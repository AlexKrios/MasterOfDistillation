using UnityEngine;

namespace Scripts.Objects.Raw
{
    [CreateAssetMenu(fileName = "New Raw Data", menuName = "Raw Data", order = 51)]
    public class RawData : ScriptableObject
    {
        [SerializeField] private RawType _name;
        public RawType Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [SerializeField] private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [SerializeField] private Sprite _icon;
        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}