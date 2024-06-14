using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(tag == "Zona")
        {
            GetComponent<Animator>().SetBool("rotate", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
