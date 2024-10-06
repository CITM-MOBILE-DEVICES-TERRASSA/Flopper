using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public int spawnrate = 2;
    private float timer = 0;
    public float highOffstet = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
        
    }

    void SpawnPipe()
    {
        float lowestpoint = transform.position.y - highOffstet*5;
        float highestpoint = transform.position.y + highOffstet;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }
}
