using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSwitcher : MonoBehaviour
{
    // Reference to the SpriteRenderer component on the player
    private SpriteRenderer spriteRenderer;

    // Sprites from the atlas (idle sprite and active sprite)
    public Sprite idleSprite;   // Assign the first sprite (Idle) from the atlas here
    public Sprite activeSprite; // Assign the second sprite (when pressing space) from the atlas here
    private float animCooldown=0.0f;

    void Start()
    {
        // Get the SpriteRenderer component attached to the player
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the player's initial sprite to the idle sprite
        spriteRenderer.sprite = idleSprite;
    }

    void Update()
    {
        // Check if the Space key is being pressed
        if (gameObject.GetComponent<Player>().isAlive && Input.GetKey(KeyCode.Space)&&animCooldown<=5.0f)
        {
            // Change to the active sprite when space is pressed
            spriteRenderer.sprite = activeSprite;
            animCooldown+=0.01f;
        }
        else{
            
            // Change back to the idle sprite when space is released
            spriteRenderer.sprite = idleSprite;
        }

        // Check if the Space key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animCooldown=0.0f;
        }
    }
}
