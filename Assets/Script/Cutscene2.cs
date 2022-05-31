using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2 : MonoBehaviour
{
   public GameObject thePlayer;
   public GameObject Phase;
 public GameObject CutScene1;

   void OnTriggerEnter(Collider collider) {
        
            Phase.SetActive (true);
            CutScene1.SetActive (true);
            thePlayer.SetActive (false);
            
            StartCoroutine(FinishCut());

        
   } 
   IEnumerator FinishCut(){
       yield return new WaitForSeconds(6);
       thePlayer.SetActive(true);
       CutScene1.SetActive(false);
        Destroy(gameObject, 1);
   }
}
