using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public Button playButton;

    private bool hasShownPanel = false;

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        if (!hasShownPanel)
        {
            mainMenuPanel.SetActive(true);
            hasShownPanel = true;
        }
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
    }
}
