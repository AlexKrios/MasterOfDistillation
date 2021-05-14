using Scripts.Common.Craft;
using Scripts.Objects.Craft;
using Scripts.Timer;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Craft.Create
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

            var timer = StartCoroutine(_craftController.StartCraftTimer());
            var craftObj = CraftObjectFactory(timer);

            _craftController.StartCraft(craftObj);

            _menu.PartGroup.SetPartsInfo();
        }

        public void StartRawTimer()
        {
            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }

        private CraftObject CraftObjectFactory(Coroutine timer)
        {
            return new CraftObject()
            {
                Item = _menu.ItemsGroup.ActiveItem.Product,
                Quality = _menu.QualityBtn.ActiveQuality,
                Coroutine = timer
            };
        }
    }
}
