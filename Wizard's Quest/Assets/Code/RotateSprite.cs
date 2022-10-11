using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public float rotateSpeed;

    //Rotate the player
    void FixedUpdate() {
        rotatePlayer();
    }

    private void rotatePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            transform.position.x - mousePosition.x,
            transform.position.y - mousePosition.y
        );

        if (direction.x != 0)
        {
            transform.up = direction;
        }        
    }
}
