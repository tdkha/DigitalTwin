using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tab : Task
{
    private int count_;
    public void Start()
    {
        count_ = 1; 
    }
    public Tab(string name, int ram = 0, int cpu = 0, int gpu = 0)
        : base(name, ram, cpu, gpu)
    {
    }

    public int GetCount()
    {
        return count_;
    }

    public void AddTab()
    {
        
        AdjustSpecs();
        count_++;
    }

    public void AdjustSpecs()
    {
            ramImpact_ += (ramImpact_ / count_);
            cpuImpact_ += (cpuImpact_ / count_);
            gpuImpact_ += (gpuImpact_ / count_);

        
    }

    public void RemoveTab()
    {
        if (count_ > 0)
        {
            DecreaseSpecs();
            if(cpuImpact_==0 || gpuImpact_==0 || ramImpact_ == 0)
            {
                count_ = 0;
                return;
            }
            count_--;
        }
    }

    public void DecreaseSpecs()
    {
        if (count_ > 0)
        {
            // Calculate averages based on the remaining count
            ramImpact_ -= (ramImpact_ / count_);
            cpuImpact_ -= (cpuImpact_ / count_);
            gpuImpact_ -= (gpuImpact_ / count_);
        }
    }
}