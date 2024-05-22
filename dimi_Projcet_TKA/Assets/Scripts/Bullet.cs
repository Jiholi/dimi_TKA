using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int Damage = 5;
    /// <summary>
    /// 총알이 삭제될 때 까지 걸리는 시간.
    /// </summary>
    [SerializeField] float lifeTime;
    /// <summary>
    /// 총알 종류. bullet/slash/lazer 순서대로 1/2/3
    /// </summary>
    [SerializeField] int attackType = 2;
    /// <summary>
    /// 투척형 탄환의 발사 강도.
    /// </summary>
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
            defaultSlash(player.GetComponent<Player_controller>().lastRotation);
        }
    }

    void Update()
    {

    }

    void defaultSlash(float rot)
    {
        if (rot > 0) { transf.localPosition = new Vector2(2.7f, 0); }
        else { transf.localPosition = new Vector2(-2.7f, 0); }
    }

    void defaultBullet(Vector3 throwDirection)
    {
        rb.AddForce(throwDirection * throwPower);
        Debug.Log("shoot");
    }
}