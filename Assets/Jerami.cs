using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerami : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            var movement = collision.gameObject.GetComponent<CharacterMovement>();

            if (movement.isNitro)
            {
                var playerProperties = Resources.Load<PlayerProperties>("Player Properties");
                playerProperties.money += Random.Range(2, 10);
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine( movement.ManipulateSpeedLimit(movement.m_speed, 1));
            }
        }
        else
        {
            var movement = collision.gameObject.GetComponent<EnemyMovement>();

            if (movement.isNitro)
            {
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(movement.ManipulateSpeedLimit(movement.m_speed, 1));
            }
        }
    }
}
