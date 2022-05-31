using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {

   // this is ammo area 
    [Header("Ammo Management")]
    public int ammocount = 30; 
    public int availableammo = 500; 
    public int maxAmmo  = 30;
    public static int killed = 0;
  
    public Animator anim ;
    public Text currentammotext; 
     public Text totalammotext; 
      public Text zombiekilledtext; 
  
    public float Damage = 25f;

  //declare GameObjects and create isShooting boolean.
  private GameObject gun;
  private GameObject spawnPoint;
  private bool isShooting;

   public GameObject thePlayer;
   public GameObject Phase;
 public GameObject CutScene1;
  public GameObject Win;
  
 






  // Use this for initialization
  void Start () {

    

    //create references to gun and bullet spawnPoint objects
    gun = gameObject;
    spawnPoint = gameObject.transform.GetChild (0).gameObject;

    //set isShooting bool to default of false
    isShooting = false;
  }

  //Shoot function is IEnumerator so we can delay for seconds
  public IEnumerator Shoot() {
    ammocount--;
    
    //set is shooting to true so we can't shoot continuosly
    isShooting = true;
    //instantiate the bullet
    GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
    //Get the bullet's rigid body component and set its position and rotation equal to that of the spawnPoint
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    bullet.transform.rotation = spawnPoint.transform.rotation;
    bullet.transform.position = spawnPoint.transform.position;
    //add force to the bullet in the direction of the spawnPoint's forward vector
    rb.AddForce(spawnPoint.transform.forward * 500f);
    //play the gun shot sound and gun animation
    GetComponent<AudioSource>().Play ();
    anim.SetBool("shoot",true);
    
    //destroy the bullet after 1 second
    Destroy (bullet, 1);
    
    //wait for 1 second and set isShooting to false so we can shoot again
    yield return new WaitForSeconds (0.1f);
    isShooting = false;
     
  }
  

  // Update is called once per frame
  void Update () {
  
    //declare a new RayCastHit
    RaycastHit hit;
    //draw the ray for debuging purposes (will only show up in scene view)
    Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green, 25);

    // totalammotext.text= "/"+ availableammo.ToString();
    currentammotext.text= ammocount.ToString() ;
    zombiekilledtext.text= killed.ToString();
    
        
        if(ammocount <= 0){
            
            anim.SetBool("Reload",true);
            anim.SetBool("shoot",false);
            return;
        }
        if(killed >= 44){
          



          Phase.SetActive (true);
            CutScene1.SetActive (true);
            thePlayer.SetActive (false);
            
            StartCoroutine(FinishCut());

          
          
        }
        
      

        


    LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, spawnPoint.transform.position);
        lineRenderer.SetPosition(1, spawnPoint.transform.position + spawnPoint.transform.forward * 20);
    

    //cast a ray from the spawnpoint in the direction of its forward vector
    if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 30)){

      //if the raycast hits any game object where its name contains "zombie" and we aren't already shooting we will start the shooting coroutine
      if (hit.collider.name.Contains("zombie")) 
      {
        if (!isShooting) {
          StartCoroutine ("Shoot");
          anim.SetBool("shoot",true);
          zombieScript enemy = hit.transform.GetComponent<zombieScript>();
                enemy.Damage(Damage);

            
          
        }
      

      }
      
        
    }
      
  }

  public void StopShoot(){
    StopCoroutine ("Shoot");

  }
   public void Reload(){
        
        
        availableammo = availableammo - maxAmmo + ammocount;
        ammocount = maxAmmo; 
        anim.SetBool("Reload",false); 
    }

    public void Gunshoot(){
        
        anim.SetBool("shoot",false); 
    }

//     public void WinGame(){

//            Phase.SetActive (true);
//             CutScene1.SetActive (true);
//             thePlayer.SetActive (false);
            
//             StartCoroutine(FinishCut());
// }

 IEnumerator FinishCut(){
       yield return new WaitForSeconds(6);
       thePlayer.SetActive(true);
       CutScene1.SetActive(false);
       Destroy(CutScene1);
       
       Win.SetActive(true);
   }

    
}