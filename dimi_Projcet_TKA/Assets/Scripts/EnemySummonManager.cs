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
        
    }
}
