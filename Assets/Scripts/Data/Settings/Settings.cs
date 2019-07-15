using UnityEngine;

public static class Settings
{
    public static SettingsData Data { get; private set; }

    public static void Init()
    {
        Data = new SettingsIO().Read();
        
        if (!Data.isLocaleSet)
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.English:
                    Data.locale = Locales.EN;
                    break;
                case SystemLanguage.Russian:
                    Data.locale = Locales.RU;
                    break;
                default:
                    Data.locale = Locales.EN;
                    break;
            }
        }

        Save();
    }

    public static void Save()
    {
        if (Data != null)
        {
            new SettingsIO().Write(Data);
        }
    }
}