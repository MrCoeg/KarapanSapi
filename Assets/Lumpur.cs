using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumpur : MonoBehaviour
{

    private bool doingEffect;
    private float time;
    public AudioSource lumpur;
   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Character")
        {

                var movement = collision.gameObject.GetComponent<CharacterMovement>();
                var speed = movement.m_speed - (movement.m_speed * 0.7f);
                StartCoroutine(movement.ManipulateSpeedLimit(-speed, 2));

            lumpur.Play();
        }
        else
        {

                var movement = collision.gameObject.GetComponent<EnemyMovement>();
                var speed = movement.m_speed - (movement.m_speed * 0.7f);
                StartCoroutine(movement.ManipulateSpeedLimit(-speed, 2));
            
        }
    }
}
