using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public CurrentPlayerProperties properties;
    private Sapi stats;

    private float m_speed;
    private float m_speedLimit;
    private bool isNitro;


    private Button nitro;
    private void Awake()
    {
        stats = properties.currentSapi;

        m_speed = stats.speed;
        m_speedLimit = stats.speedLimit;

        nitro = GameObject.Find("Nitro Button").GetComponent<Button>();
        nitro.onClick.AddListener(Nitro);
    }

    private void Update()
    {


        if (m_speed < m_speedLimit)
        {
            m_speed += stats.acceleration * Time.deltaTime;
        }


        this.transform.localPosition += new Vector3(m_speed * Time.deltaTime, 0, 0);
    }

    public IEnumerator ManipulateSpeedLimit(float manipulationSpeed, float duration)
    {
        m_speedLimit += manipulationSpeed;


        yield return new WaitForSeconds(duration);

        m_speedLimit = stats.speedLimit;
    }

    

    public void Nitro()
    {
        if (!isNitro)
        {
            m_speedLimit += stats.nitroSpeed;

        }
        else
        {
            m_speedLimit = stats.speedLimit;

        }
    }
}
