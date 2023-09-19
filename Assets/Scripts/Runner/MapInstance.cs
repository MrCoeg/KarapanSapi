using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstance : MonoBehaviour
{
    public int selected;
    public SceneLoader sceneChanger;

    public void Play()
    {
        StartCoroutine( sceneChanger.ChangeSceneAnimation(selected));
    }


}
