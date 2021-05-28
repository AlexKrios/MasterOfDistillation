using Assets.Scripts.Common.Craft;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.Ui.Craft.Order.State;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Order
{
    [UsedImplicitly]
    public class CraftCell : MonoBehaviour, IPointerClickHandler
    {
        private Dictionary<Type, ICraftCellState> _stateMap;
        private ICraftCellState _currentState;

        [NonSerialized] public ICraftController CraftController;
        [NonSerialized] [Inject] public readonly ILevelStore LevelStore;
        [NonSerialized] [Inject] public readonly IProductStore ProductStore;

        [SerializeField] private CraftCellsGroup _craftCellsGroup;

        public int Id { get; set; }

        [Header("Product cell info")]
        [SerializeField] private Image _icon;
        public Image Icon => _icon;

        [SerializeField] private Text _timer;
        public Text Timer => _timer;

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            CraftController = sceneContext.GetComponent<ICraftController>();
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            InitStates();
            SetStateByDefault();

            _craftCellsGroup.SubscribeCellToList(this);
            Id = _craftCellsGroup.Cells.Count - 1;
        }

        private void InitStates()
        {
            _stateMap = new Dictionary<Type, ICraftCellState>
            {
                [typeof(CraftCellEmpty)] = new CraftCellEmpty(this),
                [typeof(CraftCellBusy)] = new CraftCellBusy(this),
                [typeof(CraftCellFinish)] = new CraftCellFinish(this)
            };
        }

        private ICraftCellState GetState<T>() where T : ICraftCellState
        {
            var type = typeof(T);
            return _stateMap[type];
        }

        private void SetState(ICraftCellState newState)
        {
            _currentState?.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        public void SetStateByDefault()
        {
            SetStateEmpty();
        }

        public void SetStateEmpty()
        {
            var state = GetState<CraftCellEmpty>();
            SetState(state);
        }

        public void SetStateBusy()
        {
            var state = GetState<CraftCellBusy>();
            SetState(state);
        }

        public void SetStateFinish()
        {
            var state = GetState<CraftCellFinish>();
            SetState(state);
        }

        public bool IsFreeForCraft()
        {
            return _currentState is CraftCellEmpty;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _currentState.Click();
        }

        public void ResetCell()
        {
            _icon.color = new Color(1, 1, 1, 0);
            _icon.sprite = null;

            _timer.text = null;
        }

        public void SetCellIcon(Sprite icon)
        {
            Icon.color = new Color(1, 1, 1, 1);
            Icon.sprite = icon;
        }

        public void SetCellTimer(string timer)
        {
            Timer.text = timer;
        }
    }
}
