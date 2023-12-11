using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models; // custom namespace


public class GameController : MonoBehaviour
{

    public TaskManager taskManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //taskManager.DisplaySpecs();
    }

    void OnAddTask( Task task )
    {
        taskManager.AddTask(task);
    }

    void OnDeleteTask(Task task)
    {
        taskManager.RemoveTask(task);
    }

    void OnBrowserAddTab(Browser browser)
    {
        //browser.OpenTab();
    }

    void OnBrowserCloseTab(Browser browser)
    {
        //browser.CloseTab();
    }
    
}
