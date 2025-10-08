using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Sauvegarder la position du joueur
            Vector3 pos = other.transform.position;
            PlayerPrefs.SetFloat("CheckpointX", pos.x);
            PlayerPrefs.SetFloat("CheckpointY", pos.y);
            PlayerPrefs.SetFloat("CheckpointZ", pos.z);

            PlayerPrefs.SetInt("HasCheckpoint", 1); // Pour savoir s’il y a une sauvegarde
            PlayerPrefs.Save();

            Debug.Log($"Checkpoint sauvegardé à : {pos}");
        }
    }
}
