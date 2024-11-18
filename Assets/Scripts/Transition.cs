using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string targetScene;
    private PlayerInput inputActions;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && inputActions.Gameplay.UseTransition.phase == InputActionPhase.Started) SceneManager.LoadScene(targetScene);
    }

    public void UseTransition()
    {
        try
        {
            SceneManager.LoadScene(targetScene);
        }

        catch (NullReferenceException) 
        { 
            throw new NullReferenceException(targetScene + " is not a valid scene name!");
        }
    }
}