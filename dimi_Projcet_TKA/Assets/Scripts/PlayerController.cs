using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Dictionary<string, string> keyMap = new Dictionary<string, string>(); // 키매핑
    int rot = 0;
    int postRot;
    GameObject foot;
    Collider2D footC;
    public float speed = 7;
    public float standardSpeed = 7;
    public float jumpPower = 300;
    public bool isGround = false;
    public bool isSlide = false;
<<<<<<< Updated upstream
    public float timer = 0f;

    // Start is called before the first frame update
=======
    public float dashJumpPower = 80f;
    public float dashSpeed = 24;
    public float dashRuntime = 0.113f;
    bool isDashing = false; // 대시 중인지 여부

>>>>>>> Stashed changes
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        foot = GameObject.Find("foot");
        footC = foot.GetComponent<Collider2D>();

<<<<<<< Updated upstream
=======
        // 키매핑        
>>>>>>> Stashed changes
        keyMap.Add("Jump", "space");
        keyMap.Add("Left", "a");
        keyMap.Add("Right", "d");
        keyMap.Add("Slide", "s");
    }
<<<<<<< Updated upstream
    
=======

>>>>>>> Stashed changes
    void OnTriggerStay2D(Collider2D footC)
    {
        isGround = true;
    }

<<<<<<< Updated upstream
    void OnTriggerEnter2D(Collider2D footC) {
        isGround = true;
    }
    // Update is called once per frame
=======
    void OnTriggerEnter2D(Collider2D footC)
    {
        isGround = true;
    }

>>>>>>> Stashed changes
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2000f ) { timer = 0f; }
        rot = 0;
        if (isSlide == false) { speed = standardSpeed; }
        if (Input.GetKey(keyMap["Right"])) { rot = 1; }
        else if (Input.GetKey(keyMap["Left"])) { rot = -1; }

<<<<<<< Updated upstream
        if (Input.GetKeyDown(keyMap["Jump"]) && isGround) { Jump(); }
        if (Input.GetKey(keyMap["Slide"])) { Slide(); }
        if (Input.GetKeyUp(keyMap["Slide"])) { isSlide = false; }
        
        
=======
        if (Input.GetKeyDown(keyMap["Jump"]) && isGround && !isDashing) { Jump(); }
        if (Input.GetKeyDown(keyMap["Dash"]) && !isDashing) { Dash(); }
>>>>>>> Stashed changes
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rot * speed, rb.velocity.y);
<<<<<<< Updated upstream
=======
        if (rb.velocity.y > 17) { rb.velocity = new Vector2(rb.velocity.x, 17); }
>>>>>>> Stashed changes
    }

    void Jump()
    {
        speed = standardSpeed;
        isGround = false;
        isSlide = false;
        rb.AddForce(new Vector2(0, jumpPower));
        Debug.Log("Jump");

    }

<<<<<<< Updated upstream
    void Slide()
    {
        if (!isSlide)
        {
            timer = 0;
        }

        if (rot != 0 && isGround) {
            isSlide = true; 
            if (timer < 1.8) { speed = 9.5f; } else { speed = 4.5f; }
        } else { speed = 4.5f; isSlide = true; }

        
=======
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
>>>>>>> Stashed changes
    }
}
