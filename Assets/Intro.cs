using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public Transition transition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) transition.UseTransition();
    }
}
