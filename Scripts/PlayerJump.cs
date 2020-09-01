 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public Material floor;
    public Material witch;
    public Material wandering_trader;
    public AudioSource audioSource;
    public ParticleSystem playerParticleSystem;
    bool isJump = false;
    public void OnButtonClick()
    {
        if (isJump==false)
        {
            rigidbody.velocity += new Vector3(0, 5, 0);
            rigidbody.AddForce(Vector3.up * Effect.JumpUp);
            isJump = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Jump") 
            { 
                isJump = false;
            }
        }
        switch (collision.gameObject.tag)
        {
            case "Floor":
                {
                    PlayerParticlePlay(floor);
                    return;
                }
            case "Wandering_trader":
                {
                    PlayerParticlePlay(wandering_trader);
                    return;
                }
            case "Witch":
                {
                    PlayerParticlePlay(witch);
                    return;
                }
        }
    }
    void PlayerParticlePlay(Material material) 
    {
        playerParticleSystem.gameObject.GetComponent<ParticleSystemRenderer>().material = material;
        isJump = false;
        playerParticleSystem.Stop();
        playerParticleSystem.Play();
        audioSource.Play();
    }
}
