using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class PlayerMove: MonoBehaviour
{
    [Header("Audio")]
    // Clip audio à jouer quand le joueur saute (assigné dans l’Inspector)
    [SerializeField] private AudioClip sfxJump;
    
    // Composant AudioSource qui jouera les sons
    private AudioSource audioSource;
    // Valeur d’entrée horizontale (−1 = gauche, 0 = immobile, 1 = droite)
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 3f; // Vitesse horizontale
    [SerializeField] private float jumpForce = 7f;
    private float x;
    // Composant pour gérer l’affichage du sprite (retourner à gauche/droite)
    private SpriteRenderer spriteRenderer;
    // Composant pour gérer les animations du joueur
    private Animator animator;
    // Composant physique pour gérer les forces (notamment le saut)
    private Rigidbody2D rb;
    // Indique si le joueur doit sauter à la prochaine frame physique
    private bool jump = false;

    void Awake()
    {
        // Récupère les composants nécessaires attachés au GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        // Méthode appelée au lancement, vide ici mais disponible pour init
    }
    // Update est appelé une fois par frame (logique liée aux entrées joueur)
    void Update()
    {
        // ---- Déplacement horizontal ----
        x = Input.GetAxisRaw("Horizontal"); // récupère l’input clavier/flèches
        animator.SetFloat("x", Mathf.Abs(x)); // anime la marche selon vitesse
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * x); // déplace le joueur
        // ---- Orientation du sprite ----
        if (x > 0f) { spriteRenderer.flipX = false; } // regarde à droite
        if (x < 0f) { spriteRenderer.flipX = true; }  // regarde à gauche
        // ---- Gestion du saut ----
        // Ancienne version commentée (force directe au moment de l’appui)
        // if (Input.GetKeyDown(KeyCode.UpArrow)) { rb.AddForce(Vector2.up * 900f); }
        // Nouvelle version : déclenche un "flag" de saut
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true; // signal qu’il faut sauter dans FixedUpdate
            audioSource.PlayOneShot(sfxJump); // joue le son du saut
        }
        
    }
    // FixedUpdate est appelé à chaque frame physique (idéal pour Rigidbody)
    private void FixedUpdate()
    {
        // Déplacement horizontal répété ici (⚠ doublon avec Update)
        transform.Translate(Vector2.right * jumpForce * Time.deltaTime * x);
        // ---- Saut ----
        if (jump) // si le flag est actif
        {
            jump = false; // réinitialise pour éviter des sauts infinis
            audioSource.PlayOneShot(sfxJump); // rejoue le son du saut (⚠ doublon aussi)
            rb.AddForce(Vector2.up * 500f); // applique une force vers le haut
        }
    }
}
