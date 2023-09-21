using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyMovement : MonoBehaviour
{
    public Sapi stats;
    private SpriteRenderer spriteRenderer;
    public float m_speed;
    private float m_speedLimit;
    public bool isNitro;
    public float moveLineSpeed;

    public int line;
    private bool ableToUsenNitro;

    private bool transitioning;
    public Sprite[] taisprites;
    public Light2D light2d;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        m_speed = stats.speed;
        m_speedLimit = stats.speedLimit;
        moveLineSpeed = stats.moveLineSpeed;
    }

    private void Update()
    {
        if (m_speed < m_speedLimit)
        {
            m_speed += stats.acceleration * Time.deltaTime;

        }
        else
        {
            m_speed = m_speedLimit;
        }

        this.transform.localPosition += new Vector3(m_speed * Time.deltaTime, 0, 0);
    }

    public IEnumerator ManipulateSpeedLimit(float manipulationSpeed, float duration)
    {
        m_speedLimit += manipulationSpeed;


        yield return new WaitForSeconds(duration);

        m_speedLimit = stats.speedLimit;
    }

    public void manipulate(float manipulationSpeed, float duration)
    {
        StartCoroutine(ManipulateSpeedLimit(manipulationSpeed, duration));
        StartCoroutine(effectTai(duration));
    }


    IEnumerator StartUp()
    {

        var up = 0f;

        while (up < 2)
        {
            up += moveLineSpeed * Time.deltaTime;
            this.transform.localPosition += new Vector3(0, moveLineSpeed * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.01f);
        }
        spriteRenderer.sortingOrder = line + 1;
        transitioning = false;
        yield return null;
    }

    IEnumerator StartDown()
    {

        var up = 0f;

        while (up < 2)
        {
            up += moveLineSpeed * Time.deltaTime;
            this.transform.localPosition -= new Vector3(0, moveLineSpeed * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.01f);

        }
        spriteRenderer.sortingOrder = line + 1;
        transitioning = false;

        yield return null;
    }

    public void Up()
    {

        if (line < 0 || transitioning)
        {
            return;
        }

        transitioning = true;
        StartCoroutine(StartUp());
        line -= 1;
    }

    public void Down()
    {
        if (line > 2 || transitioning)
        {
            return;
        }
        transitioning = true;

        StartCoroutine(StartDown());

        line += 1;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (line >= 2)
            {
                Up();
            }

            if (line == 1)
            {
                var a = Random.Range(0, 10);
                if (a > 5)
                {
                    Up();
                }
                else
                {
                    Down();
                }
            }

            if (line <= 0)
            {
                Down();
            }
        }
    }

    public IEnumerator effectTai(float duration)
    {
        light2d.gameObject.SetActive(true);
        float time = 0;
        int counter = 0;
        while(time < duration)
        {
            
            time += 0.01f;
            counter %= taisprites.Length;
         
            light2d.lightCookieSprite = taisprites[counter];
            yield return new WaitForSeconds(0.01f);
            
        }
        light2d.gameObject.SetActive(false);

    }
}
