using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    protected string name_;
    protected int ramImpact_;
    protected int cpuImpact_;
    protected int gpuImpact_;

    protected Task(string name, int ramImpact, int cpuImpact, int gpuImpact)
    {
        this.name_ = name;
        this.ramImpact_ = ramImpact;
        this.cpuImpact_ = cpuImpact;
        this.gpuImpact_ = gpuImpact;
    }

    public string GetName()
    {
        return name_;
    }

    public int GetRamImpact()
    {
        return ramImpact_;
    }

    public int GetCpuImpact()
    {
        return cpuImpact_;
    }

    public int GetGpuImpact()
    {
        return gpuImpact_;
    }
    public void SetName(string name)
    {
        this.name_ = name;
    }

    public void SetRamImpact(int ram)
    {
        this.ramImpact_ = ram;
    }

    public void SetCpuImpact(int cpu)
    {
        this.cpuImpact_ = cpu;
    }

    public void SetGpuImpact(int gpu)
    {
        this.gpuImpact_ = gpu;
    }
}