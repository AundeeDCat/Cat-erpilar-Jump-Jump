using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class Player_Controller : MonoBehaviour
{

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player_collider = this.GetComponent<CapsuleCollider2D>();
    }

    
    public static bool isDead = false;
    void Update()
    {
        if (!isDead)
        {
            X_Move();
            Jump();
            Dash();
            Crawl();
        }
    
    }



    Rigidbody2D rb;
    float x_dir;
    float x_speed = 10;
    
    void X_Move()
    {
        if (Input.GetKey(KeyCode.A)) x_dir = -1;
        else if (Input.GetKey(KeyCode.D)) x_dir = 1;
        else x_dir = 0;

        rb.linearVelocityX = x_dir * x_speed * dash_multiplier * crawl_multiplier;
    }



    float jump_height = 20f;
    public static bool isOnFloor;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            rb.linearVelocityY = jump_height;
            isOnFloor = false;

        }
    }



    float dash_cooldown = 1;
    float dash_duration = 0.05f;
    bool dash_ready = true;
    bool isDashing = false;
    float dash_multiplier = 1;
    void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && dash_ready && rb.linearVelocityX != 0)
        {
            dash_ready = false;
            isDashing = true;
            dash_multiplier = 10;

            StartCoroutine(DashCooldown(dash_cooldown));
            StartCoroutine(DashDuration(dash_duration));
        }
    }

    IEnumerator DashDuration(float wait)
    {
        yield return new WaitForSeconds(wait);
        dash_multiplier = 1;
        isDashing = false;
    }

    IEnumerator DashCooldown(float wait)
    {
        yield return new WaitForSeconds(wait);
        dash_ready = true;
    }


    float crawl_multiplier = 1;
    CapsuleCollider2D player_collider;
    public static bool isTouchCeiling = false;
    void Crawl()
    {
        if (Input.GetKey(KeyCode.S))
        {
            crawl_multiplier = 0.5f;
            player_collider.size = new Vector2(player_collider.size.x, 1);
        }

        else if (Input.GetKeyUp(KeyCode.S) && !isTouchCeiling)
        {
            crawl_multiplier = 1;
            player_collider.size = new Vector2(player_collider.size.x, 2);
        }

        else if (!isTouchCeiling)
        {
            crawl_multiplier = 1;
            player_collider.size = new Vector2(player_collider.size.x, 2);
        }
    }


    


    public static void Death()
    {
        isDead = true;
        Debug.Log("DEATH SCREEN");
    }
}
