using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Scenes.Main.MainCamera.Disable
{
    public class Disable : IDisable
    {
        private readonly List<string> _list;

        public Disable()
        {
            _list = new List<string>();
        }

        public void Add(string value)
        {
            _list.Add(value);
        }

        public void Remove(string value)
        {
            _list.Remove(value);
        }

        public bool Find(string value)
        {
            var item = _list.FirstOrDefault(x => x == value);

            if (item == null)
            {
                return false;
            }

            return true;
        }

        public bool IsEmpty()
        {
            return _list.Count == 0;
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}