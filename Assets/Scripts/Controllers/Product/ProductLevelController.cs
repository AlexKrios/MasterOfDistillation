using Assets.Scripts.Stores.Craft;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers.Product
{
    public class ProductLevelController
    {
        public SetExperienceEvent OnSetExperience;

        public ProductLevelController()
        {
            if (OnSetExperience == null)
                OnSetExperience = new SetExperienceEvent();

            OnSetExperience.AddListener(SetProductExperience);
        }

        private void SetProductExperience(ICraftable product)
        {
            product.Experience++;
        }
    }

    public class SetExperienceEvent : UnityEvent<ICraftable> { }
}
