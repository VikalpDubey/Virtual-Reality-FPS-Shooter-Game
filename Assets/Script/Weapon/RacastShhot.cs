using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RacastShhot : MonoBehaviour
{
    public Camera Playercamera; 
    public float FireRate = 10f; 
    private float timeBetweenNextShot;
    public float Damage = 20f;
    public GameObject mudEffect; 
    public mouseLook mouse; 
    
    // this is ammo area 
    [Header("Ammo Management")]
    public int ammocount = 25; 
    public int availableammo = 100; 
    public int maxAmmo  = 25;
    public Animator anim ;
    public Text currentammotext; 
    public float vRecoil; 
    public float hRecoil; 

    public Animator aimAnim; 
    public bool aim; 

    void Update(){
        
        if(Input.GetButtonDown("Fire2")){
            aim  =! aim; 
        }
        if(aim==true){
            aimAnim.SetBool("Aim",true);
        }else{
            aimAnim.SetBool("Aim",false);
        }
        currentammotext.text= ammocount.ToString();
        if(Input.GetKeyDown(KeyCode.R) && ammocount <= maxAmmo){
            
            anim.SetBool("Reload",true);
            anim.SetBool("Shoot",false);
            mouse.AddRecoil(0 , 0);
        }
        if(ammocount <= 0){
            
            anim.SetBool("Reload",true);
            anim.SetBool("Shoot",false);
            mouse.AddRecoil(0 , 0);
            return;
        }
        if(Input.GetButton("Fire1")&& Time.time >= timeBetweenNextShot){
            timeBetweenNextShot = Time.time + 1f/FireRate;
            anim.SetBool("Shoot",true);
            float h = Random.Range(-hRecoil , hRecoil);
            mouse.AddRecoil(h ,vRecoil);
            weapon();
        }
        if(Input.GetButtonUp("Fire1")){
            anim.SetBool("Shoot",false);
            mouse.AddRecoil(0 , 0);
        }
        
    }
    void weapon(){
        ammocount--;
        RaycastHit hit;
        if(Physics.Raycast(Playercamera.transform.position , Playercamera.transform.forward,out hit )){
            Instantiate(mudEffect , hit.point, Quaternion.LookRotation(hit.normal));
            if(hit.transform.tag == "Enemy"){
                Health enemy = hit.transform.GetComponent<Health>();
                enemy.Damage(Damage);
            }
        }
    }
    public void Reload(){
        
        
        availableammo = availableammo - maxAmmo + ammocount;
        ammocount = maxAmmo; 
        anim.SetBool("Reload",false); 
    }
}
