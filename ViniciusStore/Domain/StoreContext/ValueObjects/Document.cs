namespace Domain.StoreContext.ValueObjects
{
    public class Document
    {
        #region Constructors
        public Document(string number)
        {
            Number = number;
        }
        #endregion

        #region Properties
        public string Number { get; private set; }
        #endregion

        #region Methods
        public override string ToString() => Number;
        #endregion
    }
}