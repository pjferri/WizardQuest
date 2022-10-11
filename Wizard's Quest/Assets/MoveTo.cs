using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float stoppingDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //the step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;
            //move enemy toward player
            if (Vector3.Distance(transform.position, target.position) > stoppingDistance){
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
    }
    }
