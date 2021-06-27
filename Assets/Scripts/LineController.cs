using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineController : MonoBehaviour
{
    public XRBaseInteractable interactable;
    public GameObject contexMenuPrefab;
    public Transform rayCastStart;
    public Transform rayCastEnd;
    GameObject mainCamera;
    GameObject contexMenuCur;
    public GeometyFigureController geometyFigureController;
    private RaycastHit hitInfo;
    // Start is called before the first frame update

    void Awake(){

    }
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        geometyFigureController = transform.parent.GetComponent<GeometyFigureController>();
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onSelectEntered.AddListener(this.OnSelectEntered);
        interactable.onSelectExited.AddListener(this.OnSelectExited);
        ChekRayCast();
    }

    void ChekRayCast(){
        Vector3 heading = (rayCastEnd.position - rayCastStart.position);
        var distance = heading.magnitude;
        var direction = heading / distance;
        Ray r = new Ray(rayCastStart.position, direction);
        if(distance < 0.05){
            return;
        }
        GetComponent<Collider>().enabled = false;
        if (Physics.Raycast(r, out hitInfo, distance-distance/5))
        {
            Debug.Log(hitInfo.transform.gameObject.name);
            Debug.Log(distance);
            Debug.Log(hitInfo.point);
            Debug.Log(direction);
            geometyFigureController.SplitLineIntersect(gameObject,hitInfo.transform.gameObject,hitInfo.point);
            
        }
        GetComponent<Collider>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowContexMenu(Vector3 pos, Vector3 forward){
        HideContexMenu();
        contexMenuCur = GameObject.Instantiate(contexMenuPrefab);
        contexMenuCur.GetComponent<LineContexMenuController>().lineController = this;
        contexMenuCur.GetComponent<Canvas>().worldCamera = Camera.main;
        contexMenuCur.transform.position = pos;
        contexMenuCur.transform.forward = forward;
        contexMenuCur.transform.position += forward * (-0.01f);
    }

    public void HideContexMenu(){
        if(contexMenuCur != null){
           Destroy(contexMenuCur);
           contexMenuCur = null;
        }
    }

    public void RemoveLine(){
        HideContexMenu();
        geometyFigureController.RemoveLine(gameObject);
    }

    public void SplitLine(){
        HideContexMenu();
        geometyFigureController.SplitLine(gameObject,transform.position);
        Debug.Log("Split");
    }

    public void OnSelectEntered(XRBaseInteractor interator){
        foreach(var line in geometyFigureController.lines){
            line.prefabInstance.GetComponent<LineController>().HideContexMenu();
        }
        ShowContexMenu( transform.position,mainCamera.transform.forward);
    }
    public void OnSelectExited(XRBaseInteractor interator){
    }
}
