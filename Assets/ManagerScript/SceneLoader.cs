using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public Sprite[] loadingSprites;
    public Sprite[] cowboySprites;
 
    public GameObject loadingParent;
    public GameObject cowboy;
    public GameObject loadingBar;
    private Image loadingImage;
    private Image cowboyImage;
    public GameObject toInstantiatedAudio;
    public AudioSource audioToPlay;
    private bool doneChangeScene;

    private void Awake()
    {
        if (loadingParent != null)
        {
            loadingImage = loadingParent.GetComponent<Image>();
            audioToPlay = Instantiate(toInstantiatedAudio).GetComponent<AudioSource>();

        }
    }

    private void Start()
    {

    }

    #region Method

    public IEnumerator ChangeScene(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        doneChangeScene = true;
    }

    private IEnumerator cowboyAnimation()
    {
        int counter = 0;
        int length = cowboySprites.Length;
        while (!doneChangeScene)
        {
            cowboyImage.sprite = cowboySprites[counter++];
            counter %= length;

            yield return new WaitForSeconds(0.03f);
        }
    }

    public IEnumerator ChangeSceneAnimation(int sceneIndex)
    {
        Transform parent = GameObject.FindGameObjectWithTag("Canvas").transform;
        GameObject instantiated = Instantiate(loadingParent, parent, false);
        loadingImage = instantiated.GetComponent<Image>();

        for (int i = 0; i < loadingSprites.Length; i++)
        {
            loadingImage.sprite = loadingSprites[i];

            yield return new WaitForSeconds(0.03f);
        }
        cowboyImage = Instantiate(cowboy, parent, false).GetComponent<Image>();
        var instantiatedLoadingBar = Instantiate(loadingBar, parent, false).GetComponentsInChildren<Image>()[1];
        audioToPlay.Play();
        StartCoroutine(cowboyAnimation());

        for (int i = 0; i < 100; i++)
        {
            instantiatedLoadingBar.fillAmount += (1.0f/ 100);
            yield return new WaitForSeconds(0.03f);
        }

        // Start Sound

        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(ChangeScene(sceneIndex));
    }

    public IEnumerator callAnimation(GameObject toShow)
    {
        Transform parent = GameObject.FindGameObjectWithTag("Canvas").transform;
        GameObject instantiated = Instantiate(loadingParent, parent, false);
        loadingImage = instantiated.GetComponent<Image>();

        for (int i = 0; i < loadingSprites.Length; i++)
        {
            loadingImage.sprite = loadingSprites[i];

            yield return new WaitForSeconds(0.03f);
        }
        var cowboyInstantiated = Instantiate(cowboy, parent, false);
        cowboyImage = cowboyInstantiated.GetComponent<Image>();

        var instantiatedLoadingBara = Instantiate(loadingBar, parent, false);
        var instantiatedLoadingBar = instantiatedLoadingBara.GetComponentsInChildren<Image>()[1];
        StartCoroutine(cowboyAnimation());

        for (int i = 0; i < 100; i++)
        {
            instantiatedLoadingBar.fillAmount += (1.0f / 100);
            yield return new WaitForSeconds(0.03f);
        }

        // Start Sound

        yield return new WaitForSecondsRealtime(2f);
        instantiated.SetActive(false);
        cowboyInstantiated.SetActive(false);
        instantiatedLoadingBara.gameObject.SetActive(false);
        toShow.SetActive(true);
    }

    
    #endregion
}
