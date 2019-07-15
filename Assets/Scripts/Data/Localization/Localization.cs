using System;

public static class Localization
{
    private static Locale locale;

    public static void Init()
    {
        UpdateLocale();
    }

    public static void UpdateLocale()
    {
        switch (Settings.Data.locale)
        {
            case Locales.EN:
                locale = new EnLocale();
                break;
            case Locales.RU:
                locale = new RuLocale();
                break;
        }
    }

    public static string GetLocalizedTextByType(Type type)
    {
        var field = locale.GetType().GetField(type.Name);
        return field != null ? field.GetValue(locale).ToString() : "????????";
    }

    public static string GetLocalizedTextByEnum(LocaleString localizedString)
    {
        var field = locale.GetType().GetField(localizedString.ToString());
        return field != null ? field.GetValue(locale).ToString() : "????????";
    }
}