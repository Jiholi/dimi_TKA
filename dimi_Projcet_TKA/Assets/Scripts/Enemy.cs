using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp = 20;
    Collider2D collid; // 콜라이더
    GameObject player;
    public GameObject me;
    Rigidbody2D rb;
    public float friction;
    public float colleague_delay = 0;
    public int move_speed = 10;
    public int jump_percentage = 10;
    public int jump_power = 100;
    public bool is_ground = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        this.collid = GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    //피격 판정
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            if (colleague_delay == 0)
            {
                int n = 1500;
                int damage = other.GetComponent<Bullet>().Damage;
                Debug.Log("충돌");
                rb.AddForce(new Vector2(player.GetComponent<Player_controller>().lastRotation * n, 1000));
                hp = hp - damage;
                if (hp <= 0) { Destroy(me); Debug.Log("this object dead"); }
                colleague_delay = 0.2f;
            }
        }
        else is_ground = true;
    }

    void monster_ai()
    {
        int y_val = 0;
        if (is_ground) if (Random.Range(0, 100) <= jump_percentage)
            {
                y_val = jump_power;
                is_ground = false;
            }
        rb.AddForce(new Vector2((player.GetComponent<Transform>().position.x < this.GetComponent<Transform>().position.x ? -1 : 1) * move_speed, y_val));
        
    }
    void Update()
    {
        Vector2 frictionforce = new Vector2(-rb.velocity.x, 0);
        rb.AddForce(frictionforce * friction, ForceMode2D.Force);
        monster_ai();
    }


    private void FixedUpdate()
    {
        if (colleague_delay > 0)
        {
            colleague_delay -= Time.deltaTime;
        }
        else colleague_delay = 0;
    }
}