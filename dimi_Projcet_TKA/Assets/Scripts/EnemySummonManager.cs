using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonManager : MonoBehaviour
{
    Collider2D col;
    private 
    void Awake (){
        col = gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col){
        Summon();
    }

    void Summon(){
        // 특정 구역 입장시 적 소환 
    }
}
