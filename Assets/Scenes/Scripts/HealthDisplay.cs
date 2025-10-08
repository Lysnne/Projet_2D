using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int Health;
    public int maxHealth ;

     public PlayerHealth playerHealth;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Image[] hearts;

   

     void Start()
    {
     
    }

     void Update()
    {

        Health= playerHealth.currentHealth;
        maxHealth= playerHealth.maxHealth;

       for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

          
        }

        
    }
}