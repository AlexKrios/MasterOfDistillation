using Assets.Scripts.Common.Craft;
using Assets.Scripts.Objects.Craft;
using Assets.Scripts.Timer;
using UnityEngine;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Create
{
    public class CreateButton : MonoBehaviour
    {
        private ICraftController _craftController;

        [SerializeField] private CraftMenu _menu;

        private Transform _sceneContext;

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            _sceneContext = sceneContext;
            _craftController = sceneContext.GetComponent<ICraftController>();
        }

        // ReSharper disable once UnusedMember.Local
        private void Start() { }

        public void CraftItem()
        {            
            if (!_craftController.IsEnoughParts())
            {
                Debug.LogWarning("Нехватает ингридиентов");
                return;
            }
            
            if (!_craftController.IsHaveFreeCell())
            {
                Debug.LogWarning("Нехватает ячеек для крафта");
                return;
            }

            var craftObj = CraftObjectFactory();
            _craftController.StartCraft(craftObj);

            _menu.PartGroup.SetPartsInfo();
        }

        public void StartRawTimer()
        {
            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }

        private CraftObject CraftObjectFactory()
        {
            return new CraftObject()
            {
                Item = _menu.ItemsGroup.ActiveItem.Product,
                Quality = _menu.QualityBtn.ActiveQuality,
            };
        }
    }
}
