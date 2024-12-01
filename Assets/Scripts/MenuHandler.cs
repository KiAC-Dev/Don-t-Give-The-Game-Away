using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        if (playerControls == null) playerControls = GetComponent<PlayerControls>();
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (playerControls.inputActions.Gameplay.Pause.triggered)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
