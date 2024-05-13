using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    void Awake(){
        Invoke("Dead", 1);
    }
    void Dead(){
        Destroy(this.gameObject);
    }
    [SerializeField] private float animate;
    public int Damage = 5;
}
