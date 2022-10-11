using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HelpMe : MonoBehaviour

{

    //Declare variables

    public float moveSpeed;

    void Update()
    {

        //Get input from the player

        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");



        //Move the player

        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);

    }
}