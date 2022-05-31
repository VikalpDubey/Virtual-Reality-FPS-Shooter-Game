using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float sensitivity; 
    public Transform player; 
    private float rot;
    private float v;
    private float h; 
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
        void Update(){
        float x = Input.GetAxis("Mouse X")*sensitivity *Time.deltaTime +v;
        float y = Input.GetAxis("Mouse Y")*sensitivity * Time.deltaTime +h;

        rot -=y;
        rot = Mathf.Clamp(rot , -90f , 90f);
        transform.localRotation = Quaternion.Euler(rot , 0f , 0f);
        player.Rotate(player.up*x);
        

    }
    public void AddRecoil(float V , float H){
        v = V;
        h = H; 
    }
    
}
