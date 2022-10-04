using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HelpMe : MonoBehaviour

{

    //Declare variables

    public float moveSpeed;

    public float rotateSpeed;



    void Update()
    {

        //Get input from the player

        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");



        //Move the player

        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);



        //Rotate the player

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;


        /*
        //Rotate the player based on input from the right thumbstick on the controller
        float rotHorizontalInput = Input.GetAxis("RotHorizontal");
        float rotVerticalInput = Input.GetAxis("RotVertical");

        Vector3 rotDirection = new Vector3(
            rotHorizontalInput,
            rotVerticalInput,
            0
        );

        transform.rotation = Quaternion.LookRotation(rotDirection);

        */
       
        float rotHorizontalInput = Input.GetAxis("RotHorizontal");
        float rotVerticalInput = Input.GetAxis("RotVertical");

        Vector2 rotDirection = new Vector2(
            rotHorizontalInput,
            rotVerticalInput
        );

        transform.up = rotDirection;

    }
}