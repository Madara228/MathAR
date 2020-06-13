using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using TMPro;
public class PlaceScript : MonoBehaviour
{
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits;
    public GameObject model;
    public TextMeshProUGUI textMesh;
    public Vector3 StartVector;
    public Transform p;
    public CanvasController canvasController;
    public NubmeInstance _nubmeInstance;
    public LineMover _lineMover;
    int co = 0;
    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();

        //var c = Instantiate(model, new Vector3(100,100,100), Quaternion.identity);

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
        if (raycastManager.Raycast(touch.position, hits) && co < 1 )
        {
            Pose _pose = hits[0].pose;
            var c = Instantiate(model, _pose.position, Quaternion.identity);
            canvasController = c.GetComponentInChildren<CanvasController>();
            _nubmeInstance = c.GetComponentInChildren<NubmeInstance>();
            c.GetComponentInChildren<LineMover>().SendMessage("GetVector", _pose.position);
            canvasController.CollapseVectors(_pose.position);
            _nubmeInstance.InstanceNums(_pose.position);
            //Debug.Log("number instance " + _nubmeInstance.ToString());
            //Debug.Log("co" + co);
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
