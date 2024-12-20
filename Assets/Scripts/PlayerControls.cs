using System.Net.Sockets;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed = 1.5f;

    [Header("Refereces")]
    public WalkLimiter walkLimiter;
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private Inventory inventory;
    public PlayerInput inputActions;

    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
        DontDestroyOnLoad(gameObject);

        if(inventory == null) inventory = GetComponent<Inventory>();

        if(GameObject.FindGameObjectsWithTag("Player").Length > 1) Destroy(gameObject);
    }

    private void Update()
    {
        if(Time.timeScale > 0)
        {
            Movement();
        }

        if (inventory.isHoldingItem)
            animationHandler.AddAnimation(2, "holding-present", true, 0);
        else animationHandler.RemoveAnimation(2);
    }

    private void Movement()
    {
        float step = speed * Time.deltaTime;
        float walkInput = inputActions.Gameplay.Walk.ReadValue<float>();

        if (walkInput < 0 && transform.position.x > walkLimiter.bounds.x)
        {

            transform.position -= transform.right * step;
            transform.localScale = new Vector3(-0.5012f, 0.5012f, 0.5012f);

            animationHandler.SetAnimation("Walk");
        }
        if (walkInput > 0 && transform.position.x < walkLimiter.bounds.y)
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
