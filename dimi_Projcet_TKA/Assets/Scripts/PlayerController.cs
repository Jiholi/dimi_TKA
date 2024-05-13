using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Dictionary<string, string> keyMap = new Dictionary<string, string>(); // 키매핑
    int rot = 0;
    int lastRot = 0;
    int postRot;
    GameObject foot;
    Collider2D footC;
    public float speed = 12.5f;
    public float standardSpeed = 12.5f;
    public float jumpPower = 300;
    public bool isGround = false;
    public bool isSlide = false;
    public float dashJumpPower = 80f;
    public float dashSpeed = 24;
    public float dashRuntime = 0.113f;
    bool isDashing = false; // 대시 중인지 여부

    private void Awake() {
        Application.targetFrameRate = 48;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        foot = GameObject.Find("foot");
        footC = foot.GetComponent<Collider2D>();

        // 키매핑        
        keyMap.Add("Jump", "space");
        keyMap.Add("Left", "a");
        keyMap.Add("Right", "d");
        keyMap.Add("Dash", "left shift");
    }

    void OnTriggerStay2D(Collider2D footC)
    {
        isGround = true;
    }

    void OnTriggerEnter2D(Collider2D footC)
    {
        isGround = true;
    }

    void Update()
    {
        rot = 0;
        if (Input.GetKey(keyMap["Right"])) { rot = 1; lastRot = 1; }
        else if (Input.GetKey(keyMap["Left"])) { rot = -1; lastRot = -1; }

        if (Input.GetKeyDown(keyMap["Jump"]) && isGround && !isDashing) { Jump(); }
        if (Input.GetKeyDown(keyMap["Dash"]) && !isDashing) { Dash(); }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rot * speed, rb.velocity.y);
        if (rb.velocity.y > 17) { rb.velocity = new Vector2(rb.velocity.x, 17); }
    }

    void Jump()
    {
        speed = standardSpeed;
        isGround = false;
        isSlide = false;
        rb.AddForce(new Vector2(0, jumpPower));
        Debug.Log("Jump");
    }

    void Dash()
    {
        isDashing = true; // 대시 시작
        rb.AddForce(new Vector2(0, dashJumpPower));
        speed = standardSpeed + dashSpeed;
        Invoke("EndDash", dashRuntime); // 대시 종료 예약
        Debug.Log("Dash!");
    }

    void EndDash()
    {
        isDashing = false; // 대시 종료
        speed = standardSpeed; // 속도 초기화
    }
}