using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {

    private int i = 1;
    public FormattedText text;

	void Start ()
    {
        
        //var s = Localization.Get.GetType().GetField("mainMenu").GetValue(Localization.Get);
        //s = s.GetType().GetField("settings").GetValue(s);
        //Debug.Log(s);
	}

    public void Click()
    {
        text.SetValue(i);
        i++;
        //Settings.Data.lang = "ru";
        //Settings.Save();
        //Localization.UpdateLocale();
        
    }
}
