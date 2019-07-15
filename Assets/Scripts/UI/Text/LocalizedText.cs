using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public LocaleString localizedString;
    private void Awake()
    {
        var textComponent = gameObject.GetComponent<Text>();
        textComponent.text = Localization.GetLocalizedTextByEnum(localizedString);
    }
}
