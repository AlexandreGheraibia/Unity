using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public int pointValue;
    private const float torqueRange= 10,
                        minForce=12,
                        maxForce=20,
                        xRange = 4,
                        yspawn = -6;
   
    private Rigidbody targetRB;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomUpForceInit(), ForceMode.Impulse);
        transform.position = RandomPositionInit();
        targetRB.AddTorque(RandomTorqueInit());
    }
    Vector3 RandomTorqueInit()
    {
        return new Vector3(Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange));
    }

    Vector3 RandomPositionInit()
    {
       return new Vector3(Random.Range(-xRange, xRange), yspawn);
    }
    Vector3 RandomUpForceInit()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
