using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject gameObjectPrefab;

    public GameObject gameObjectSpawned;


    Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        PlaceObject();
    }

    public void PlaceObject()
    {
        if (raycastManager.Raycast(touchPosition,hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (gameObjectSpawned == null)
            {
                gameObjectSpawned = Instantiate(gameObjectPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                gameObjectSpawned.transform.position = hitPose.position;
            }
        }
    }
}
