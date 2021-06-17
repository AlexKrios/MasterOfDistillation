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
            var result = _container.InstantiatePrefab(obj);
            _container.InstantiateComponent<ResultModel>(result.gameObject);

            var transform = result.gameObject.transform;
            transform.localPosition = new Vector3(0, 0, -500);
            transform.localRotation = Quaternion.Euler(-45, 0, 0);

            result.name = "Model";

            return result.GetComponent<ResultModel>();
        }
    }
}
