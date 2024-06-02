using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    public int hp = 100; // 플레이어 Hp
    [SerializeField]int fullHp = 100;
    float collisionCooltime =  0f; // 쿨타임 유효 시간
    [SerializeField] float standardCollsionColltime =  0.7f;
    [SerializeField] int verticalCollsionPow = 1500;
    [SerializeField] int horizontalCollsionPow = 2700;

    public Rigidbody2D rb ; // 플레이어 rigidbody;
    public Transform tr;
    Collider2D col;
    GameObject player;

    void Start(){
        col = GetComponent<Collider2D>();
        hp = fullHp;
        player = GameObject.Find("Player");
    }

    void Update(){
        if(collisionCooltime > 0 ) { collisionCooltime -= Time.deltaTime; } else if( collisionCooltime < 0 ) { collisionCooltime = 0; }
        if (tr.position.y<=-60) TurnBack();
    }


    // 적과의 충돌 판정
    /*void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collid");
        Vector2 enemyPos;
        if ( other.tag.Equals("Enemy"))
        {
            enemyPos = other.GetComponent<Transform>().position;
            if(player.GetComponent<Player_controller>().isGround){}
            else if ( tr.position.x > enemyPos.x && collisionCooltime <= 0) { rb.AddForce(new Vector2(1 * horizontalCollsionPow, verticalCollsionPow)); collisionCooltime = standardCollsionColltime; hp -= other.GetComponent<Enemy>().attack_power;}
            else if(collisionCooltime <= 0){ rb.AddForce(new Vector2(-1 * horizontalCollsionPow , verticalCollsionPow)); Debug.Log("Attacked"); collisionCooltime = standardCollsionColltime; hp -= other.GetComponent<Enemy>().attack_power;}

            if (hp <= 0)
            {
                TurnBack();
            }
        }
    }*/

    void TurnBack()
    {
        tr.position = new Vector2(0, 0);
        hp = fullHp;
    }
        
    
}
