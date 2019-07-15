public class SettingsData
{
    public Locales locale;
    public bool isLocaleSet;

    public SettingsData()
    {
        locale = Locales.EN;
        isLocaleSet = false;
    }
}