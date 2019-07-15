using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : GObject
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
