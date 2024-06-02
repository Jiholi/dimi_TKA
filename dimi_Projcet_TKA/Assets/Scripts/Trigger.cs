using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_trigger=false;
    Collider2D collid; 
    public GameObject me;
    
    void Start()
    {
        this.collid = GetComponent<Collider2D>();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
        is_trigger=true;
        transform.position = new Vector2(0,1000);
        StartCoroutine(wait());
    }}

    IEnumerator wait(){
        yield return new WaitForSeconds(0.000000001f);
        is_trigger =false;
    }
}
