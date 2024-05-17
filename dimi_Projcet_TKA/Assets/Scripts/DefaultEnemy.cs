using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Collider2D col ; // 콜라이더
    // protected public int hp;

    // Start is called before the first frame update
    void Start()
    {
        this.col = GetComponent<Collider2D>();
    }

    //피격 판정
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Bullet")) {
            int damage = other.GetComponent<BulletManager>().Damage;
            // hp = hp - damage;
            // if ( hp < 0 ){Destroy(this.gameObject);} 
            Debug.Log("this object dead");
        }
    }
    virtual public void Update()
    {
        
    }

    // navigate (몬스터 ai)
    // issue - 만들줄 모른다! - 누군가 만들어주길 요망.
}
