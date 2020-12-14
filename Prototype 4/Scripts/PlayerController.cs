using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5, powerupStrength=15;
    private Rigidbody playerRB;
    public bool hasPowerup=false;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupIndicator = GameObject.Find("Powerup Indicator");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput=Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward*verticalInput*speed);
        powerupIndicator.transform.position=transform.position+new Vector3(0,-0.42f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            //starts a thread out the main loop for countdown
            //the powerup existing time
            powerupIndicator.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {
            GameObject enemy = collision.gameObject;
            Debug.Log("Player collided with " + collision.gameObject + " with powerup set to" + hasPowerup);
            Rigidbody enemyRB = enemy.GetComponent<Rigidbody>();
            enemyRB.AddForce(getDirectionAwayFromPlayer(enemy) * powerupStrength,ForceMode.Impulse);
        }
    }
    private Vector3 getDirectionAwayFromPlayer(GameObject enemy)
    {
       return (enemy.transform.position - transform.position).normalized;
    }
    IEnumerator PowerupCountdownRoutine() {
        //wait 7 seconds
        yield return new WaitForSeconds(7);
        //switch hasPowerup to false
        hasPowerup = false;
        powerupIndicator.GetComponent<MeshRenderer>().enabled = false;
    }
}
