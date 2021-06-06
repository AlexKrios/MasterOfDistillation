using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Assets.Scripts.MainCamera.Disable
{
    [UsedImplicitly]
    public class Disable : IDisable
    {
        private readonly List<DisableType?> _list;

        public Disable()
        {
            _list = new List<DisableType?>();
        }

        public void Add(DisableType value)
        {
            _list.Add(value);
        }

        public void Remove(DisableType value)
        {
            _list.Remove(value);
        }

        public bool Find(DisableType value)
        {
            var item = _list.FirstOrDefault(x => x == value);

            return item != null;
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}