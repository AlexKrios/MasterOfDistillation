using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Objects
{
    [CreateAssetMenu(fileName = "LevelCaps", menuName = "Level Caps", order = 51)]
    public class LevelCapsScriptable : ScriptableObject
    {
        [SerializeField] private List<int> _caps;
        public List<int> Caps { get => _caps; }
    }
}
