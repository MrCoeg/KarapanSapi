using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{
    public CurrentPlayerProperties properties;
    private SpriteRenderer spriteRenderer;
    private Sapi stats;

    public Transform nitroEffect;
    private Image nitroImage;

    public float m_speed;
    private float m_speedLimit;
    public bool isNitro;
    public float moveLineSpeed;

    private int line = 1;


    private bool transitioning;

    private Button nitro;
    private Button upButton;
    private Button downButton;

    public CinemachineVirtualCamera cameraCinemachine;

    private void Awake()
    {
        stats = properties.currentSapi;

        m_speed = stats.speed;
        m_speedLimit = stats.speedLimit;
        moveLineSpeed = stats.moveLineSpeed;

        nitroEffect = GameObject.Find("Lighting base").GetComponent<Transform>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        nitro = GameObject.Find("Nitro Button").GetComponent<Button>();
        upButton = GameObject.Find("Button Up").GetComponent<Button>();
        downButton = GameObject.Find("Button Down").GetComponent<Button>();
        nitroImage = nitro.GetComponent<Image>();

        nitro.onClick.AddListener(Nitro);
        upButton.onClick.AddListener(Up);
        downButton.onClick.AddListener(Down);
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

        if (isNitro)
        {
            nitroImage.fillAmount -= 0.02f * Time.deltaTime;
            if (nitroImage.fillAmount <= 0)
            {

            }
        }
        else
        {
            nitroImage.fillAmount += 0.04f * Time.deltaTime;
        }

        this.transform.localPosition += new Vector3(m_speed * Time.deltaTime, 0, 0);
    }


    public IEnumerator ManipulateSpeedLimit(float manipulationSpeed, float duration)
    {
        m_speedLimit += manipulationSpeed;


        yield return new WaitForSeconds(duration);

        m_speedLimit = stats.speedLimit;
    }

    IEnumerator StartUp()
    {

        var up = 0f;

        while(up < 2)
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
        spriteRenderer.sortingOrder = line+1;
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
            nitroEffect.localScale = new Vector3(100,0.8f,1);
            m_speedLimit += stats.nitroSpeed;
            isNitro = true;
        }
        else
        {
            nitroEffect.localScale = new Vector3(100, 1, 1);

            m_speedLimit = stats.speedLimit;
            isNitro = false;
        }
    }
}
