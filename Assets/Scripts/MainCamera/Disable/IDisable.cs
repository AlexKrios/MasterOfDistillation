namespace Assets.Scripts.MainCamera.Disable
{
    public interface IDisable
    {
        void Add(DisableType value);
        void Remove(DisableType value);
        bool Find(DisableType value);
        void Clear();
    }
}
