using Scripts.Common.Craft;
using Scripts.Common.Craft.Action;
using Scripts.Objects.Craft;
using Scripts.Timer;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft.Create
{
    public class CreateButton : MonoBehaviour
    {
        [Inject] private ICraftController _craftController;
        [Inject] private CraftAction _craftAction;

        [SerializeField] private CraftMenuUI _menu;

        private Transform _sceneContext;

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            _sceneContext = sceneContext;
        }

        private void Start() { }

        public void CraftItem()
        {
            var index = _craftController.CheckFreeIndex();

            if (!_craftAction.IsEnoughParts())
            {
                Debug.LogWarning("Нехватает ингридиентов");
                return;
            }

            if (index == null)
            {
                Debug.LogWarning("Нехватает ячеек для крафта");
                return;
            }

            var coroutine = StartCoroutine(_craftAction.StartCraft((int)index));
            var craftObj = new CraftObject()
            {
                Item = _menu.ItemsGroup.ActiveItem.Product,
                Quality = _menu.QualityBtn.ActiveQuality,
                Coroutine = coroutine
            };

            _craftController.CraftList.Add((int)index, craftObj);

            _menu.PartGroup.SetPartsInfo();
        }

        public void StartRawTimer()
        {
            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }        
    }
}
