using System;
using UnityEngine;

public static class PlayerPrefsExtension
{
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public static T GetEnum<T>(string key)
    {
        var value = PlayerPrefs.GetString(key);
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static void SetEnum<T>(string key, T value)
    {
        PlayerPrefs.SetString(key, value.ToString());
    }
}
