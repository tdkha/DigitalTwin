using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Models;
using Unity.VisualScripting;

public class TabButton : MonoBehaviour, IPointerClickHandler 
{ 
    public string id;
    public TabGroup tabGroup;
    public GameObject panel;
    private TextMeshProUGUI cpuPerformance; // used for displaying in TaskManger tab
    private TextMeshProUGUI gpuPerformance;// used for displaying in TaskManger tab
    public TaskManager taskManager;
    private Task task;
    private bool isUpdated;

    // Start is called before the first frame update
    void Start()
    {
        
        panel.SetActive(false);
        tabGroup.Subscribe(this);

       

        if (id == "Browser")
        {
            task = gameObject.AddComponent<Browser>();
            task.SetName(id);
            task.SetCpuImpact(0);
            task.SetGpuImpact(0);
            task.SetRamImpact(0);
        }
        if (id == "Game")
        {
            task = gameObject.AddComponent<Game>();
            task.SetName(id);
            task.SetCpuImpact(200);
            task.SetGpuImpact(200);
            task.SetRamImpact(200);
        }
        if(id == "TaskManager")
        {
            cpuPerformance = panel.transform.Find("CPUPerformanceSpecs")?.GetComponent<TextMeshProUGUI>();
            gpuPerformance = panel.transform.Find("GPUPerformanceSpecs")?.GetComponent<TextMeshProUGUI>();
        }
        isUpdated = true;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (id != "TaskManager" && id != "Game")
        {
            if (isUpdated)
            {
                taskManager.AddTask(task);
                isUpdated = false;
            }
            tabGroup.OnTabSelected(this);   
        }
        else if (id == "TaskManager")
        {
            tabGroup.OnTabSelected(this);
            float tempCPU = taskManager.getCpuPerformance();
            float tempGPU = taskManager.getGpuPerformance();
            cpuPerformance.text = tempCPU.ToString();
            gpuPerformance.text = tempGPU.ToString();
        }else if (id == "Game")
        {
            if (isUpdated)
            {
                isUpdated = false;
            }    
            tabGroup.OnTabSelected(this);
        }

    }

}
