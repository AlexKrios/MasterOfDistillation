using UnityEngine;

namespace Assets.Scripts.Ui.FullMenu.Common.Model
{
    public interface IModelGroup
    {
        Transform Transform { get; set; }

        void CreateModel();
    }
}
