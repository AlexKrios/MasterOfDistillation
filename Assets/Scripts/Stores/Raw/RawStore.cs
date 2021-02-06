namespace Scripts.Stores.Raw
{
    public class RawStore : IRawStore
    {
        private int _iron;
        public int Iron
        {
            get { return _iron; }
            set { _iron = value; }
        }
    }
}
