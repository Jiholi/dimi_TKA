using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{

    [SerializeField] float speed = 10; // 플레이어 이동 속도
    [SerializeField] float jumpingPower = 10; // 플레이어 점프 힘
    [SerializeField] float friction = 6f; // 플레이어 마찰력
    [SerializeField] float maxSpeed = 10; // 플레이어 최대 속력

    public LayerMask groundLayer; // 바닥 레이어
    public Transform groundCheck; // 바닥 체크 위치

    private bool canJump = true; // 점프 가능 여부
    public bool isGround = false; // 플레이어가 바닥에 있는지 여부
    public float lastRotation = 1; // 플레이어가 바라보고 있는 방향.
    
    Transform tr;
    Collider2D col;
    Rigidbody2D rb; // 플레이어의 Rigidbody2D 컴포넌트
    Collider2D footC; // 발 충돌체
    

    void Awake()
    {
        Application.targetFrameRate = 120;
    }

    void Start()
    {
        tr = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        footC = groundCheck.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D footC)
    {
        isGround = true;
    }


    void Update()
    {

        
        float horizontalInput = Input.GetAxis("Horizontal"); // 수평 입력 값
        Vector2 moveDirection = new Vector2(horizontalInput, 0); // 이동 방향 벡터

        if (horizontalInput != 0)
        {
            if (horizontalInput > 0) { lastRotation = 1; }
            else { lastRotation = -1; }
        }

        // 플레이어에게 가해지는 마찰력을 계산합니다.
        Vector2 frictionForce = new Vector2(-rb.velocity.x * friction, 0);
        rb.AddForce(frictionForce, ForceMode2D.Force);

        // 플레이어에게 이동 힘을 가합니다.
        rb.AddForce(moveDirection * speed);

        // 플레이어의 속력을 제한하여 최대 속력을 유지합니다.
        Vector2 clampedVelocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
        rb.velocity = clampedVelocity;

        if (isGround == true)
        {
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump&&isGround)
            {
                //     바닥에 있으면 일반 점프 실행
                canJump = false;
                isGround = false;
                Jump();
            }
        }
    }


    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpingPower / 28.0f * 23.5f));
        isGround = false;
        canJump = false;
    }
}