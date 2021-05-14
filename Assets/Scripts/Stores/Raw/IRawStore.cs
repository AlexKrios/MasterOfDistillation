using System.Collections.Generic;
using Assets.Scripts.Objects.Raw;
using Assets.Scripts.Objects.Raw.Load;

namespace Assets.Scripts.Stores.Raw
{
    public interface IRawStore
    {
        Dictionary<string, RawObject> RawData { get; }

        void InitRawListData(List<RawLoadObject> rawInfo);

        void SetRawListData(string type, int count);
    }
}
