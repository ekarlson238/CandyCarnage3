using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    [Tooltip("Place the Pause panel here.")]
    [SerializeField]
    private GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }


    private void Update()
    {
        PauseGame();
    }


    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.Escape) && pausePanel.activeSelf == false)
        {

            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
            Time.timeScale = 1;

            pausePanel.SetActive(false);
    }

}
