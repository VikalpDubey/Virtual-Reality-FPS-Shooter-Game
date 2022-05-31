using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour
{
    public GameObject Area, Effect;
    public GameObject triggeringEntity;
    public float healingPoints= 30f;



    void Update() 
    {

           
    }
    
    private void OnTriggerEnter(Collider other) {
         
         
              
             triggeringEntity.GetComponent<PlayerHealth>().Heal();
             GetComponent<AudioSource>().Play ();

           Destroy(Area, 2);
           Destroy(Effect, 2);     

         
         

    }
}
