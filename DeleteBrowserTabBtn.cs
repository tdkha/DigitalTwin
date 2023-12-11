using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DeleteBrowserTabBtn : MonoBehaviour, IPointerClickHandler
{
    public string id;
    public GameObject panel;
    public Tab browserTab;
    public TextMeshProUGUI count;
    public TaskManager taskManager;
    void Start()
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

    public void OnPointerClick(PointerEventData eventData)
    {
        Browser foundTask = taskManager.FindBrowserTaskByName("Browser");
        if (foundTask != null && browserTab != null)
        {
            foundTask.CloseTab(id);
            if (count == null || !int.TryParse(count.text, out int intCount))
            {
                Debug.LogError("count is null or not a valid integer!");
                return;
            }

            // Now you can use intCount safely
            intCount--;

            count.text = intCount.ToString();
        }

    }

}
