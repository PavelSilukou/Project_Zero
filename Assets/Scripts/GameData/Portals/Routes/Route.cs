using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Route
{
    [SerializeField]
    private List<Tile> tilesPositions = new List<Tile>();

    public RouteIterator GetIterator()
    {
        return new RouteIterator(this);
    }

    public int Count
    {
        get { return tilesPositions.Count; }
    }

    public Tile this[int index]
    {
        get { return tilesPositions[index]; }
        set { tilesPositions.Add(value); }
    }
}