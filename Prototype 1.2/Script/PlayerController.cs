using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class PlayerController : MonoBehaviour
{
    private const float wheelPerimeter=(2*0.15f*Mathf.PI),
                        turnSpeed = 45f;
    private TextMeshProUGUI speedText, rpmText;
    [SerializeField] private float horsePower = 0;
    public GameObject centerOfMass;
    private  Rigidbody playerRB;
    private float coeffY, fowardInput, speed;
    private List<WheelCollider> wheelColliders;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.centerOfMass = centerOfMass.transform.position;
        speedText = GameObject.Find("Speedometer").GetComponent<TextMeshProUGUI>();
        rpmText = GameObject.Find("RPM").GetComponent<TextMeshProUGUI>();
        wheelColliders = GetComponentsInChildren<WheelCollider>().ToList();
    }
   
    // Update is called once per frame
    //appelé avant Update, sert pour gérer tout ce qui est mouvement
    //ou événement physique.
    void FixedUpdate()
    {
        if (IsOnGround())
        {
            coeffY = Input.GetAxis("Horizontal") * turnSpeed;
            fowardInput = Input.GetAxis("Vertical");
            playerRB.AddRelativeForce(Vector3.forward * horsePower * fowardInput, ForceMode.Force);
            transform.Rotate(Vector3.up * Time.deltaTime * coeffY);
            speed = playerRB.velocity.magnitude;
            speedText.text = "Speed: " + Mathf.Round(speed * 3.6f) + "km/H";
            rpmText.text = "RPM  " + Mathf.Round(speed * 60 / wheelPerimeter) + "T/M";
        }
      
    }

    bool IsOnGround()
    {
        return wheelColliders.Where(wheel => wheel.isGrounded).Count()==4;
    }
}
