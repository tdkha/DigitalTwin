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
                browserTab.SetRamImpact(250.0f);
                browserTab.SetCpuImpact(10.0f);
                browserTab.SetGpuImpact(10.0f);
            }
            if (id == "Yle")
            {
                browserTab = gameObject.AddComponent<Tab>();
                browserTab.SetName("Yle");
                browserTab.SetRamImpact(150.0f);
                browserTab.SetCpuImpact(8.0f);
                browserTab.SetGpuImpact(8.0f);
            }
            if (id == "Reddit")
            {
                browserTab = gameObject.AddComponent<Tab>();
                browserTab.SetName("Reddit");
                browserTab.SetRamImpact(200.0f);
                browserTab.SetCpuImpact(12.0f);
                browserTab.SetGpuImpact(12.0f);
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
