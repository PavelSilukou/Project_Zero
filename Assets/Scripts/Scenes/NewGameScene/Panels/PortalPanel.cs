using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPanel : NewGameScenePanel
{
    private Portal selectedPortal;

    public void SetPortal(Portal portal)
    {
        selectedPortal = portal;
    }
}
