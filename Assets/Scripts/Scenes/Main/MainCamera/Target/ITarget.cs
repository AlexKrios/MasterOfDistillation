using UnityEngine;

namespace Scripts.Scenes.Main.MainCamera
{
    public interface ITarget
    {
        Vector3 Position { get; set; }
        void SetTargetPos();
    }
}
