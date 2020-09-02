using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject audioManager;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndGameButton()
    {
        SceneManager.LoadScene("StartMenu");
        if (audioManager != null)
        {
            Destroy(audioManager);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
