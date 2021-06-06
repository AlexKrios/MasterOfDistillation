namespace Assets.Scripts.Stores.Level
{
    public interface ILevelStore
    {
        InitLevelEvent OnInitLevel { get; }
        SetExperienceEvent OnSetExperience { get; }
    }
}
