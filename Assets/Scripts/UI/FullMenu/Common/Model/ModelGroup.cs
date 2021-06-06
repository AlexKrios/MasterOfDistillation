using JetBrains.Annotations;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Model
{
    [UsedImplicitly]
    public class ModelGroup : MonoBehaviour, IModelGroup
    {
        [Inject] private readonly ModelGameObject.Factory _modelFactory;

        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;
        private ModelGameObject _model;

        public Transform Transform { get; set; }

        private void Awake()
        {
            Transform = transform;

            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _fullMenu.Model = this;
        }

        private void Start()
        {
            CreateModel();
        }

        public void CreateModel()
        {
            if (_model != null) 
                RemoveModel();

            var model = _fullMenu.ActiveItem.Product.Model;

            _model = _modelFactory.Create(model);
        }

        private void RemoveModel()
        {
            Destroy(_model.gameObject);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ModelGroup> { }
    }
}
