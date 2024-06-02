using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Rigidbody2D rb; 
    public GameObject Trigger;

    void Awake()
    {
        Application.targetFrameRate = 120;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Trigger = GameObject.Find("TRIGGER");
    }

    // Update is called once per frame
    void Update()
    {
        if(Trigger.GetComponent<Trigger>().is_trigger ==true){
            StartCoroutine(Jumping());
        }
    }

    void jumping(){
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("spider"), LayerMask.NameToLayer("Ground"));
            rb.AddForce(new Vector2(0,1000));
    }
    IEnumerator Jumping(){
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("spider"), LayerMask.NameToLayer("Ground"));
        for( int i=1; i<=3; i++ ){
        rb.AddForce(new Vector2(0,520-i*20));
        yield return new WaitForSeconds(0.06f);}
        yield return new WaitForSeconds(0.15f);

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("spider"), LayerMask.NameToLayer("Ground"),false);
    }
}
