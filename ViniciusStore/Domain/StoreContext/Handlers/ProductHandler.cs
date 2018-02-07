using Domain.StoreContext.Commands.ProductCommands.Inputs;
using Domain.StoreContext.Commands.ProductCommands.Outputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Repositories;
using FluentValidator;
using Shared.Commands;

namespace Domain.StoreContext.Handlers
{
    public class ProductHandler : Notifiable, ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ICommandResult Handle(CreateProductCommand command)
        {
            // Verificar se o produto já existe na base pelo nome
            if (productRepository.CheckProductExistsByTitle(command.Title))
                AddNotification("Title", "Produto já cadastrado com esse nome");

            // Verificar se o preço foi informado
            if (command.Price == 0)
                AddNotification("Price", "O preço do produto é inválido");

            // Criar e entidade
            var product = new Product(command.Title, command.Description, command.Image, command.Price, command.QuantityOnHand);

            // Validar entidade
            AddNotifications(product.Notifications);

            if (Invalid) return null;

            // Persistir o produto
            productRepository.SaveProduct(product);

            return new CreateProductCommandResult(product.Id, command.Title, command.Price, command.QuantityOnHand);
        }
    }
}