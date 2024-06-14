using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    [SerializeField] GameObject SomePrefab;
    [SerializeField] Vector3 SomePosition;


    // Start is called before the first frame update
    void Start()
   
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateSomePrefab()
    {
        
        {
            
            Instantiate(SomePrefab, SomePosition,  transform.rotation);
            Destroy(this.gameObject);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            print("проверка связи");
            Invoke("CreateSomePrefab", 1);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

        }
    }
}
