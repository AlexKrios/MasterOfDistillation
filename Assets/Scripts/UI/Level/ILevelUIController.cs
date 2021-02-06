namespace Scripts.UI.Level
{
    public interface ILevelUIController
    {
        void SetLevel(int value);
        void SetCurrentExperience(int value);
        void PlusCurrentExperience(int value);
        void SetLevelExperience();
        void SetLevelPercent();
    }
}
