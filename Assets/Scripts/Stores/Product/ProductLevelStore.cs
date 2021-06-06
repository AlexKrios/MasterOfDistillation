using Assets.Scripts.Objects.Item;
using JetBrains.Annotations;
using UnityEngine.Events;

namespace Assets.Scripts.Stores.Product
{
    [UsedImplicitly]
    public class ProductLevelStore
    {
        public SetExperienceEvent OnSetExperience;

        public ProductLevelStore()
        {
            if (OnSetExperience == null)
            {
                OnSetExperience = new SetExperienceEvent();
            }

            OnSetExperience.AddListener(SetProductExperience);
            OnSetExperience.AddListener(SetProductLevel);
        }

        private void SetProductExperience(ICraftable product)
        {
            product.Experience++;
        }

        private void SetProductLevel(ICraftable product)
        {
            if (product.Experience < product.LevelCaps[product.Level - 1])
            {
                return;
            }

            product.Level++;
        }
    }

    public class SetExperienceEvent : UnityEvent<ICraftable> { }
}
