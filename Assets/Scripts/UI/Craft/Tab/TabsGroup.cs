using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Craft.Tab
{
    [UsedImplicitly]
    public class TabsGroup : MonoBehaviour, ITabsGroup
    {
        #region Links

        private List<ITabButton> _tabs;
        public ITabButton ActiveTab { get; set; }

        #endregion

        #region Assets

        [Header("Assets")]
        [SerializeField] private Sprite _bgInactive;
        public Sprite BgInactive => _bgInactive;

        [SerializeField] private Sprite _bgActive;
        public Sprite BgActive => _bgActive;

        #endregion

        public void SubscribeTabToList(TabButton button)
        {
            if (_tabs == null)
            {
                _tabs = new List<ITabButton>();
            }

            _tabs.Add(button);

            if (transform.childCount == _tabs.Count)
            {
                ActiveTab = _tabs[0];
            }
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TabsGroup> { }
    }
}
