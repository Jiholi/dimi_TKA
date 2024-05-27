using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp = 20;
    Collider2D collid; 
    GameObject player;
    public GameObject me;
    Rigidbody2D rb;
    public float friction;
    public float colleague_delay = 0;
    public int move_speed = 10;
    public int jump_percentage = 10;
    public int jump_power = 100;
    public bool is_ground = true;
    public int attack_power = 10;
    float stunDuration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        this.collid = GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

            if (other.tag == "Bullet")
            {

                if (colleague_delay == 0)
                {
                    rb.velocity = new Vector2(0, 0);
                    int n = 2000;
                    int damage = other.GetComponent<Bullet>().Damage;
                    Debug.Log("충돌");
                    rb.AddForce(new Vector2(player.GetComponent<Player_controller>().lastRotation * n, 500));
                    hp = hp - damage;
                    if (hp <= 0) { Destroy(me); Debug.Log("this object dead"); }
                    colleague_delay = 0.2f;
                    stunDuration = 0.5f;

            }
                is_ground = false;
            }
            else is_ground = true;
    }

    void monster_ai()
    {
        if (stunDuration > 0.0f)
        {
            stunDuration -= Time.deltaTime; // Reduce stun duration every frame
            return; // Don't perform AI logic while stunned
        }
        int y_val = 0;
            if (is_ground) if (Random.Range(0, 100) <= jump_percentage)
                {
                    y_val = jump_power;
                    is_ground = false;
                }
            rb.AddForce(new Vector2((player.GetComponent<Transform>().position.x < this.GetComponent<Transform>().position.x ? -1 : 1) * move_speed, 0));
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