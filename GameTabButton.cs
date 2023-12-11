using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameTabButton: MonoBehaviour
{
    public string id;
    public GameObject panel;
    public GameObject button;
    public Game Game;
    public Tab browserTab;
    TaskManager taskManager;
    void Start()
    {
        id = "Google";
        if (taskManager != null)
        {
            if (id == "Youtube")
            {
                browserTab = gameObject.AddComponent<Tab>();
                browserTab.SetName("Youtube");
                browserTab.SetRamImpact(250);
                browserTab.SetCpuImpact(10);
                browserTab.SetGpuImpact(10);
            }
            if (id == "Yle")
            {
                browserTab = gameObject.AddComponent<Tab>();
                browserTab.SetName("Yle");
                browserTab.SetRamImpact(150);
                browserTab.SetCpuImpact(8);
                browserTab.SetGpuImpact(8);
            }
            if (id == "Reddit")
            {
                browserTab = gameObject.AddComponent<Tab>();
                browserTab.SetName("Reddit");
                browserTab.SetRamImpact(200);
                browserTab.SetCpuImpact(12);
                browserTab.SetGpuImpact(12);
            }
        }


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (taskManager)
        {
            Browser foundTask = taskManager.FindBrowserTaskByName(id);
            if (foundTask != null && browserTab != null)
            {
                foundTask.OpenTab(browserTab);
            }
        }
        Debug.Log("Failed to open brewser tab window");

    }
}
