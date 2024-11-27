using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    public List<Transition> transitions;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject door = transitions[player.GetComponent<CollisionHandler>().targetDoor].gameObject;
        player.transform.position = new Vector3(door.transform.position.x, player.transform.position.y, player.transform.position.z);

        GameObject.Find("ItemTracker").GetComponent<ItemTracker>().LoadItems();
    }
}
