using Assets.Scripts.Ui.Order.Cell.State;
using Assets.Scripts.Ui.Order.State;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Cell
{
    [UsedImplicitly]
    public class CraftCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly CraftCellEmpty.Factory _emptyFactory;
        [Inject] private readonly CraftCellBusy.Factory _busyFactory;
        [Inject] private readonly CraftCellFinish.Factory _finishFactory;

        private Dictionary<Type, ICraftCellState> _stateMap;
        private ICraftCellState _currentState;

        public int Id { get; set; }

        [Header("Product cell info")]
        [SerializeField] private Image _icon;
        [SerializeField] private Text _timer;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            InitStates();
            SetStateByDefault();
        }

        private void InitStates()
        {
            _stateMap = new Dictionary<Type, ICraftCellState>
            {
                [typeof(CraftCellEmpty)] = _emptyFactory.Create(this),
                [typeof(CraftCellBusy)] = _busyFactory.Create(this),
                [typeof(CraftCellFinish)] = _finishFactory.Create(this)
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

        private void SetStateByDefault()
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
            _icon.color = new Color(1, 1, 1, 1);
            _icon.sprite = icon;
        }

        public void SetCellTimer(string timer)
        {
            _timer.text = timer;
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftCell> { }
    }
}
