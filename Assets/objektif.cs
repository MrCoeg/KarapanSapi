using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objektif : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
        StartCoroutine(sss());
    }

    IEnumerator sss()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        Destroy(this.gameObject, 0.1f);
    }
}
