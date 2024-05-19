using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController: MonoBehaviour
{   
    Rigidbody2D rb;
    public Collider2D footCollider;
    [SerializeField] private float speed = 12.5f;
    [SerializeField] private float standardSpeed = 12.5f;
    [SerializeField] private float jumpPower = 300;
    [SerializeField] private int MaxVerticalSpeeed = 17;

    public bool isGround = false;
    private float player_rotation = 0; // 플레이어의 현재 이동 방향W`z
    /// <summary>
    /// 플레이억 마지막으로 바라보고 있던 방향
    /// </summary>
    public float lastRotation = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 플레이어가 땅을 밟고 있는지 판정함.
    void OnTriggerStay2D(Collider2D footCollider) { isGround = true; }
    void OnTriggerExit2D(Collider2D footCollider) { isGround = false; }

    //키입력
    void Update()
    {
        player_rotation = Input.GetAxisRaw("Horizontal");
        /*if (Input.GetKey(keyMap["Right"])) { rotation = 1;  }
        else if (Input.GetKey(keyMap["Left"])) { rotation = -1; } */
        if (Input.GetKeyDown("space") && isGround ) { Jump(); }
        if(player_rotation != 0){
            lastRotation = player_rotation;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(player_rotation * speed, rb.velocity.y)  ; // vecolity 이동.
        if (rb.velocity.y > MaxVerticalSpeeed) { rb.velocity = new Vector2(rb.velocity.x, MaxVerticalSpeeed); } // 하락 최대속도 제한.
    }

    /// <summary>
    /// 점프 함수.
    /// </summary>
    void Jump()
    {
        speed = standardSpeed;
        rb.AddForce(new Vector2(0, jumpPower));
        Debug.Log("Jump");
    }

    /* 추후 복구
    [SerializeField] private float speed = 10; // 플레이어 이동 속도
    [SerializeField] private float jumpingPower = 10; // 플레이어 점프 힘
    [SerializeField] private float friction = 0.1f; // 플레이어 마찰력
    [SerializeField] private float maxSpeed = 10; // 플레이어 최대 속력
    [SerializeField] private int frameRate = 120; // 프레임
    Rigidbody2D rb; // 플레이어의 Rigidbody2D 컴포넌트
    public Collider2D footCollider; // 발 충돌체
    private bool isGround = false; // 플레이어가 바닥에 있는지 여부
    private float jumpBufferTime = 0.1f; // 점프 버퍼링 지연 시간
    private bool isJumpBuffered = false; // 점프 입력 버퍼링 여부
    private bool canJump = true; // 점프 가능 여부


    private Vector2 moveDirection;
    private Vector2 frictionForce;
    private Vector2 clampedVelocity;

    void Awake() {
        // Application.targetFrameRate = frameRate; // 프레임율 설정
    }
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = clampedVelocity;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpingPower / 28.0f * 23.5f));
        isGround = false;
    }
    */
}