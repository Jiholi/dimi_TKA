using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_con : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 M_lo;
    
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
       M_lo = transform.position;
    }
}
