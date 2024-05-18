using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject DefaultBullet; // 추후 공격 시스템 구축을 위한 예제. 삭제 예정
    public Transform Player;
    public Vector3 dir;
    Camera cam;


    void Start(){
        cam = Camera.main;
        Player = this.gameObject.GetComponent<Transform>();
    }
    // 입력
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ LeftClick(); } // 좌클릭
        if(Input.GetMouseButtonDown(1)){ RightClick(); } // 우클릭

        dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
    }

    void FixedUpdate(){

    }

    void LeftClick(){
        GameObject defaultBullet = Instantiate(DefaultBullet, Player) ;
        Debug.Log("left Click");
    }

    void RightClick(){

    }
}
