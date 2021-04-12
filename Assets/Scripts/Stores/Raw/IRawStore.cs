using Scripts.Objects.Raw;
using System.Collections.Generic;

namespace Scripts.Stores.Raw
{
    public interface IRawStore
    {
        List<RawObject> RawInfo { get; set; }
        int Iron { get; set; }
    }
}
