using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [Tooltip("Place the main menu canvas here.")]
    [SerializeField]
    private Canvas menuCanvas;

    [Tooltip("Place the main menu panel here.")]
    [SerializeField]
    private GameObject menuPanel;

    [Tooltip("Place the credits panel here.")]
    [SerializeField]
    private GameObject creditPanel;

    [Tooltip("Type the scene you want loaded here.")]
    [SerializeField]
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        creditPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CreditPanel()
    {
        creditPanel.SetActive(true);

        menuPanel.SetActive(false);
    }

    public void MenuPanel()
    {
        creditPanel.SetActive(false);

        menuPanel.SetActive(true);
    }

}
