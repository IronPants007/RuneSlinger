using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public void RetryGame ()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame ()
    {
        SceneManager.LoadScene("GameQuit");
    }
}
