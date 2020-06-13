using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class FIgureController : MonoBehaviour
{
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits;
    public GameObject place_prefab;
    private FigureDemoController demoController;
    private int co = 0;
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
        demoController = GameObject.FindObjectOfType<FigureDemoController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (IsPointerOverUIObject(touch.position))
        {
            return;
        }
        if (raycastManager.Raycast(touch.position, hits) && co < 1)
        {
            Pose _pose = hits[0].pose;
            var c = Instantiate(place_prefab, _pose.position, Quaternion.identity);
            demoController.GetElements();
            co += 1;
        }
    }
    bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null)
        {
            return false;
        }
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
