namespace Domain.StoreContext.ValueObjects
{
    public class Name
    {
        #region Constructors
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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