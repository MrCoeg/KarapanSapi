using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class MapTracker : MonoBehaviour
{
    public List<GameObject> sapi = new List<GameObject>();
    public Transform finishLine;

    public Image progressBar;
    public TextMeshProUGUI textHastag;
    public CinemachineVirtualCamera camerastop;

    public Image winPallete;

    public GameObject[] toHide;
    public GameObject toShow;

    private bool alreadyWin;
    private void Start()
    {
        sapi.Add(GameObject.FindGameObjectWithTag("Character"));
        var enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemy.Length; i++)
        {
            sapi.Add(enemy[i]);
        }
    }

    private void Update()
    {
        int counter = 1;
        var dist = finishLine.position.x - sapi[0].transform.position.x;

        for (int i = 1; i < sapi.Count; i++)
        {
            if (dist > finishLine.position.x - sapi[i].transform.position.x)
            {
                counter += 1;
            }
        }

        textHastag.text = "#" + counter.ToString();
        progressBar.fillAmount = 1-(dist / finishLine.position.x);

        if (dist < 0 && !alreadyWin)
        {
            alreadyWin = true;
            camerastop.Follow = null;
            winPallete.gameObject.SetActive(true);
            StartCoroutine( Win());
        }
    }

    IEnumerator Win()
    {
        var loader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();

        yield return new WaitForSeconds(2);
        StartCoroutine( loader.callAnimation(toShow));
        for (int i = 0; i < toHide.Length; i++)
        {
            toHide[i].SetActive(false);
        }
    }

}
