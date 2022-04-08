using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelbutton : MonoBehaviour
{
    // The ID of the panel we want to show
    public string PanelID;
    
    // Cashed panels manager
    private PanelManager _panelManager;

    private void Start()
    {
        // Cache this
        _panelManager = PanelManager.Instance;
    }

    public void DoShowPanel()
    {
        _panelManager.ShowPanel(PanelID);
    }
}
