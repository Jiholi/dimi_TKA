using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int Damage = 5;

    [SerializeField] float lifeTime;

    [SerializeField] int attackType = 2;

    [SerializeField] int throwPower = 100;
    Rigidbody2D rb;
    GameObject player;
    Transform transf;

    void Start()
    {

        player = GameObject.Find("Player");
        Destroy(this.gameObject, lifeTime);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        transf = this.gameObject.GetComponent<Transform>();

        if (attackType == 1)
        {
            defaultBullet(player.GetComponent<CombatManager>().dir * throwPower);
        }
        else if (attackType == 2)
        {
            defaultSlash();
        }
    }

    void Update()
    {
    }

    void defaultSlash()
    {
        if(player.GetComponent<CombatManager>().isJumpMelee){}
        else { transf.localPosition = new Vector2(0.1f, 1.2f); }
    }

    void defaultBullet(Vector3 throwDirection)
    {
        rb.AddForce(throwDirection * throwPower);
        Debug.Log("shoot");
    }
}