using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float colliderRadious;
    // Start is called before the first frame update
    void Start()
    {
        //gets the size of the collider of the ship
        colliderRadious = GetComponent<CircleCollider2D>().radius;
    }

    //makes the object wrap when leaving screen
    private void OnBecameInvisible()
    {
        Vector2 elementPosition = transform.position;
        if (transform.position.x - colliderRadious >= ScreenUtils.ScreenRight)
        {
            elementPosition.x = ScreenUtils.ScreenLeft;
        }
        else if (transform.position.x + colliderRadious <= ScreenUtils.ScreenLeft)
        {
            elementPosition.x = ScreenUtils.ScreenRight;
        }
        if (transform.position.y - colliderRadious >= ScreenUtils.ScreenTop)
        {
            elementPosition.y = ScreenUtils.ScreenBottom;
        }
        else if (transform.position.y + colliderRadious <= ScreenUtils.ScreenBottom)
        {
            elementPosition.y = ScreenUtils.ScreenTop;
        }
        transform.position = elementPosition;
    }
}
