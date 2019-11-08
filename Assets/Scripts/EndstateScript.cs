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
    private Enemy bossEnemy;
    
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

        Time.timeScale = 1;
    }

    /// <summary>
    /// opens the end UI when the boss is killed
    /// </summary>
    private void Update()
    {
        if (bossEnemy == null)
        {
            endPanel.SetActive(true);
            healthPanel.SetActive(false);

            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Restart the active scene
    /// </summary>
    public void Retry()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// load whatever scene is set as mainMenuScene
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(mainMenuScene);
    }

}
