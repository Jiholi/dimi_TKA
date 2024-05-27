using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject Melee;
    public GameObject JumpMelee;
    public Transform playerPos;
    GameObject player;
    public Vector3 dir;
    Rigidbody2D rb;
    Camera cam;
    [SerializeField] private float delay = 0;
    [SerializeField] bool isWClicked;
    public bool isJumpMelee;
    bool LastisJumpMelee;


    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
        playerPos = this.gameObject.GetComponent<Transform>();
    }

    // �Է�
    void Update()
    {
        if (delay > 0) { delay -= Time.deltaTime; } else if (delay < 0) { delay = 0; }
        if (Input.GetMouseButtonDown(0)) { LeftClick(); } // ��Ŭ��
        if (Input.GetMouseButtonDown(1)) { RightClick(); } // ��Ŭ��
        if (Input.GetKeyDown("w")) { pushW(); }

        dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
        if(player.GetComponent<Player_controller>().isGround) {
            LastisJumpMelee = false;
        }
    }

    void LeftClick()
    { 
        isWClicked = false;
        Slash();
    }

    void pushW(){
        isWClicked = true;
        if(!player.GetComponent<Player_controller>().isGround){
            Slash();
        }
    }

    void RightClick()
    {
        
    }

    void Slash()
    {
        int horizontalJumpPow = 1250;
        int verticalJumpPow = 250;
        bool isAtatacking;
        if (delay <= 0)
        {
            isAtatacking = false;
            if(!player.GetComponent<Player_controller>().isGround){
                if(!isAtatacking && isWClicked && !LastisJumpMelee)
                {
                    LastisJumpMelee = true;
                    delay += 0.612f;
                    GameObject jumpMelee = Instantiate(JumpMelee, playerPos);
                    isAtatacking = false;
                    isJumpMelee = true;
                    rb.velocity = Vector3.zero;
                    rb.AddForce(new Vector2(player.GetComponent<Player_controller>().lastRotation * verticalJumpPow, horizontalJumpPow));
                } else if(!isWClicked) {
                    GameObject melee = Instantiate(Melee, playerPos);
                    delay += 0.3f;
                    isAtatacking = true;
                    isWClicked = false;
                    isJumpMelee = false;
                }
            } else if(!isWClicked){
                GameObject melee = Instantiate(Melee, playerPos);
                delay += 0.3f;
                isAtatacking = true;
                isWClicked = false;
                isJumpMelee = false;
            }   
        }        
    }
}