using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LaunchScenne : MonoBehaviour
{
    private Button button;
    private string sceneToLoad = "LevelOne";

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClip);
    }

    private void TaskOnClip()
    {
        // Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(sceneToLoad);
    }
}
 