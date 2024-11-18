using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private Vector2 blinkTimeRange;

    private void Start()
    {
        if(skeletonAnimation == null)
            skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    private void Update()
    {
        Blink();
    }

    public void SetAnimation(int index, string state, bool loop)
    {
        if (skeletonAnimation.AnimationName == state) return;
        skeletonAnimation.AnimationState.SetAnimation(index, state, loop);
    }

    public void SetAnimation(string state)
    {
        SetAnimation(0, state, true);
    }

    public void SetAnimation(int index, string state)
    {
        SetAnimation(index, state, true);
    }

    public void SetAnimation(string state, bool loop)
    {
        SetAnimation(0, state, loop);
    }

    [SerializeField] float blinkTimer = 0;
    [SerializeField] float blinkDelay;
    private void Blink()
    {
        if (blinkTimer > blinkDelay)
        {
            blinkTimer = 0;

            //Pick a random time between the set ranges for the next blink.
            blinkDelay = Random.Range(blinkTimeRange.x, blinkTimeRange.y);

            skeletonAnimation.state.AddAnimation(1, "Blinking", false, 0);
        }

        blinkTimer += Time.deltaTime;
    }
}
