using Scripts.UI.Product;
using System.Linq;

namespace Scripts.UI.Money
{
    public class RifleUIController : AbstractProductUIController
    {
        protected override void SetComponentText() 
        {
            if (!_componentText)
            {
                _componentText = _uiController.Find("Rifle").GetComponent<ProductUI>().ComponentText;
            }

            var common = _productStore.Components.First(x => x.Quality == "Common").Count;
            var bronze = _productStore.Components.First(x => x.Quality == "Bronze").Count;
            var silver = _productStore.Components.First(x => x.Quality == "Silver").Count;
            var gold = _productStore.Components.First(x => x.Quality == "Gold").Count;

            _componentText.text = $"{common}/{bronze}/{silver}/{gold}";
        }
    }
}
