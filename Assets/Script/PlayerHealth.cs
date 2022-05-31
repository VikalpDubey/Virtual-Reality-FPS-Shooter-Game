using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    // public float damagePoints = 10f;
    // float healingPoints = 30;
    float healingPoints= 30f;
    float damagePoints;
    

    public float health= 100f;
    float maxHealth = 100f;
    float lerpSpeed;
    // public GameObject Area, Effect;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text =  health + "%";
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
        if(health <= 0){
        FindObjectOfType<GameHandler>().GameOver();
        }

        

    
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
        healthText.color = healthColor;
        
    }
    
    public void PlayerDamage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }
    public void Heal()
    {
        if (health < maxHealth)
            health += healingPoints;
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);
    }
    private void OnTriggerEnter(Collider other) {
    if (other.tag == "enemy"){
        damagePoints = other.GetComponent<zombieScript>().damagePoints;
        PlayerDamage(damagePoints);
        if (health > 0)
            health -= damagePoints;
             GetComponent<AudioSource>().Play ();

        
    }
  
     
   
        
        

    

}
}
    
        
        

       
    


    

