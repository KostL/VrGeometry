using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineController : MonoBehaviour
{
    public XRBaseInteractable interactable;
    public GeometyFigureController geometyFigureController;
    // Start is called before the first frame update

    void Awake(){

    }
    void Start()
    {
        geometyFigureController = transform.parent.GetComponent<GeometyFigureController>();
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onSelectEntered.AddListener(this.OnSelectEntered);
        interactable.onSelectExited.AddListener(this.OnSelectExited);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectEntered(XRBaseInteractor interator){
        geometyFigureController.RemoveLine(gameObject);
    }
    public void OnSelectExited(XRBaseInteractor interator){
    }
}
