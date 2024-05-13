using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 10; // 플레이어 이동 속도
    public float jumpingPower = 10; // 플레이어 점프 힘
    public float friction = 0.1f; // 플레이어 마찰력
    public float maxSpeed = 10; // 플레이어 최대 속력
    public LayerMask groundLayer; // 바닥 레이어
    public Transform groundCheck; // 바닥 체크 위치
    private Rigidbody2D rb; // 플레이어의 Rigidbody2D 컴포넌트
    Collider2D footC; // 발 충돌체
    public bool isGround = false; // 플레이어가 바닥에 있는지 여부

    private void Awake() {
        // Application.targetFrameRate = 48;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footC = groundCheck.GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D footC)
    {
        isGround = true; 
    }

    void OnTriggerEnter2D(Collider2D footC)
    {
        isGround = true;
    }

    // void OnTriggerExit2D(Collider2D footC)
    // {
    //     if (footC.gameObject.layer != 6) // 6번 레이어가 아닌 경우에만 바닥으로 간주
    //         isGround = false;
    // }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 수평 입력 값
        Vector2 moveDirection = new Vector2(horizontalInput, 0); // 이동 방향 벡터

        // 플레이어에게 가해지는 마찰력을 계산합니다.
        Vector2 frictionForce = new Vector2(-rb.velocity.x * friction, 0);
        rb.AddForce(frictionForce, ForceMode2D.Force);

        // 플레이어에게 이동 힘을 가합니다.
        rb.AddForce(moveDirection * speed);

        // 플레이어의 속력을 제한하여 최대 속력을 유지합니다.
        Vector2 clampedVelocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
        rb.velocity = clampedVelocity;

    }
    private float jumpCooldown = 0.1f; // 점프 쿨타임
    private bool canJump = true; // 점프 가능 여부

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && canJump) // 스페이스바를 누르고 바닥에 있는 경우에만 점프
        {
            StartCoroutine(Jump());
            canJump = false; // 점프 후 점프 불가능 상태로 변경
            StartCoroutine(ResetJumpCooldown()); // 점프 쿨타임 시작
        } 
    }

    IEnumerator ResetJumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true; // 점프 가능 상태로 변경
    }
    IEnumerator Jump()
    {
        isGround = false;
        for (int i = 1; i <= 8; i++)
        {
            rb.AddForce(new Vector2(0, jumpingPower / 6.0f));
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("Jump");
    }
}
