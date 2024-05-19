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
    }
    void Update()
    {
            Vector2 frictionforce = new Vector2(-rb.velocity.x, 0);
            rb.AddForce(frictionforce * friction, ForceMode2D.Force);
    }


    private void FixedUpdate()
    {
        if (colleague_delay > 0)
        {
            colleague_delay -= Time.deltaTime;
        }
        else colleague_delay = 0;
    }



    // navigate (몬스터 ai)
    // issue - 만들줄 모른다! - 누군가 만들어주길 요망.
}