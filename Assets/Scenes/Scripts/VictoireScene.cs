using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VictoireScene : MonoBehaviour
{
    private Button button;
    private string sceneToLoad = "Victoire";

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClipVictoire);
    }

    private void TaskOnClipVictoire()
    {
        // Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(sceneToLoad);
    }
}
 