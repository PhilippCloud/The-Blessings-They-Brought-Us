using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startscreen : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }        
    }
}
