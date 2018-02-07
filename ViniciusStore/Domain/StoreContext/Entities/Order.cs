using Domain.StoreContext.Enums;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        #region Constructor
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        #endregion

        #region Properties
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
        #endregion

        #region Methods
        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque, apenas {product.QuantityOnHand} quantidades.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //Criar um pedido
        public void GenerateOrder()
        {
            //Gerar o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            //Validar
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
        }

        //Pagar um pedido
        public void PayOrder()
        {
            Status = EOrderStatus.Paid;
        }

        //Enviar um pedido
        public void ShipOrder()
        {
            // Regra, a cada 5 produtos é gerado uma entrega
            var deliveries = new List<Delivery>();

            // Gera a primeira entrega para pedidos com menos de 5 produtos ou número de produtos não multiplos de 5.
            if (_items.Count % 5 != 0 && _items.Count > 5 || _items.Count < 5 && deliveries.Count < 1)
                deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));

            // Quebra as entregas
            var count = 1;
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 0;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            // Envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            // Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        //Cancelar um pedido
        public void CancelOrder()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
        #endregion
    }
}