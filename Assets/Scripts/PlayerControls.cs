using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerControls : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed = 1.5f;

    [Header("Refereces")]
    [SerializeField] private AnimationHandler animationHandler;
    private PlayerInput inputActions;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        float walkInput = inputActions.Gameplay.Walk.ReadValue<float>();

        if (walkInput < 0)
        {

            transform.position -= transform.right * step;
            transform.localScale = new Vector3(-0.5012f, 0.5012f, 0.5012f);

            animationHandler.SetAnimation("Walk");
        }
        if (walkInput > 0)
        {
            transform.position += transform.right * step;
            transform.localScale = new Vector3(0.5012f, 0.5012f, 0.5012f);

            animationHandler.SetAnimation("Walk");
        }
        if (walkInput == 0)
        {
            animationHandler.SetAnimation("idle");
        }
    }
}
