using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        movePlayer();
    }

    private void movePlayer()
    {
        Vector3 mousePosition = Input.mousePosition; //Get the mouse position and save it
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //Covert the mouse position from screenspace to world space

        Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);
        //copied is above

        if (Input.GetAxis("Vertical") > 0) //The value moves between -1 and +1 depending on which button is pressed. Up is positive, Down is negative, Zero is no movement
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }

        //Do the opposite down here with another if
        if (Input.GetAxis("Vertical") < 0) //The value moves between -1 and +1 depending on which button is pressed. Up is positive, Down is negative, Zero is no movement
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
    }

    private void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition; //Get the mouse position and save it
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //Covert the mouse position from screenspace to world space

        Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y); //The reason "new Vector 2" is here is because we are defining the x, y and z ourselves 
        //had to subtract mouseposition from transform as opposed to the other way around, since that made the characters backside aim to the mouse
        transform.up = direction;
    }
}
