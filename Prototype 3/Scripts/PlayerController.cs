using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private ParticleSystem explosionParticle;
    private ParticleSystem dirtParticle;
    public AudioClip jumpSound, crashSound;
    private AudioSource playerAudio;
    public float jumpForce = 1000;
    public float gravityModifier = 9.81f;
    public bool isOnGround = true;
    public bool gameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio= GetComponent<AudioSource>();
        ParticleSystem[] particlesSystem= GetComponentsInChildren<ParticleSystem>();
        dirtParticle = particlesSystem.Where(ps => ps.name == "FX_DirtSplatter").FirstOrDefault();
        explosionParticle = particlesSystem.Where(ps => ps.name == "FX_Explosion_Smoke").FirstOrDefault();
        playerAnim.SetTrigger("Static_b");
        playerAnim.SetFloat("Speed_f", 1.0f);
        playerAnim.speed = 2.5f;
        Physics.gravity *= gravityModifier;
        dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround && !gameOver)
        {   dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name) {
            case "Ground":
                if (!gameOver)
                {
                    isOnGround = true;
                    dirtParticle.Play();
                }
                break;
            case "RotateBarrel":
                gameOver = true;
                playerAnim.SetTrigger("Death_b");
                playerAnim.SetInteger("DeathType_int",1);
                playerAudio.PlayOneShot(crashSound, 1.0f); 
                dirtParticle.Stop();
                explosionParticle.Play();
                Destroy(collision.gameObject);
                Debug.Log("Game Over!");
                break;
        }
    }
}
