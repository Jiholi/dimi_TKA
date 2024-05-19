using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject Melee;

    public Transform Player;
    public Vector3 dir;
    Camera cam;
    [SerializeField] private float delay = 0;


    void Start()
    {
        cam = Camera.main;
        Player = this.gameObject.GetComponent<Transform>();
    }

    // �Է�
    void Update()
    {
        if (delay > 0) { delay -= Time.deltaTime; } else if (delay < 0) { delay = 0; }
        if (Input.GetMouseButtonDown(0)) { LeftClick(); } // ��Ŭ��
        if (Input.GetMouseButtonDown(1)) { RightClick(); } // ��Ŭ��

        dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
    }

    void FixedUpdate()
    {

    }

    void LeftClick()
    { 
        Slash();
    }

    void RightClick()
    {
        
    }

    void Slash()
    {
        if (delay <= 0)
        {
            GameObject melee = Instantiate(Melee, Player);
            delay += 0.3f;
        }
    }
}