using System.Collections.Generic;

namespace Assets.Scripts.Stores.Raw
{
    public interface IRawStore
    {
        Dictionary<string, IRaw> RawData { get; }

        void InitRawListData(List<RawLoadObject> rawInfo);

        void SetRawListData(string type, int count);
    }
}
