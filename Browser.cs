using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Browser : Task
{
    private List<Tab> openTabs;

    public Browser(string name, float ram, float cpu, float gpu)
        : base(name, ram, cpu, gpu) // Initialize non-string values to 0 for GoogleChrome instance
    {
        openTabs = new List<Tab>();
        UpdateSpecs();
    }

    public void Start()
    {
        openTabs = new List<Tab>();
        
    }
    public void Update()
    {
        UpdateSpecs();
    }

    public int GetNumTabs()
    {
        return openTabs.Count;
    }

    public void OpenTab(string tabName, float ram = 0, float cpu = 0, float gpu = 0)
    {
        if (!openTabs.Any(tab => tab.GetName() == tabName))
        {
            // Open the new tab
            openTabs.Add(new Tab(tabName, ram, cpu, gpu));
            Debug.Log($"Opened a new tab '{tabName}'. Total tabs: {GetNumTabs()}");
        }
        else
        {
            // Same name 
            Tab foundTab = openTabs.Find(tab => tab.GetName() == tabName);
            foundTab.AddTab();
            foundTab.AdjustSpecs();
            Debug.Log($"Added a tab '{tabName}'. Total tabs: {GetNumTabs()}");
        }
        // Update the specs based on all tabs
        UpdateSpecs();
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
            foundTab.AdjustSpecs();
            Debug.Log($"Added a tab '{tab.GetName()}'. Total tabs: {GetNumTabs()}");
        }
        // Update the specs based on all tabs
        UpdateSpecs();
    }

    public void CloseTab(string tabName)
    {
        var foundTab = openTabs.Find(tab => tab.GetName() == tabName);

        if (foundTab != null)
        {
            foundTab.RemoveTab();
            if (foundTab.GetCount() == 0)
            {
                openTabs.Remove(foundTab);
                Console.WriteLine($"Closed the last tab '{tabName}'. GoogleChrome instance deleted.");
            }
            else
            {
                Console.WriteLine($"Closed a tab '{tabName}'. Total tabs: {GetNumTabs()}");
            }
        }
        else
        {
            Console.WriteLine($"No tab found with the name '{tabName}'.");
        }
        // Update the specs based on all tabs
        UpdateSpecs();
    }

    public void CloseTab(Tab tab)
    {
        var foundTab = openTabs.Find(existingTab => existingTab.GetName() == tab.GetName());

        if (foundTab != null)
        {
            foundTab.RemoveTab();
            if (foundTab.GetCount() == 0)
            {
                openTabs.Remove(foundTab);
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
        // Update the specs based on all tabs
        UpdateSpecs();
    }

    private void UpdateSpecs()
    {
        float totalRam = 0, totalCpu = 0, totalGpu = 0;

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
    public new float GetRamImpact()
    {
        return GetNumTabs() > 0 ? base.GetRamImpact() : -1;
    }

    public new float GetCpuImpact()
    {
        return GetNumTabs() > 0 ? base.GetCpuImpact() : -1;
    }

    public new float GetGpuImpact()
    {
        return GetNumTabs() > 0 ? base.GetGpuImpact() : -1;
    }
}