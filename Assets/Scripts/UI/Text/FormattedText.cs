using UnityEngine;
using UnityEngine.UI;

public class FormattedText : MonoBehaviour
{
    private string initialText;
    private Text textComponent;

    private void Awake()
    {
        textComponent = gameObject.GetComponent<Text>();
    }

    public void SetValue(params object[] parameters)
    {
        if (string.IsNullOrEmpty(initialText))
        {
            initialText = textComponent.text;
        }
        textComponent.text = string.Format(initialText, parameters);
    }
}
