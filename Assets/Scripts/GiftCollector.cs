using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollector : MonoBehaviour
{
    public UIHandler uiHandler;
    public int presentsCollected {  get; private set; }

    private void Start()
    {
        if(uiHandler == null) uiHandler = Camera.main.GetComponent<UIHandler>();
    }

    public void AddPresent()
    {
        presentsCollected++;
        uiHandler.AddPresent();
    }

    public void RemovePresent()
    {
        //Debug.Log("Present removal attempted...");
        if (presentsCollected > 0)
        {
            presentsCollected--;
            uiHandler.RemovePresent();
        }
        else throw new System.Exception("There are zero presents in the attic and you are trying to remove one.");
    }
}
