using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed = 1.5f;

    [Header("Refereces")]
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private Inventory inventory;
    private PlayerInput inputActions;

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
        Movement();

        if (inventory.isHoldingItem)
            animationHandler.AddAnimation(2, "holding-present", true, 0);
        else animationHandler.RemoveAnimation(2);
    }

    private void Movement()
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
