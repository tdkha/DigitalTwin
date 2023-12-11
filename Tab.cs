using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : Task
{
    private int count_;

    public void Start()
    {
        count_ = 0; 
    }
    public Tab(string name, float ram = 0, float cpu = 0, float gpu = 0)
        : base(name, ram, cpu, gpu)
    {
        count_ = 0; // Initialize count to 1 for the first tab
    }

    public int GetCount()
    {
        return count_;
    }

    public void AddTab()
    {
        count_++;
        AdjustSpecs();
    }

    public void AdjustSpecs()
    {
        if(count_ > 0)
        {
            ramImpact_ += (ramImpact_ / count_);
            cpuImpact_ += (cpuImpact_ / count_);
            gpuImpact_ += (gpuImpact_ / count_);
        }
        
    }

    public void RemoveTab()
    {
        if (count_ == 1)
        {
            count_--;
            DecreaseSpecs();
        }
    }

    public void DecreaseSpecs()
    {
        if(count_ > 0)
        {
            ramImpact_ -= (ramImpact_ / count_);
            cpuImpact_ -= (cpuImpact_ / count_);
            gpuImpact_ -= (gpuImpact_ / count_);
        }
    }
}