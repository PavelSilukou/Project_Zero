using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleTile : Tile
{
    private void OnMouseDown()
    {
        FindObjectOfType<CastlePanel>().SetCastle(GetCastle());
    }

    public Castle GetCastle()
    {
        return GetComponentInChildren<Castle>();
    }
}
