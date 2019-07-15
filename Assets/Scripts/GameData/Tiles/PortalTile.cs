using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTile : Tile
{
    private void OnMouseDown()
    {
        FindObjectOfType<PortalPanel>().SetPortal(GetPortal());
    }

    private Portal GetPortal()
    {
        return GetComponentInChildren<Portal>();
    }
}
