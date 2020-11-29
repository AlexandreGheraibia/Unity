using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 10, -30);
        transform.Rotate(Vector3.up*90);
        transform.LookAt(plane.transform.position);
        transform.parent = plane.transform;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = plane.transform.position + offset;
    }
}
