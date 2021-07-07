using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleRotateScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider scaleSlider;
    private Slider rotateSlider;
    public float scaleMinValue;
    public float scaleMaxValue;
    public float rotMaxValue;
    public float rotMinValue;
    void Start()
    {
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();

        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);
        
        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = rotMinValue;
        rotateSlider.maxValue = rotMaxValue;

        rotateSlider.onValueChanged.AddListener(RotUpdate);
    }

    private void RotUpdate(float rot)
    {
        // Debug.Log(rot);
        transform.localEulerAngles = new Vector3(transform.rotation.x,rot,transform.rotation.z);
    }

    private void ScaleSliderUpdate(float scale)
    {
        transform.localScale = new Vector3(scale,scale,scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
