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
    /// 총알 종류. bullet/bomb/lazer 순서대로 1/2/3
    /// </summary>
    [SerializeField] int attackType = 1;
    /// <summary>
    /// 투척형 탄환의 발사 강도.
    /// </summary>
    [SerializeField] int throwPower = 100;
    Rigidbody2D rb;
    GameObject player;

    void Start(){
        
        player = GameObject.Find("Player");
        Destroy(this.gameObject, lifeTime);
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        if(attackType == 1) {
            defaultBullet(player.GetComponent<CombatManager>().dir * throwPower);
        }
    }

    void Update(){
        
    }

    public void defaultBullet(Vector3 throwDirection)
    {
        rb.AddForce(throwDirection * throwPower);       
        Debug.Log("shoot"); 
    }

    void hitScan()
    {

    }
}
