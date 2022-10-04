using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
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
