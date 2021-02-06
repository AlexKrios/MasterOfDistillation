using Scripts.Stores;
using Zenject;

namespace Scripts.Scenes.Main.Craft.Weapon.Rifle
{
    public class RifleCraft : AbstractCraft, IRifleCraft
    {
        [Inject]
        public void Construct(IProductStore productStore)
        {
            _productStore = productStore;

            ProductType = "Rifle";
        }

        private void Update()
        {
            //Debug.Log($"Raw: {_productStore.Raw}");
            //Debug.Log($"IngedientCommon: {_productStore.IngredientCommon}");
        }
    }
}
