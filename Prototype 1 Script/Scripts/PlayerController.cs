using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed,turnSpeed;
    private float coeffY, fowardInput, brake=-1.5f;
    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = 60f;
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        coeffY = Input.GetAxis("Horizontal") * turnSpeed;
        fowardInput = Input.GetAxis("Vertical");
       
        if (fowardInput > 0.0f)
        {
            if (speed+ fowardInput > 50){
                speed = 50;
            }
            else {
                speed += fowardInput;
            }
        }
        else {
            if (fowardInput != 0.0f)
            {
                if (speed + brake > 0.0f)
                    speed += brake;
                else
                {
                    speed += fowardInput;
                }
            }
           
        }
    	
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime* coeffY);
    }
}
