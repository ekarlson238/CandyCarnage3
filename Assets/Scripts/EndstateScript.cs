using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndstateScript : MonoBehaviour
{
    ///This script determines the end state of the game. If the boss creature is destroyed, it activates the game over panel.


    [SerializeField]
    [Tooltip("Place the endstate panel here.")]
    private GameObject endPanel;

    [SerializeField]
    [Tooltip("Place the health canvas here.")]
    private GameObject healthPanel;

    [SerializeField]
    [Tooltip("Place the boss enemy here.")]
    private GameObject bossEnemy;

    [SerializeField]
    [Tooltip("Type the name of the scene you want to reload here.")]
    private string sceneToLoad;

    [SerializeField]
    [Tooltip("Type the name of the menu scene you want to load here.")]
    private string mainMenuScene;

    [SerializeField]
    [Tooltip("Place the player object here.")]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
    }

    private void Update()
    {
        if (bossEnemy == null)
        {
            endPanel.SetActive(true);
            healthPanel.SetActive(false);

            Time.timeScale = 0;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

}
