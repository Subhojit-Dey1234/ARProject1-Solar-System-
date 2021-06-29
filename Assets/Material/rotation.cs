using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform Sun;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,90.0f*Time.deltaTime,0,Space.Self);
        transform.RotateAround(Sun.position,Sun.up, speed * Time.deltaTime);
    }
}
