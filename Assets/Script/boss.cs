using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss : MonoBehaviour
{
     private Transform goal;
  private UnityEngine.AI.NavMeshAgent agent;
  

  public Animator Bossanim;
  
   public float health = 300f;
     
     float time;
     float timeDelay;


    public void Damage(float amount){
        health -= amount;
    }

    public void Roar(){
      
      GetComponent<AudioSource>().Play ();
    }
 
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeDelay = 8f;
    }
     private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")){
        Bossanim.SetBool("attack",true);

    }else{
      Bossanim.SetBool("attack",false);

    }
     }


    // Update is called once per frame
    void Update()
    {
        goal = Camera.main.transform;
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //set the navmesh agent's desination equal to the main camera's position (our first person character)
    agent.destination = goal.position;


    time = time + 1f * Time.deltaTime;
    if(time >= timeDelay) {
        time = 0f;
        Roar();
    }
      if(health<= 0f){
            Death();
           
    }
    

     void Death()
    {

        
     Bossanim.SetBool("dead",true);
    //destroy this zombie in three seconds.
    Destroy (gameObject, 3);

    }
    
    
    
    
   
    }
}
