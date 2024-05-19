using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject DefaultBullet; // 추후 공격 시스템 구축을 위한 예제. 삭제 예정
    public GameObject slash;

    public Transform Player;
    public Vector3 dir;
    Camera cam;
    [SerializeField] private float delay = 0;


    void Start(){
        cam = Camera.main;
        Player = this.gameObject.GetComponent<Transform>();
    }

    // 입력
    void Update()
    {
        if(delay > 0) { delay -= Time.deltaTime; } else if(delay < 0 ) { delay = 0; }
        if(Input.GetMouseButton(0)){ LeftClick(); } // 좌클릭
        if(Input.GetMouseButton(1)){ RightClick(); } // 우클릭

        dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
    }

    void FixedUpdate(){
        
    }

    void LeftClick(){
        Debug.Log("left Click");
        Bullet();
    }

    void RightClick(){
        Slash();
    }


    void Bullet(){
        if(delay <= 0 ){
            GameObject defaultBullet = Instantiate(DefaultBullet, Player) ;
            delay += 0.25f;
        } 
    }

    void Slash(){
        if(delay <= 0 ){
            GameObject Slash = Instantiate(slash, Player) ;
            delay += 2f;
        } 
    }

    void Charge(){

    }
}
