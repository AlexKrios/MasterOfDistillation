using UnityEngine;

namespace Assets.Scripts.MainCamera.Target
{
    public interface ITarget
    {
        Vector3 Position { get; set; }
        void SetTargetPos();
    }
}
