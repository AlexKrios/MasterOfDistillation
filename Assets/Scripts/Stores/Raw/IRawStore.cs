using Scripts.Objects.Raw;
using Scripts.Objects.Raw.Load;
using System.Collections.Generic;

namespace Scripts.Stores.Raw
{
    public interface IRawStore
    {
        Dictionary<string, RawObject> RawData { get; }

        void InitRawListData(List<RawLoadObject> rawInfo);

        void SetRawListData(string type, int count);
    }
}
