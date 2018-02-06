using FluentValidator;
using FluentValidator.Validation;

namespace Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        #region Constructors
        public Email(string address)
        {
            Address = address;

            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .IsEmail(Address, "Address", "E-mail inválido.")
                );
        }
        #endregion

        #region Properties
        public string Address { get; private set; }
        #endregion

        #region Methods
        public override string ToString() => Address;
        #endregion
    }
}