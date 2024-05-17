using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private float speed = 10; // 플레이어 이동 속도
    [SerializeField] private float jumpingPower = 10; // 플레이어 점프 힘
    [SerializeField] private float friction = 0.1f; // 플레이어 마찰력
    [SerializeField] private float maxSpeed = 10; // 플레이어 최대 속력
    [SerializeField] private int frameRate = 120; // 프레임
    LayerMask groundLayer; // 바닥 레이어
    Transform groundCheck; // 바닥 체크 위치
    Rigidbody2D rb; // 플레이어의 Rigidbody2D 컴포넌트
    Collider2D footCollider; // 발 충돌체
    private bool isGround = false; // 플레이어가 바닥에 있는지 여부
    private float jumpBufferTime = 0.1f; // 점프 버퍼링 지연 시간
    private bool isJumpBuffered = false; // 점프 입력 버퍼링 여부
    private bool canJump = true; // 점프 가능 여부


    private Vector2 moveDirection;
    private Vector2 frictionForce;

    void Awake() {
        // Application.targetFrameRate = frameRate; // 프레임율 설정
    }
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.footCollider = gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D footCollider) { isGround = true; }
    void OnTriggerExit2D(Collider2D footCollider){ isGround = false; }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 수평 입력 값
        moveDirection = new Vector2(horizontalInput, 0); // 이동 방향 벡터
        frictionForce = new Vector2(-rb.velocity.x * friction, 0); // 플레이어에게 가해지는 마찰력을 계산합니다.
        

        // 플레이어의 속력을 제한하여 최대 속력을 유지합니다.
        Vector2 clampedVelocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
        rb.velocity = clampedVelocity;

        if (isGround== true) { canJump = true; }
        if (Input.GetKeyDown(KeyCode.Space)  && canJump)
        {
            if (isGround) // 바닥에 있으면 일반 점프 실행
            {
                canJump = false;
                isGround = false;
                Jump();
            } else {
                // 바닥에 없으면 점프 입력 버퍼링
                isJumpBuffered = true;
                jumpBufferTime = 0.3f; // 버퍼링 시간 초기화
            }
        }
    }

    void FixedUpdate()
    {
        // 점프 버퍼링 확인 및 실행
        if (isJumpBuffered && !isGround)
        {
            if (jumpBufferTime <0) { jumpBufferTime -= Time.deltaTime; } 
            else {
                isJumpBuffered = false;
                canJump = false;
                isGround = false;
                Jump();
            }
        }

        rb.AddForce(frictionForce, ForceMode2D.Force);
        rb.AddForce(moveDirection * speed); // 플레이어 이동
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpingPower / 28.0f * 23.5f));
        isGround = false;
    }
}