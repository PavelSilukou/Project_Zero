using UnityEngine;

public class SettingsIO
{
    public SettingsData Read()
    {
        if (PlayerPrefs.HasKey("locale"))
        {
            return new SettingsData
            {
                locale = PlayerPrefsExtension.GetEnum<Locales>("locale"),
                isLocaleSet = PlayerPrefsExtension.GetBool("isLocaleSet")
            };
        }
        else
        {
            return new SettingsData();
        }
    }

    public void Write(SettingsData settings)
    {
        PlayerPrefsExtension.SetEnum("locale", settings.locale);
        PlayerPrefsExtension.SetBool("isLocaleSet", settings.isLocaleSet);
        PlayerPrefs.Save();
    }
}
