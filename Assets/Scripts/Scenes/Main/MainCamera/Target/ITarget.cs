using UnityEngine;

namespace Assets.Scripts.Scenes.Main.MainCamera.Target
{
    public interface ITarget
    {
        Vector3 Position { get; set; }
        void SetTargetPos();
    }
}
