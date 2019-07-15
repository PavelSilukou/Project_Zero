using System;

public class SelectLanguagesScene : GameScene
{
    public void SelectLocale(string locale)
    {
        var localeValue = (Locales)Enum.Parse(typeof(Locales), locale, true);
        Settings.Data.locale = localeValue;
        Settings.Data.isLocaleSet = true;
        Settings.Save();
        Localization.UpdateLocale();
        LoadNextScene(Menu);
    }
}
