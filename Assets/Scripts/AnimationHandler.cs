using Spine;
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
    public TrackEntry AddAnimation(int index, string state, bool loop, float delay)
    {
        return skeletonAnimation.state.AddAnimation(index, state, loop, delay);
    }
    #endregion AddAnimation

    #region RemoveAnimation
    public void RemoveAnimation(int index)
    {
        skeletonAnimation.AnimationState.SetEmptyAnimation(index, 0);
    }
    #endregion RemoveAnimation

    #region SetSkin
    public void SetSkin(string skin)
    {
        skeletonAnimation.skeleton.SetSkin(skin);
    }
    #endregion SetSkin

    private void Blink()
    {
        AddAnimation(1, "Blinking", false, 3);
    }
}