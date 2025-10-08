using UnityEngine;
 using UnityEngine.SceneManagement;
using System.Collections; 
public class PlayerHealth : MonoBehaviour
{
    private float reloadDelay = 2f;
    public int maxHealth = 5;
    public int currentHealth;
   // public string sceneToLoad="Level2";
    private Animator animator;
    [SerializeField] public SpriteRenderer playerSr;
    [SerializeField] public PlayerMove playerMovement;


    void Awake() => currentHealth = maxHealth;
 
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log("Player prend " + dmg + " dégâts. HP restants = " + currentHealth);
        if (currentHealth <= 0)
         { 
            playerSr.enabled = false;
            playerMovement.enabled = false;
            Die();
           
          };
    }
 
    void Die()
    {
        Debug.Log("Player est mort !");
        animator = GetComponent<Animator>();
        GetComponent<PlayerMove>().enabled = false;
        animator.SetTrigger("feu");
        StartCoroutine(WaitAndReloadScene());
        // Ici : désactiver le joueur, lancer une animation, recharger la scène, etc.
    
    //   if (reloadDelay <= 0f) SceneManager.LoadScene(sceneToLoad);
    //     else StartCoroutine(CoDelay(sceneToLoad, reloadDelay));
    
    }
    //      IEnumerator CoDelay(string name, float seconds)
    // {
    //     yield return new WaitForSecondsRealtime(seconds);
    //     SceneManager.LoadScene(name);
    // }
    IEnumerator WaitAndReloadScene()
    {
         SceneManager.LoadScene("GameOver");
        // Attente de reloadDelay secondes avant de recharger la scène
        yield return new WaitForSeconds(reloadDelay);
 
        // Rechargement de la scène actuelle
        Scene activeScene = SceneManager.GetActiveScene();
       
         SceneManager.LoadScene("LevelOne");
    }
}