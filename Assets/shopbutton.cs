using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopbutton : MonoBehaviour
{
    public SceneLoader loader;
    public void Kembali()
    {
        StartCoroutine( loader.ChangeScene(2));
    }
}
