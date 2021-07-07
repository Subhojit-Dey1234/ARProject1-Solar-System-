using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovingScripts : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update(){
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x,0,y);

        rb.velocity = movement * 0.4f ;

    }
}
