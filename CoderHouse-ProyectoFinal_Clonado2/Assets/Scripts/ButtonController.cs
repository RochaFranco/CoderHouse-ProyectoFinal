using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    
}
