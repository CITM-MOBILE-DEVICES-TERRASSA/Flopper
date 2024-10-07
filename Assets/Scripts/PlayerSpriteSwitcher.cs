using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSwitcher : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;

    
    public Sprite idleSprite;
    public Sprite activeSprite;
    private float animCooldown=0.0f;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        spriteRenderer.sprite = idleSprite;
    }

    void Update()
    {
        
        if (gameObject.GetComponent<Player>().isAlive && Input.GetKey(KeyCode.Space)&&animCooldown<=5.0f)
        {
            
            spriteRenderer.sprite = activeSprite;
            animCooldown+=0.01f;
        }
        else{
            
            
            spriteRenderer.sprite = idleSprite;
        }

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animCooldown=0.0f;
        }
    }
}
