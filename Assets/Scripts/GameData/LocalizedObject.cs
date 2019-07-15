public class LocalizedObject
{
    public string LocalizedName
    {
        get
        {
            return Localization.GetLocalizedTextByType(this.GetType());
        }
    }
}
