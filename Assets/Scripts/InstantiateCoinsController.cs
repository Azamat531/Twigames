using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoinsController : MonoBehaviour
{
    [SerializeField] float spawnTime=2f;
    private float timer;
    [SerializeField] GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnCoins();
            timer = spawnTime;
        }
    }
    void SpawnCoins()
    {
        int posX = Random.Range(-120, 121);
        int posZ = Random.Range(-50, 101);
        Instantiate(coin, new Vector3(posX, 150, posZ),new Quaternion(90f,90f,0f,0f));
    }
}
