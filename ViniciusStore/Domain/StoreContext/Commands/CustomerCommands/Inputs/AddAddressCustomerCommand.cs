using Domain.StoreContext.Enums;
using FluentValidator;
using FluentValidator.Validation;
using Shared.Commands;
using System;

namespace Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCustomerCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType AddressType { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                   .IsNotNullOrEmpty(Street, "Street", "Endereço deve ser preenchido")
                   .IsNotNullOrEmpty(Number, "Number", "Numero deve ser preenchido")
                   .IsNotNullOrEmpty(Complement, "Complement", "Complemento deve ser preenchido")
                   .IsNotNullOrEmpty(District, "District", "Bairro deve ser preenchido")
                   .IsNotNullOrEmpty(City, "City", "Cidade deve ser preenchida")
                   .IsNotNullOrEmpty(State, "State", "Estado deve ser preenchido")
                   .IsNotNullOrEmpty(Country, "Country", "País deve ser preenchido")
                   .IsNotNullOrEmpty(ZipCode, "ZipCode", "Cep deve ser preenchido")
              );
            return IsValid;
        }
    }
}