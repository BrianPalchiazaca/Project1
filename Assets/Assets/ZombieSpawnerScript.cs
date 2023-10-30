using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Enemy;
    private float delay;

    public List<GameObject> Enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            Instantiate(Enemy, transform.position = new Vector3(10.5f, 0, 1), Quaternion.identity);
            delay = 5;

            //ZombieMovement.Speed = 2;
        }
    }
}

