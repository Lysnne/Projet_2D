using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameOverScene : MonoBehaviour
{
    private Button button;
    private string sceneToLoad = "GameOver";

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
 