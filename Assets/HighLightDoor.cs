using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseEnter()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        Debug.Log(gameObject.name);
    }
}
