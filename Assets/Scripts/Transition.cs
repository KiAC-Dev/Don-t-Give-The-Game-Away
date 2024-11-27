using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int targetDoor;
    public string targetScene;

    public int UseTransition()
    {
        try
        {
            SceneManager.LoadScene(targetScene);
        }

        catch (NullReferenceException) 
        { 
            throw new NullReferenceException(targetScene + " is not a valid scene name!");
        }
        return targetDoor;
    }
}