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
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.foot = GameObject.Find("foot");
        this.footC = foot.GetComponent<Collider2D>();

        //키매핑        
        keyMap.Add("Jump", "space");
        keyMap.Add("Left", "a");
        keyMap.Add("Right", "d");
        keyMap.Add("Dash", "left shift");
    }
    
    //발이 땅에 닿아있는지 판정함
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
        rot = 0;
        if (Input.GetKey(keyMap["Right"])) { rot = 1; lastRot = 1; }
        else if (Input.GetKey(keyMap["Left"])) { rot = -1; lastRot = -1; }

        if (Input.GetKey(keyMap["Jump"]) && isGround) { Jump(); }
        if (Input.GetKeyDown(keyMap["Dash"])) { Dash(); rot = lastRot;  }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rot * speed, rb.velocity.y);
        if( rb.velocity.y > 17) {new Vector2(rot * speed, 17);}

    }

    void Jump()
    {
        speed = standardSpeed;
        isGround = false;
        isSlide = false;
        rb.AddForce(new Vector2(0, jumpPower));
        Debug.Log("Jump");
    }

    //dash
    void Dash(){

        rb.AddForce( new Vector2(0, dashJumpPower));
        speed = standardSpeed + dashSpeed;
        Invoke("initSpeed", dashRuntime);
        Debug.Log("dash!");
    }
    void initSpeed(){
        speed = standardSpeed;
    }
}
