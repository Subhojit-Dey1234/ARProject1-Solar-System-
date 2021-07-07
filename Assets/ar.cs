using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ar : MonoBehaviour
{

    public GameObject arObjectToSpawn;
    public GameObject shoot;
    public Button button;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private float initialDistance;
    private Vector3 initialScale;
    // private float finalDistance;
    // private float finalScale;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        button = GameObject.Find("Button").GetComponent<Button>();

        button.onClick.AddListener(AddObject);
        shoot.SetActive(false);
    }

    private void AddObject()
    {
        placementIndicator.SetActive(true);
        spawnedObject = null;
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if(spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
            shoot.SetActive(true);
        }

        if (Input.touchCount == 2){
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled ||
            touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled){
                return;
            }

            if(touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began){

                initialDistance = Vector2.Distance(touchZero.position,touchOne.position);
                initialScale = spawnedObject.transform.localScale;
            }
            else{
                var currentDistance = Vector2.Distance(touchOne.position,touchZero.position);
                var factor = currentDistance/ initialDistance;

                if(Mathf.Approximately(initialDistance,0)){
                    return;
                }

                spawnedObject.transform.localScale = initialScale * factor;
            }
        }


        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }
    void UpdatePlacementIndicator()
    {
        if(spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if(placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }
}


