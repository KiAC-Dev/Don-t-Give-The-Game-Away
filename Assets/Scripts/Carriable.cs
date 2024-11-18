using UnityEngine;

public class Carriable : MonoBehaviour
{
    public bool isCarried;
    private bool buttonPressed;

    private Rigidbody2D rb;
    private PlayerInput inputActions;
    [SerializeField] private AnimationHandler animationHandler;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (inputActions.Gameplay.Pickup.triggered)
        {
            buttonPressed = true;
        }
        if (buttonPressed && isCarried)
        {
            buttonPressed = false;
            isCarried = false;
            transform.parent = null;
            transform.position = new Vector3(transform.position.x, -3.429f, 0f);
            animationHandler.RemoveAnimation(2);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && buttonPressed && !isCarried)
        {
            buttonPressed = false;
            isCarried = true;
            transform.parent = collision.transform;
            transform.localPosition = new Vector3(0.26f, 3.05f, 0f);

            if (animationHandler == null) animationHandler = collision.GetComponent<AnimationHandler>();
            animationHandler.AddAnimation(2, "holding-present", true);
        }
    }
}
