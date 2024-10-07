using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D player;
    public int velocity = 5;
    public float rotationSpeed = 1.5f;
    public bool isAlive = true;

    public LogicScript logic;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        AudioManager.instance.PlayMusic("Music");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            AudioManager.instance.PlaySound("Jump");
            player.velocity = Vector2.up * velocity ;
        }
        transform.rotation = Quaternion.Euler(0,0,GetComponent<Rigidbody2D>().velocity.y*rotationSpeed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isAlive){
            logic.GameOver();
            isAlive = false;
            AudioManager.instance.PlaySound("Death");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAlive && collision.CompareTag("death")){
            logic.GameOver();
            isAlive = false;
            AudioManager.instance.PlaySound("Death");
        }
    }
}
