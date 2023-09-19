using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nitroui : MonoBehaviour
{
    public Image nitro;
    public bool isUsed;

    private void Awake()
    {
        nitro = gameObject.GetComponent<Image>();

    }

    private void Update()
    {
        if (nitro.fillAmount < 1 && !isUsed)
        {
            Refill();
        }

        if (isUsed)
        {
            nitro.fillAmount -= 0.01f;
        }
    }

    void Refill()
    {
        nitro.fillAmount += 0.01f;
    }

    public void Use()
    {
        isUsed = !isUsed;
    }
}
