using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; 

public class PlayerHealth : MonoBehaviour
{
    private float reloadDelay = 2f;
    public int maxHealth = 5;
    public int currentHealth;
    private Animator animator;

    [SerializeField] public SpriteRenderer playerSr;
    [SerializeField] public PlayerMove playerMovement;
    private static int deathCount = 0; // Compte combien de fois le joueur est mort
    private const int maxDeathsBeforeGameOver = 3; // Nombre maximum avant GameOver

    void Awake()
    {
        currentHealth = maxHealth;

        // Charger la position du dernier checkpoint si disponible
        if (PlayerPrefs.GetInt("HasCheckpoint", 0) == 1)
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            float z = PlayerPrefs.GetFloat("CheckpointZ");

            transform.position = new Vector3(x, y, z);
            Debug.Log($"Position restaurée depuis checkpoint : {transform.position}");
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log($"Player prend {dmg} dégâts. HP restants = {currentHealth}");

        if (currentHealth <= 0)
        { 
            // playerSr.enabled = false;
            playerMovement.enabled = false;
            Die();
        }
    }

    void Die() { 
        Debug.Log("Player est mort !"); 
        animator = GetComponent<Animator>(); 
        GetComponent<PlayerMove>().enabled = false; 
        animator.SetTrigger("feu"); 
        deathCount++;
        StartCoroutine(WaitAndReloadScene());
         }

    IEnumerator WaitAndReloadScene()
    {
 
// Attendre le temps de l'animation avant d’agir
        yield return new WaitForSeconds(reloadDelay);

        // Si le joueur a dépassé le nombre max de morts → aller à GameOver
        if (deathCount >= maxDeathsBeforeGameOver)
        {
            Debug.Log("🛑 Trop de morts ! Chargement de la scène GameOver...");
            deathCount = 0; // Réinitialiser pour une nouvelle partie
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // Sinon, respawn à la dernière position sauvegardée
            Debug.Log("↩️ Respawn depuis le dernier checkpoint !");
            SceneManager.LoadScene("LevelOne");
        }

    }
}
