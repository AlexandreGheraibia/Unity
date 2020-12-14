using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody EnemyRB;
    private GameObject player;
    private float speed=5;
    private float destructionDepth = -10f;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        EnemyRB.AddForce(lookDirection*speed);
        if (transform.position.y < destructionDepth)
        {
            Destroy(gameObject);
        }
    }
}
