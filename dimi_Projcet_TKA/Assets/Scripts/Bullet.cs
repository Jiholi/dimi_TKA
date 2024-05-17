using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletManager : MonoBehaviour
{
    public int Damage = 5;    
    float DeadTime; // 총알이 삭제될 시간

    void Awake(){

    }

    void FixedUpdate(){
        DeadTime -= Time.deltaTime;
        if(DeadTime <= 0 ){ Dead(); }
    }

    void Dead(){  Destroy(this.gameObject); }
}
