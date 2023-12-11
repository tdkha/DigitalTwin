using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    protected string name_;
    protected float ramImpact_;
    protected float cpuImpact_;
    protected float gpuImpact_;

    protected Task(string name, float ramImpact, float cpuImpact, float gpuImpact)
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

    public float GetRamImpact()
    {
        return ramImpact_;
    }

    public float GetCpuImpact()
    {
        return cpuImpact_;
    }

    public float GetGpuImpact()
    {
        return gpuImpact_;
    }
    public void SetName(string name)
    {
        this.name_ = name;
    }

    public void SetRamImpact(float ram)
    {
        this.ramImpact_ = ram;
    }

    public void SetCpuImpact(float cpu)
    {
        this.cpuImpact_ = cpu;
    }

    public void SetGpuImpact(float gpu)
    {
        this.gpuImpact_ = gpu;
    }
}