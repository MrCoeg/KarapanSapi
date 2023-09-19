using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simplemove : MonoBehaviour
{
    public Transform character;
    private Vector3 a;
    public float speed;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            a = character.localPosition;
            character.localPosition = new Vector3(a.x + (speed * Time.deltaTime), a.y, a.z);
            image.fillAmount += 0.0001f;
        }
    }
}
