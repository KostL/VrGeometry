using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineController : MonoBehaviour
{
    public XRBaseInteractable interactable;
    public GameObject contexMenuPrefab;
    GameObject mainCamera;
    GameObject contexMenuCur;
    public GeometyFigureController geometyFigureController;
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
        geometyFigureController.SplitLine(gameObject);
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
