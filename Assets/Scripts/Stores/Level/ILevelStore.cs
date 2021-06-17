namespace Assets.Scripts.Stores.Level
{
    public interface ILevelStore
    {
        int Level { get; }

        InitLevelEvent OnInitLevel { get; }
        SetExperienceEvent OnSetExperience { get; }
    }
}
