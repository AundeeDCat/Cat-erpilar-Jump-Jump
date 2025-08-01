using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Player_Controls : MonoBehaviour
{

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        X_Move();
        Jump();
        WallJump();
        Dash();
    }


    Rigidbody2D rb;
    float x_dir;
    float x_speed = 10;
    void X_Move()
    {
        if (Input.GetKey(KeyCode.A) && !isTouchLeft && !isDashing) x_dir = -1;
        else if (Input.GetKey(KeyCode.D) && !isTouchRight && !isDashing) x_dir = 1;

        else if (Input.GetKey(KeyCode.A) && isTouchLeft && !isDashing) x_dir = 0;
        else if (Input.GetKey(KeyCode.D) && isTouchRight && !isDashing) x_dir = 0;

        else if (!isDashing) x_dir = 0;

        rb.linearVelocityX = x_dir * x_speed;
    }

    float jump_height = 20f;
    public static bool isOnFloor;
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isOnFloor)
        {
            rb.linearVelocityY = jump_height;
            isOnFloor = false;

        }

        //Debug.Log(isOnFloor);
    }

    public static bool isTouchLeft;
    public static bool isTouchRight;
    void WallJump()
    {
        if (Input.GetKey(KeyCode.Space) && isTouchRight)
        {
            rb.linearVelocityY = jump_height;
            rb.linearVelocityX = -x_speed * 3;
            isTouchRight = false;
        }

        if (Input.GetKey(KeyCode.Space) && isTouchLeft)
        {
            rb.linearVelocityY = jump_height;
            rb.linearVelocityX = x_speed * 3;
            isTouchLeft = false;
        }
    }

    float dash_cooldown = 3;
    float dash_duration = 0.5f;
    bool dash_ready = true;
    bool isDashing = false;
    void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && dash_ready && rb.linearVelocityX!=0)
        {
            dash_ready = false;
            isDashing = true;

            rb.linearVelocityX = x_dir * x_speed * 10;

            StartCoroutine(DashCooldown(dash_cooldown));
            StartCoroutine(DashDuration(dash_duration));
        }
    }

    IEnumerator DashDuration(float wait)
    {
        yield return new WaitForSeconds(wait);
        isDashing = false;
    }

    IEnumerator DashCooldown(float wait)
    {
        yield return new WaitForSeconds(wait);
        dash_ready = true;
    }

}
