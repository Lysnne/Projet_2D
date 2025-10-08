using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{
    [Header("Cible à suivre")]
    public Transform target;      // La cible à suivre (ex. le joueur) → à glisser/déposer dans l’Inspector
 
    [Header("Décalage")]
    public Vector3 offset = new Vector3(0, 0, -10); // Décalage entre la caméra et la cible (Z = -10 en 2D pour voir la scène)
 
    [Header("Lissage")]
    public float smoothSpeed = 5f; // Vitesse de lissage du mouvement de la caméra (valeur élevée = caméra réactive, valeur faible = caméra plus fluide/retardée)
 
    // LateUpdate est appelé après Update → garantit que la caméra suit le joueur après qu’il ait bougé
    void LateUpdate()
    {
        // Si aucune cible n’est définie, ne rien faire
        if (target == null) return;
 
        // Calcul de la position désirée de la caméra (cible + décalage)
        Vector3 desiredPosition = target.position + offset;
 
        // Interpolation entre la position actuelle de la caméra et la position désirée
        // Lerp = interpolation linéaire → crée un effet de mouvement fluide
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
 
        // Mise à jour de la position de la caméra avec la valeur interpolée
        transform.position = smoothed;
    }
 
}