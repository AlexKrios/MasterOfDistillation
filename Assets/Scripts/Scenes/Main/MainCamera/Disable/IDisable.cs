namespace Assets.Scripts.Scenes.Main.MainCamera.Disable
{
    public interface IDisable
    {
        void Add(string value);
        void Remove(string value);
        bool Find(string value);
        bool IsEmpty();
        void Clear();
    }
}
