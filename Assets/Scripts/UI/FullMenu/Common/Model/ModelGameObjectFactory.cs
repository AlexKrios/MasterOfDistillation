using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.FullMenu.Common.Model
{
    [UsedImplicitly]
    public class ModelGameObjectFactory : IFactory<GameObject, ModelGameObject> 
    {
        [Inject] private readonly DiContainer _container;

        [Inject] private readonly IUiController _uiController;

        public ModelGameObject Create(GameObject obj)
        {
            var parent = _uiController.FindByPart("Menu").GetComponent<IFullMenu>().Model.Transform;

            var result = _container.InstantiatePrefab(obj, parent);
            _container.InstantiateComponent<ModelGameObject>(result.gameObject);

            result.gameObject.name = "Model";

            return result.GetComponent<ModelGameObject>();
        }
    }
}
