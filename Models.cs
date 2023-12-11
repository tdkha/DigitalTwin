using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Models
{
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
        public void SetName( string name)
        {
            this.name_ = name;
        }

        public void  SetRamImpact( float ram )
        {
            this.ramImpact_ = ram;
        }

        public void SetCpuImpact(float cpu)
        {
            this.cpuImpact_ = cpu;
        }

        public void SetGpuImpact( float gpu)
        {
            this.gpuImpact_= gpu;
        }
    }
    public class Tab : Task
    {
        private int count_;

        public Tab(string name, float ram = 0, float cpu = 0, float gpu = 0)
            : base(name, ram, cpu, gpu)
        {
            count_ = 1; // Initialize count to 1 for the first tab
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
            ramImpact_ += (ramImpact_ / count_);
            cpuImpact_ += (cpuImpact_ / count_);
            gpuImpact_ += (gpuImpact_ / count_);
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
            ramImpact_ -= (ramImpact_ / count_);
            cpuImpact_ -= (cpuImpact_ / count_);
            gpuImpact_ -= (gpuImpact_ / count_);
        }
    }
    public class Browser : Task
    {
        

        private List<Tab> openTabs;

        public Browser(string name)
            : base(name, 0, 0, 0) // Initialize non-string values to 0 for GoogleChrome instance
        {
            openTabs = new List<Tab>();
            openTabs.Add(new Tab("Google")); 
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
                openTabs.Add(new Tab(tabName, ram , cpu, gpu));
                Console.WriteLine($"Opened a new tab '{tabName}'. Total tabs: {GetNumTabs()}");
            }
            else
            {
                // Same name 
                Tab foundTab = openTabs.Find(tab => tab.GetName() == tabName);
                foundTab.AddTab();
                foundTab.AdjustSpecs();
                Console.WriteLine($"Added a tab '{tabName}'. Total tabs: {GetNumTabs()}");
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
                Console.WriteLine($"Opened a new tab '{tab.GetName()}'. Total tabs: {GetNumTabs()}");
            }
            else
            {
                // Same name 
                Tab foundTab = openTabs.Find(existingTab => existingTab.GetName() == tab.GetName());
                foundTab.AddTab();
                foundTab.AdjustSpecs();
                Console.WriteLine($"Added a tab '{tab.GetName()}'. Total tabs: {GetNumTabs()}");
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

    public class Game : Task
    {
        public Game(string name, float ram, float cpu, float gpu )
               : base(name, ram, cpu, gpu)
        {
            
        }
    }
    public class TaskManager : MonoBehaviour
    {
        private List<Task> tasks_;
        private float cpuPerformance_;
        private float gpuPerformance_;
        private float ramUsage_;


        public void Update()
        {
            List<Browser> chromeInstances = tasks_.OfType<Browser>().Where(chrome => chrome.GetNumTabs() == 0).ToList();

            foreach (var chromeInstance in chromeInstances)
            {
                tasks_.Remove(chromeInstance);
            }

            foreach(Task task in tasks_)
            {
                cpuPerformance_ += task.GetCpuImpact();
                gpuPerformance_ += task.GetGpuImpact();
                ramUsage_ += task.GetRamImpact();
            }
        }
        public TaskManager()
        {
            tasks_ = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks_.Add(task);
        }

        public void RemoveTask(Task task)
        {
            tasks_.Remove(task);
            Console.WriteLine($"Removed task '{task.GetName()}'.");
        }

        public void DisplayTasks()
        {
            Console.WriteLine("Current tasks:");
            foreach (var task in tasks_)
            {
                Console.WriteLine($"Name: {task.GetName()}, RAM Impact: {task.GetRamImpact()}, CPU Impact: {task.GetCpuImpact()}, GPU Impact: {task.GetGpuImpact()}");
            }
        }
    }
}
