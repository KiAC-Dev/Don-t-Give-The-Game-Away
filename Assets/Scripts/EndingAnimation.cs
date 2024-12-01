using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndingAnimation : MonoBehaviour
{
    private float timer;
    
    [Header("Opening Animation Timers")]
    [SerializeField] private float fadeIn, duration, fadeOut;
    [SerializeField] private float gameCloseTimer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > gameCloseTimer)
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #endif

            Application.Quit();
        }
    }
}
