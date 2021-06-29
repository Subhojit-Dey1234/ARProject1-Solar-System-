using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    // Start is called before the first frame update
    protected Joystick joystick;
    public Rigidbody sphere;
    void Start()
    {
        joystick = GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        sphere.velocity = new Vector3(joystick.Horizontal * 100f,0,joystick.Vertical * 100);
        Debug.Log(sphere.velocity);
        Debug.Log(sphere.position);
    }
}
