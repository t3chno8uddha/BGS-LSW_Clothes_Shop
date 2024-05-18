using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviewScreen : MonoBehaviour
{
    public int gameplayScene;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(gameplayScene);
        }
    }
}