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
    Animator attackty;
    SpriteRenderer spriteRenderer;
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
    Animator Attack;
    bool isAtatacking = false;
    float action_timer;
    float attacktimer;
    int attacktype=0;

    void Start()
    {
        attacktype=0;
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
        playerPos = this.gameObject.GetComponent<Transform>();
        Attack = GetComponent<Animator>();
        attackty = GetComponent<Animator>();
    }

    // �Է�
    void Update()
    {
        if (delay <= 0)
        {
            isAtatacking = false;
        }
        if (delay > 0) { delay -= Time.deltaTime; } else if (delay < 0) { delay = 0; }
        if (attacktimer > 0) { attacktimer -= Time.deltaTime; } else if (attacktimer < 0) { attacktimer = 0; }
        if (action_timer > 0) { action_timer -= Time.deltaTime; } else if (action_timer < 0) { action_timer = 0; }
        if (Input.GetMouseButtonDown(0)) { LeftClick();}
        if (Input.GetMouseButtonDown(1)) { RightClick(); } 
        if (Input.GetKeyDown("w")) { pushW(); }

        dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
        if(player.GetComponent<Player_controller>().isGround) {
            LastisJumpMelee = false;
        }
        if(Input.GetMouseButtonDown(0)&&isAtatacking ==true){
            if(attacktype==0){
            Attack.SetBool("IsAttacking2",false);
            Attack.SetBool("IsAttacking3",false);
            Attack.SetBool("IsAttacking1",true);
            attacktype+=1;
            }
            else if(attacktype ==1){
            Attack.SetBool("IsAttacking2",true);
            Attack.SetBool("IsAttacking3",false);
            Attack.SetBool("IsAttacking1",false);
            attacktype+=1;
            }
            else if(attacktype==2){
            Attack.SetBool("IsAttacking2",false);
            Attack.SetBool("IsAttacking3",true);
            Attack.SetBool("IsAttacking1",false);
            attacktype=0;
            }
            
        }
        if(isAtatacking ==false){
            Attack.SetBool("IsAttacking1",false);
            Attack.SetBool("IsAttacking2",false);
            Attack.SetBool("IsAttacking3",false);
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
        int verticalJumpPow = 350;
        if (delay <= 0)
        {
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
                    delay += 0.4f;
                    isAtatacking = true;
                    isWClicked = false;
                    isJumpMelee = false;
                }
            } else if(!isWClicked){
                GameObject melee = Instantiate(Melee, playerPos);
                delay += 0.4f;
                isAtatacking = true;
                isWClicked = false;
                isJumpMelee = false;
            }  
        }        
    }
}