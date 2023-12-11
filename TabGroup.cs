using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<GameObject> tabPanels;


    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);

        if (tabPanels == null)
        {
            tabPanels = new List<GameObject>();
        }

        tabPanels.Add(button.panel);
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTabs();

        int index = tabButtons.IndexOf(button);
        if (index >= 0 && index < tabPanels.Count)
        {
            tabPanels[index].SetActive(true);
        }
    }

    public void ResetTabs()
    {
        foreach (GameObject panel in tabPanels)
        {
            panel.SetActive(false);
        }
    }
}