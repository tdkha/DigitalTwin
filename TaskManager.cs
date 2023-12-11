using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private List<Task> tasks_; 
    private float cpuTemperature_;
    private float gpuTemperature_;
    private float cpuPerformance_;
    private float gpuPerformance_;
    private float ramUsage_;

    private bool isUpdated;

    private float totalCpuCapacity = 100.0f;  // Percentages
    private float totalGpuCapacity = 100.0f; // Percentages
    private float totalRamCapacity = 64.0f; //  GB

    private float maxTemp = 80;
    private float minTemp = 40;

   

    public void Start()
    {
        tasks_ = new List<Task>();
        cpuTemperature_ = 20;
        gpuTemperature_ = 20;
        cpuPerformance_ = 10;
        gpuPerformance_ = 10;
        ramUsage_ = 20;
        isUpdated = false;
    }
    public void Update()
    {
        if(tasks_!= null)
        {
            //List<Browser> chromeInstances = tasks_.OfType<Browser>().Where(chrome => chrome.GetNumTabs() == 0).ToList();

            //foreach (var chromeInstance in chromeInstances)
            //{
            // // tasks_.Remove(chromeInstance);
            //}

            float totalCPU = 0;
            float totalGPU = 0;
            float totalRAM = 0;
            foreach (Task task in tasks_)
            {
                totalCPU += task.GetCpuImpact();
                totalGPU += task.GetGpuImpact();
                totalRAM += task.GetRamImpact();
            }
            cpuPerformance_ = totalCPU;
            gpuPerformance_ = totalGPU;
            ramUsage_ = totalRAM;
        }
       
    }
    public float getCpuTemp()
    {
        return cpuTemperature_;
    }
    public float getGpuTemp()
    {
        return gpuTemperature_;
    }
    public float getCpuPerformance()
    {
        return cpuPerformance_;
    }
    public float getGpuPerformance()
    {
        return gpuPerformance_;
    }
    void Validate()
    {
        if (cpuTemperature_ >= maxTemp || gpuTemperature_ >= maxTemp)
        {
            Debug.Log($"Computer gets too hot");// Warn and stop
        }
    }

    public void AddTask(Task task)
    {
        int index = tasks_.IndexOf(task);
        if(index == -1 )
        {
            tasks_.Add(task);
            isUpdated = true;
        }
        
    }

    public void RemoveTask(Task task)
    {
        tasks_.Remove(task);
        isUpdated = true;
        Debug.Log($"Removed task '{task.GetName()}'.");
    }
    public Task FindTask(string id)
    {
        return tasks_.Find(task => task.GetName() == id);
    }
    public Browser FindBrowserTaskByName(string taskName)
    {
        return tasks_.Find(task => task is Browser && task.GetName() == taskName) as Browser;
    }

    public Game FindGameTaskByName(string taskName)
    {
        return tasks_.Find(task => task is Game && task.GetName() == taskName) as Game;
    }
    public void DisplayTasks()
    {
        Debug.Log("Current tasks:");
        if(tasks_ != null)
        {
            foreach (var task in tasks_)
            {
                Debug.Log($"Name: {task.GetName()}, RAM Impact: {task.GetRamImpact()}, CPU Impact: {task.GetCpuImpact()}, GPU Impact: {task.GetGpuImpact()}");
            }
        }
    }
    public void DisplaySpecs()
    {
        if (tasks_ != null )
        {
            Debug.Log($"Total Task: {tasks_.Count}");
            Debug.Log($"CPU Performance: {getCpuPerformance()}");
            Debug.Log($"GPU Performance: {getGpuPerformance()}");
        }
            
    }
}