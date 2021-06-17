namespace Assets.Scripts.Stores.Raw
{
    public interface IRaw
    {
        string Name { get; set; }

        ItemType ItemType { get; set; }
        RawType RawType { get; set; }

        int Count { get; set; }

        RawSettingsObject Settings { get; set; }
    }
}
