using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARPlacementManager : MonoBehaviour
{
    // Start is called before the first frame update
    ARRaycastManager rayM;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Camera arcam;

    public GameObject playerbox; 

    private void awake()
    {
        rayM = GetComponent<ARRaycastManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = arcam.ScreenPointToRay(center);

        if (rayM.Raycast(ray, hits, TrackableType.PlaneWithinPolygon)){
            Pose hitpose = hits[0].pose;

            Vector3 pos = hitpose.position;

            playerbox.transform.position = pos;
        }

    }
}
