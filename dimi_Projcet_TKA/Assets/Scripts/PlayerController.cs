using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Dictionary<string, string>keyMap= new Dictionary<string, string>(); //키매핌
    int rot = 0;
    int postRot;
    GameObject foot;
    Collider2D footC;
    public float speed = 7;
    public float standardSpeed = 7;
    public float jumpPower = 300;
    public bool isGround = false;
    public bool isSlide = false;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.foot = GameObject.Find("foot");
        this.footC = foot.GetComponent<Collider2D>();

        keyMap.Add("Jump", "space");
        keyMap.Add("Left", "a");
        keyMap.Add("Right", "d");
        keyMap.Add("Slide", "s");
    }
    
    void OnTriggerStay2D(Collider2D footC)
    {
        isGround = true;
    }

    void OnTriggerEnter2D(Collider2D footC) {
        isGround = true;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2000f ) { timer = 0f; }
        rot = 0;
        if (isSlide == false) { speed = standardSpeed; }
        if (Input.GetKey(keyMap["Right"])) { rot = 1; }
        else if (Input.GetKey(keyMap["Left"])) { rot = -1; }

        if (Input.GetKeyDown(keyMap["Jump"]) && isGround) { Jump(); }
        if (Input.GetKey(keyMap["Slide"])) { Slide(); }
        if (Input.GetKeyUp(keyMap["Slide"])) { isSlide = false; }
        
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rot * speed, rb.velocity.y);
    }

    void Jump()
    {
        speed = standardSpeed;
        isGround = false;
        isSlide = false;
        rb.AddForce(new Vector2(0, jumpPower));
        Debug.Log("Jump");

    }

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

        
    }
}
