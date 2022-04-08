using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    // The list of all the panels available for our manager
    public List<PanelModel> Panels;

    // This is going to hold all of our instances
    private Queue<PanelInstanceModel> _queue = new Queue<PanelInstanceModel>();

    public void ShowPanel(string panelID)
    {
        PanelModel panelModel = Panels.FirstOrDefault(panel => panel.PanelID == panelID);

        if (panelModel != null)
        {
            // Create a new instance
            var newInstancePanel = Instantiate(panelModel.PanelPrefab, transform);

            newInstancePanel.transform.localPosition = Vector3.zero;

            // Add this new panel to the queue
            _queue.Enqueue(new PanelInstanceModel
            {
                PanelID = panelID,
                PanelInstance = newInstancePanel
            });
        }
        else
        {
            Debug.LogWarning($"Trying to use panelID ={panelID},but this is not found in Panels");
        }
    }

    public void HideLastPanel()
    {
        // Make sure we do have a panel
        if (AnyPanelShowing())
        {
            var lastPanel = _queue.Dequeue();
        }
    }

    // Returns if any panel is showing
    public bool AnyPanelShowing()
    {
        return GetAmountPanelsInQueue() > 0;
    }

    // Returns how many panels we have in queue
    public int GetAmountPanelsInQueue()
    {
        return _queue.Count;
    }
}
