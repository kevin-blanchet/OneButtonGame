using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else
            {
                StartGame();
            }
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
