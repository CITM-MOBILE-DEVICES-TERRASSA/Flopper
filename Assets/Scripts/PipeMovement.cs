using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movSpeed = 5.0f;
    public float deadzone = -20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * movSpeed) * Time.deltaTime;
        if (transform.position.x <= deadzone)
        {
            Destroy(gameObject);
        }
    }
}
