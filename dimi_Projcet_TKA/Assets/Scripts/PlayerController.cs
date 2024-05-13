using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject foot;
    private Collider2D footC;

    public Dictionary<string, string> keyMap = new Dictionary<string, string>(); // 키매핑
    [SerializeField] private float rot = 0; // 현재 방향
    [SerializeField] private int lastRot = 0; // 방향키를 때었을 때 마지막 이동 방향
    [SerializeField] private float speed = 12.5f; // 현재 속도
    [SerializeField] private float standardSpeed = 12.5f; //속도 초기화를 위한 기준속도
    [SerializeField] private float jumpPower = 300;
    [SerializeField] private bool isGround = false;


    // 키매핑 설정
    void Awake() {
        keyMap.Add("Jump", "space");
        keyMap.Add("Left", "a");
        keyMap.Add("Right", "d");
        keyMap.Add("Dash", "left shift");
        
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        foot = GameObject.Find("foot");
        footC = foot.GetComponent<Collider2D>();
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
        if (Input.GetKey(keyMap["Right"])) { rot = 1; lastRot = 1; }
        else if (Input.GetKey(keyMap["Left"])) { rot = -1; lastRot = -1; }
        else if ( rot > 0 ) { rot = rot - 0.15f; }
        else if ( rot < 0 ) { rot = rot + 0.15f; }
        if (Input.GetKeyDown(keyMap["Jump"]) && isGround) { Jump(); }
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
        rb.AddForce(new Vector2(0, jumpPower));
        Debug.Log("Jump");
    }
}