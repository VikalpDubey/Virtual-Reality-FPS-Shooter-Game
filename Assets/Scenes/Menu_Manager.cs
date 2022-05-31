using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    
   public GameObject About;
   public GameObject mainMenucanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void ChangeScene()

    {
        About.SetActive(false);
        SceneManager.LoadScene(0);

    }
   

      public void Quitgame(){
        Application.Quit();

    }
    
    public void _Menu(){
        About.SetActive(false);
        mainMenucanvas.SetActive(true);
    }
}
