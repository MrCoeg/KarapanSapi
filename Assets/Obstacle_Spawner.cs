using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public Collider2D collider2d;
    public GameObject[] obstaclePrefab;
    public int count;
    public int line;
    private void Awake()
    {
        var min = collider2d.bounds.min;
        var max = collider2d.bounds.max;
        var pos = new Vector3();
        for (int i = 0; i < count; i++)
        {
            pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);

            var instantiated = Instantiate(obstaclePrefab[Random.Range(0,obstaclePrefab.Length-1)], pos, Quaternion.identity, this.transform);
            instantiated.GetComponent<SpriteRenderer>().sortingOrder = line;
            instantiated.tag = "Obstacle";
        }
    }
}
