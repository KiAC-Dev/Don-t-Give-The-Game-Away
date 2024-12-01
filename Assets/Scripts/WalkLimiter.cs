using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLimiter : MonoBehaviour
{
    private Collider2D boxCollider;
    public Vector2 bounds;

    private void Start()
    {
        if(boxCollider ==  null) boxCollider = GetComponent<Collider2D>();
        GetBounds();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().walkLimiter = this;
    }

    private void GetBounds()
    {
        float startingPosition = transform.position.x;
        bounds.x = startingPosition - boxCollider.bounds.extents.x;
        bounds.y = startingPosition + boxCollider.bounds.extents.x;
    }
}
