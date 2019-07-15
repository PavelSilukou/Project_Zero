using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePanel : NewGameScenePanel
{
    private Castle selectedCastle;

    public void SetCastle(Castle castle)
    {
        selectedCastle = castle;
        ShowPanel();
    }
}
