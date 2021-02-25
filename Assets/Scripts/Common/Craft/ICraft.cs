namespace Scripts.Common.Craft
{
    public interface ICraft
    {
        string ProductType { get; set; }

        void CraftComponent();
    }
}
