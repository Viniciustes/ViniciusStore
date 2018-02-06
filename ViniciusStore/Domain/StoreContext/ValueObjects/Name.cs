using FluentValidator;
using FluentValidator.Validation;

namespace Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        #region Constructors
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
                );
        }
        #endregion

        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        #endregion
    }
}