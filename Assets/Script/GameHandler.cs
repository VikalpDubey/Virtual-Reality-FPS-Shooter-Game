using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour
{
    public GameObject Enemies, DeathScene, WinScene;
    public GameObject theplayer;
    public void GameOver()
    {
        Enemies.SetActive(false);
        theplayer.SetActive(false);
        DeathScene.SetActive(true);
        Invoke("gameover", 14);

    }

    public void MissionAcomplished()
    {


    }
    void gameover(){
         SceneManager.LoadScene("MainMenu");
    }



    

    // Update is called once per frame
    void Update()
    {
        
    }
}
