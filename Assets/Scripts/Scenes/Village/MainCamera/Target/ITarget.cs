using UnityEngine;

namespace Scripts.Scenes.Village.MainCamera
{
    public interface ITarget
    {
        Vector3 Position { get; set; }
        void SetTargetPos();
    }
}
