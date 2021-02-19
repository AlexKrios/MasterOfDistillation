using Scripts.Stores.Raw;

namespace Scripts.Stores
{
    public interface IProductStore 
    {
        int ComponentCommon { get; set; }
        int ComponentBronze { get; set; }
        int ComponentSilver { get; set; }
        int ComponentGold { get; set; }
    }
}
