using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonManager : MonoBehaviour
{
    Collider2D collid;
    public GameObject defaultEnemy;
    public GameObject rangerEnemy;

    private 
    void Awake (){
        collid = gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        Summon();
    }

    void Summon(){
        // 특정 구역 입장시 적 소환 
    }
}
