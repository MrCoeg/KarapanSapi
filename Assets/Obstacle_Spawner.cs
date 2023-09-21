using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public Collider2D collider2d;
    public GameObject[] obstaclePrefab;
    public int count;
    public int line;

    public GameObject lumpur;
    public GameObject jerami;
    private void Awake()
    {
        var lumpursfx = Instantiate(lumpur);
        var jeramisfx =Instantiate(jerami);
        var min = collider2d.bounds.min;
        var max = collider2d.bounds.max;
        var pos = new Vector3();
        for (int i = 0; i < count; i++)
        {
            pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
            var index = Random.Range(0, obstaclePrefab.Length);
            if (index == 0)
            {
                var instantiated = Instantiate(obstaclePrefab[index], pos, Quaternion.identity, this.transform);

                instantiated.GetComponent<Lumpur>().lumpur = lumpursfx.GetComponent<AudioSource>();
                instantiated.GetComponent<SpriteRenderer>().sortingOrder = line;
                instantiated.tag = "Obstacle";
            }
            else
            {
                var instantiated = Instantiate(obstaclePrefab[index], pos, Quaternion.identity, this.transform);
                instantiated.GetComponent<Jerami>().jerami = jeramisfx.GetComponent<AudioSource>();

                instantiated.GetComponent<SpriteRenderer>().sortingOrder = line;
                instantiated.tag = "Obstacle";
            }

        }
    }
}
