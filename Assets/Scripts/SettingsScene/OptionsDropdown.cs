using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsDropdown : MonoBehaviour
{
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        Debug.Log(canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
