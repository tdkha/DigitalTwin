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

    public void OnPointerClick(PointerEventData eventData)
    {
        Browser foundTask = taskManager.FindBrowserTaskByName("Browser");
        if (foundTask != null && browserTab != null)
        {
            
            if (count == null || !int.TryParse(count.text, out int intCount))
            {
                Debug.LogError("count is null or not a valid integer!");
                return;
            }
                if (intCount == 0)
                {
                    return;
                }
            foundTask.CloseTab(browserTab);
            // Now you can use intCount safely
            intCount--;

            count.text = intCount.ToString();
        }

    }

}
