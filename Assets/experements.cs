using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class experements : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check that the colliding object is the player object
        if (other.gameObject.tag == "Player")
        {
            
        }
            // Start is called before the first frame update
    }

            void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
