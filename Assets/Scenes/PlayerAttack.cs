using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip sfxAttack;       // Son d’attaque
    private AudioSource audioSource;

    private Animator animator;
    
    

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");          // déclenche animation
            if (sfxAttack != null)
                audioSource.PlayOneShot(sfxAttack); // joue le son
        }
    }
}
