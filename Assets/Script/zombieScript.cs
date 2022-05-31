using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;


public class zombieScript : MonoBehaviour {
  //declare the transform of our goal (where the navmesh agent will move towards) and our navmesh agent (in this case our zombie)
  private Transform goal;
  private UnityEngine.AI.NavMeshAgent agent;
  

  public Animator Zombieanim;
  public float damagePoints = 10;
  
  bool death = false;
  
   public float health = 100f;
   
    float time;
     float timeDelay;
     


    public void Damage(float amount){
        health -= amount;
    }
    public void PlayerDamage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }
    
     public void Roar(){
      
      GetComponent<AudioSource>().Play ();
    }

  // Use this for initialization
  void Start () {
   time = 0f;
        timeDelay = 10f;
  }
  void Update () {
    //create references
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
        if (death == false)
        {
          death = true;
           Death();
        }
        
           
          

        }


  }

    
  public void Death()
    { playerScript.killed++;
    this.GetComponent<CapsuleCollider>().enabled = false;
    
    
      agent.destination = gameObject.transform.position;

     Zombieanim.SetBool("attack",false);
     Zombieanim.SetBool("dead",true);
     
    //destroy this zombie in 2 seconds.
    Destroy (gameObject, 1);
    
      
    
   

    }
  
 private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")){
        Zombieanim.SetBool("attack",true);
        
    }

    
     
    
    
    
    
 }


 
  
 


 }

