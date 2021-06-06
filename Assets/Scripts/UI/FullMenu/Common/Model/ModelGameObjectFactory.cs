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

            var result = _container.InstantiatePrefabForComponent<ModelGameObject>(obj, parent);
            result.name = "Model";

            return result;
        }
    }
}
