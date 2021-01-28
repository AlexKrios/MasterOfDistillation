using UnityEngine;

namespace Scripts.UI.Vodka
{
    public class VodkaManager : MonoBehaviour, IVodkaManager
    {
        private int _vodkaResource;
        public int VodkaResource
        {
            get { return _vodkaResource; }
            set { _vodkaResource = value; }
        }

        private int _vodkaComponentBronze;
        public int VodkaComponentBronze
        {
            get { return _vodkaComponentBronze; }
            set { _vodkaComponentBronze = value; }
        }

        private int _vodkaComponentSilver;
        public int VodkaComponentSilver
        {
            get { return _vodkaComponentSilver; }
            set { _vodkaComponentSilver = value; }
        }

        private int _vodkaComponentGold;
        public int VodkaComponentGold
        {
            get { return _vodkaComponentGold; }
            set { _vodkaComponentGold = value; }
        }

        private void Start() { }
    }
}
