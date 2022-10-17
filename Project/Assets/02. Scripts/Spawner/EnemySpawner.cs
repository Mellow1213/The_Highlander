using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefabs, transform.position + SetPos(), Quaternion.identity);
        Instantiate(enemyPrefabs, transform.position + SetPos(), Quaternion.identity);
        Instantiate(enemyPrefabs, transform.position+SetPos(), Quaternion.identity);
        Destroy(transform.gameObject, 3.0f);
    }

    Vector3 SetPos()
    {
        Vector3 pos = new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f));
        return pos;

    }
}
