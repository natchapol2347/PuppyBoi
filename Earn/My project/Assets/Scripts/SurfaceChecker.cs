using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
public class SurfaceChecker : MonoBehaviour
{
    public ARRaycastManager arRayCastMng;
    public bool canPlace;
    private Pose placementPose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRayCastMng.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        canPlace = hits.Count > 0;
        if (canPlace)
        {
            placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);

        }
    }
}
