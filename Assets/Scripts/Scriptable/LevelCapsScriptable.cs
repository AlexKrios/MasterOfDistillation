using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649

namespace Assets.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "LevelCaps", menuName = "Level Caps", order = 51)]
    public class LevelCapsScriptable : ScriptableObject
    {
        [SerializeField] private List<int> _caps;
        public List<int> Caps => _caps;
    }
}
