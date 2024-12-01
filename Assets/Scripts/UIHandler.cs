using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    #region UI Elements
    public Image[] presents = new Image[5];
    public Sprite presentCollected, presentEmpty;
    #endregion UI Elements

    private int presentsCollected;

    private void Start()
    {
        foreach (Image present in presents)
        {
            present.sprite = presentEmpty;
        }
    }

    public void AddPresent()
    {
        presents[presentsCollected].sprite = presentCollected;
        presentsCollected++;
    }

    public void RemovePresent()
    {
        presentsCollected--;
        presents[presentsCollected].sprite = presentEmpty;
    }
}
