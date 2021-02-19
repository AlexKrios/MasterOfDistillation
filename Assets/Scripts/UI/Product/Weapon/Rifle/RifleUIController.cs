using Scripts.UI.Product;

namespace Scripts.UI.Money
{
    public class RifleUIController : AbstractProductUIController
    {
        protected override void SetComponentCommonText() 
        {
            if (!_componentCommonText)
            {
                _componentCommonText = _uiController.Find("Rifle").GetComponent<ProductUI>().ComponentCommonText;
            }

            _componentCommonText.text = _productStore.ComponentCommon.ToString();
        }
    }
}
