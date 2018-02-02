using Domain.StoreContext.ValueObjects;
using FluentValidator;
using System.Collections.Generic;
using System.Linq;

namespace Domain.StoreContext.Entities 
{
    public class Customer : Notifiable
    {
        #region Constructors
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }
        #endregion

        #region Properties
        private readonly IList<Address> _addresses;

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
        #endregion

        #region Methods
        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public void Register() { }

        public override string ToString() => Name.ToString();
        #endregion

        #region Events
        public void OnRegister() { }
        #endregion
    }
}