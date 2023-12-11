using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Browser : Task
{
    private List<Tab> openTabs;
    public Browser(string name, int ram, int cpu, int gpu)
        : base(name, ram, cpu, gpu) // Initialize non-string values to 0 for GoogleChrome instance
    {
        
    }
    public void Start()
    {
        openTabs = new List<Tab>();
    }
    public void Update()
    {
        List<Tab> tabInstances = openTabs.OfType<Tab>().Where(tab => tab.GetCount() == 0).ToList();

        foreach (var tab in tabInstances)
        {
            openTabs.Remove(tab);
        }

        UpdateSpecs();
    }


    public int GetNumTabs()
    {
        return openTabs.Count;
    }


    public void OpenTab(Tab tab)
    {
        if (!openTabs.Any(existingTab => existingTab.GetName() == tab.GetName()))
        {
            // Open the new tab
            openTabs.Add(tab);
            Debug.Log($"Opened a new tab '{tab.GetName()}'. Total tabs: {GetNumTabs()}");
        }
        else
        {
            // Same name 
            Tab foundTab = openTabs.Find(existingTab => existingTab.GetName() == tab.GetName());
            foundTab.AddTab();
            Debug.Log($"Added a tab '{tab.GetName()}'. Total tabs: {GetNumTabs()}");
        }
    }

    public void CloseTab(Tab tab)
    {
        var foundTab = openTabs.Find(existingTab => existingTab.GetName() == tab.GetName());

        if (foundTab != null)
        {
            foundTab.RemoveTab();

            if (foundTab.GetCount() == 0)
            {
                Console.WriteLine($"Closed the last tab '{tab.GetName()}'. GoogleChrome instance deleted.");
            }
            else
            {
                Console.WriteLine($"Closed a tab '{tab.GetName()}'. Total tabs: {GetNumTabs()}");
            }
        }
        else
        {
            Console.WriteLine($"No tab found with the name '{tab.GetName()}'.");
        }
    }



    private void UpdateSpecs()
    {
        int totalRam = 0, totalCpu = 0, totalGpu = 0;

        foreach (var tab in openTabs)
        {
            totalRam += tab.GetRamImpact();
            totalCpu += tab.GetCpuImpact();
            totalGpu += tab.GetGpuImpact();
        }

        // Update the specs of the GoogleChrome instance
        SetCpuImpact(totalCpu);
        SetGpuImpact(totalGpu);
        SetRamImpact(totalRam);
    }

    // Override the GetRamImpact, GetCpuImpact, and GetGpuImpact methods
    // to return the sum of the specs of all tabs if there are any tabs
    public new int GetRamImpact()
    {
        return base.GetRamImpact() ;
    }

    public new int GetCpuImpact()
    {
        return base.GetCpuImpact() ;
    }

    public new int GetGpuImpact()
    {
        return base.GetGpuImpact() ;
    }
}