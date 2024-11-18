using Spine.Unity;
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

    #region SetAnimation
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
    #endregion SetAnimation

    #region AddAnimation
    public void AddAnimation(int index, string state, bool loop)
    {
        if (skeletonAnimation.AnimationName == state) return;
        skeletonAnimation.AnimationState.AddAnimation(index, state, loop, 0);
    }

    public void AddAnimation(string state)
    {
        AddAnimation(0, state, true);
    }

    public void AddAnimation(int index, string state)
    {
        AddAnimation(index, state, true);
    }

    public void AddAnimation(string state, bool loop)
    {
        AddAnimation(0, state, loop);
    }
    #endregion AddAnimation

    #region RemoveAnimation
    public void RemoveAnimation(int index)
    {
        skeletonAnimation.AnimationState.SetEmptyAnimation(index, 0);
    }
    #endregion RemoveAnimation

    #region Blink
    float blinkTimer = 0;
    float blinkDelay;
    private void Blink()
    {
        if (blinkTimer > blinkDelay)
        {
            blinkTimer = 0;

            //Pick a random time between the set ranges for the next blink.
            blinkDelay = Random.Range(blinkTimeRange.x, blinkTimeRange.y);

            AddAnimation(1, "Blinking", false);
        }

        blinkTimer += Time.deltaTime;
    }
    #endregion Blink
}