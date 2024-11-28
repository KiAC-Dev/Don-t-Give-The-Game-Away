using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private ItemTracker itemTracker;
    [SerializeField] private AnimationHandler animationHandler;
    private PlayerInput inputActions;
    public int targetDoor;
    private bool pickupPressed, transitionPressed, pickupToggle, transitionToggle = false;


    private void Start()
    {
        if(inventory == null) inventory = GetComponent<Inventory>();
        if(playerControls == null) playerControls = GetComponent<PlayerControls>();
        if(animationHandler == null) animationHandler = GetComponent<AnimationHandler>();
        inputActions = new PlayerInput();
        inputActions.Gameplay.Enable();
    }

    private void Update()
    {
        if (inputActions.Gameplay.Pickup.triggered) { pickupPressed = true; pickupToggle = true; }
        if (inputActions.Gameplay.UseTransition.triggered) { transitionPressed = true; transitionToggle = true; }
    }

    private void FixedUpdate()
    {
        if(!pickupToggle) pickupPressed = false;
        if(!transitionToggle) transitionPressed = false;

        pickupToggle = false;
        transitionToggle = false;

        if (pickupPressed && inventory.isHoldingItem)
        {
            GameObject itemObject = inventory.heldItem.gameObject;

            inventory.heldItem = null;
            inventory.isHoldingItem = false;
            itemObject.transform.parent = null;
            SceneManager.MoveGameObjectToScene(itemObject, SceneManager.GetActiveScene());
            itemObject.transform.position = new Vector3(transform.position.x, -3.429f, 0f);
            itemObject.SetActive(true);
            itemTracker.AddItem(itemObject);
            animationHandler.SetSkin("default");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        switch (collider.tag)
        {
            case "Item":
                Pickup(collider, collider.GetComponent<Item>());
                break;

            case "Transition":
                Transition(collider.GetComponent<Transition>());
                break;

            default: break;
        }
    }

    private void Transition(Transition transition)
    {
        if (transitionPressed)
        {
            targetDoor = transition.UseTransition();
        } 
        
    }

    private void Pickup(GameObject itemObject, Item item)
    {
        if (pickupPressed && !inventory.isHoldingItem)
        {
            itemTracker.RemoveItem(itemObject);
            inventory.heldItem = item;
            inventory.isHoldingItem = true;
            itemObject.transform.parent = transform;
            itemObject.transform.localPosition = new Vector3(0.26f, 3.05f, 0f);
            itemObject.SetActive(false);
            animationHandler.SetSkin("KK_Present_1");
        }
    }
}
