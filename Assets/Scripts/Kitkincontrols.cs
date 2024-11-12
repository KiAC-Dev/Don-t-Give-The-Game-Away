using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Kitkincontrols : MonoBehaviour
{

    public float speed = 0.8f;
    public SkeletonAnimation SkeletonAnimation;

    // Start is called before the first frame update
    void Start()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.position -= transform.right * step;
            transform.localScale = new Vector3(-0.5012f, 0.5012f, 0.5012f);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * step;
            transform.localScale = new Vector3(0.5012f, 0.5012f, 0.5012f);
        }
        else
        {
            _ = GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "Walk", true); }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _ = GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "Walk", true);
        }
    }
}
