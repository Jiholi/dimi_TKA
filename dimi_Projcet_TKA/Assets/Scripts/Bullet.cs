using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int Damage = 5;
    /// <summary>
    /// �Ѿ��� ������ �� ���� �ɸ��� �ð�.
    /// </summary>
    [SerializeField] float lifeTime;
    /// <summary>
    /// �Ѿ� ����. bullet/slash/lazer ������� 1/2/3
    /// </summary>
    [SerializeField] int attackType = 2;
    /// <summary>
    /// ��ô�� źȯ�� �߻� ����.
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
        if(player.GetComponent<CombatManager>().isJumpMelee){}
        else if (rot > 0) { transf.localPosition = new Vector2(2.7f, 0); }
        else { transf.localPosition = new Vector2(-2.7f, 0); }
    }

    void defaultBullet(Vector3 throwDirection)
    {
        rb.AddForce(throwDirection * throwPower);
        Debug.Log("shoot");
    }
}