using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public SceneLoader loader;
    private void Start()
    {
        StartCoroutine(loader.ChangeSceneAnimation(1));
    }
}
