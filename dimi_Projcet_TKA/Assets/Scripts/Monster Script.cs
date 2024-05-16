using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public Vector2 M_location;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        M_location = transform.position;
    }
}
