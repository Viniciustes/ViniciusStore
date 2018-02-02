namespace Domain.StoreContext.ValueObjects
{
    public class Email
    {
        #region Constructors
        public Email(string address)
        {
            Address = address;
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