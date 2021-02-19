namespace Scripts.Common.Craft.Weapon.Rifle
{
    public class RifleCraft : AbstractCraft, IRifleCraft
    {
        private void Start()
        {
            ProductType = "Rifle";
        }

        private void Update()
        {
            //Debug.Log($"Raw: {_productStore.Raw}");
            //Debug.Log($"IngedientCommon: {_productStore.IngredientCommon}");
        }
    }
}
