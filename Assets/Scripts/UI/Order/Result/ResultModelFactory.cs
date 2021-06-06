using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.Order.Result
{
    [UsedImplicitly]
    public class ResultModelFactory : IFactory<GameObject, ResultModel> 
    {
        [Inject] private readonly DiContainer _container;

        public ResultModel Create(GameObject obj)
        {
            var result = _container.InstantiatePrefabForComponent<ResultModel>(obj);
            result.name = "Model";

            return result;
        }
    }
}
