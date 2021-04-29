using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Objects
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Level Settings", order = 51)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private List<LevelCaps> _caps;
        public List<LevelCaps> Caps { get => _caps; }
    }
}
