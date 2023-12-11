using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
public class TabWindow : MonoBehaviour
{
    private Task task_;
    private List<Models.Tab> tabs_;
    int tabCount_;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAddTab()
    {
        tabCount_++;
        string id = "Tab" + tabCount_;
        
    }
}
