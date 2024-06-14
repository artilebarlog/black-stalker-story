using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class drobitel : weapon
{
    

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1f;
        auto = false;
        ammoCurrent = 6;
        ammoMax = 6;
        ammoBackPack = 32;
        
    }

    // Update is called once per frame
    protected override void OnShoot()
    {
        
        
        
        
        RaycastHit hit;
        for (int bulletcounter = 20; bulletcounter > 0; bulletcounter -- )
        {
            Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Vector3 drift = new Vector3(UnityEngine.Random.Range(-75, 75), UnityEngine.Random.Range(-75, 75), UnityEngine.Random.Range(-75, 75));
            Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition + drift);

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.tag == "enemy")
                {
                    //hit.collider.GetComponent<Enemy>().ChangeHealth(10); 
                }
                GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
                Destroy(gameBullet, 1);
            }
        }
    }

}
