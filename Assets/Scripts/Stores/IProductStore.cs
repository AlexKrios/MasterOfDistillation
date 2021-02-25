using Scripts.Objects.Component;
using System.Collections.Generic;

namespace Scripts.Stores
{
    public interface IProductStore 
    {
        List<ComponentObject> Components { get; set; }
    }
}
