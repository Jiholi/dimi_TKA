using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Dictionary<string, string> keyMap;
    public GameObject DefaultBullet; // 추후 공격 시스템 구축을 위한 예제. 삭제 예정
    public Transform Player;

    void Start(){
        Player = this.gameObject.GetComponent<Transform>();
        GameObject myBullet = Instantiate(DefaultBullet, Player);
    }
    // 입력
    void Update()
    {
        if(Input.GetMouseButton(0)){ LeftClick(); } // 좌클릭
        if(Input.GetMouseButton(1)){ RightClick(); } // 우클릭
    }

    void FixedUpdate(){

    }

    void LeftClick(){
        
    }

    void RightClick(){

    }
}
