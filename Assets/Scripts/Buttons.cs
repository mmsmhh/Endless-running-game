using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{

    public void ChangeCamera()
    {
        Player.ChangeCamera();
    }
    public void ToggleSound()
    {
        SoundManager.ToggleSound();
    }
    public void PlayGame()
    {     
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Pause()
    {
        Player.InversePause();
    }
}
