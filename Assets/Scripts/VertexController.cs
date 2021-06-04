using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class VertexController : MonoBehaviour
{
    // Start is called before the first frame update
    public XRBaseInteractable interactable;
    public GeometyFigureController geometyFigureController;
    void Start()
    {
        geometyFigureController = transform.parent.GetComponent<GeometyFigureController>();
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(this.OnHoverEntered);
        interactable.onHoverExited.AddListener(this.OnHoverExited);
        interactable.onSelectEntered.AddListener(this.OnSelectEntered);
        interactable.onSelectExited.AddListener(this.OnSelectExited);
    }

    public void OnHoverEntered(XRBaseInteractor interator){
        geometyFigureController.OnHoverEnteredVertex(interator,gameObject);
    }
    public void OnHoverExited(XRBaseInteractor interator){
        geometyFigureController.OnHoverExitedVertex(interator,gameObject);
    }

    public void OnSelectEntered(XRBaseInteractor interator){
        geometyFigureController.OnSelectEnteredVertex(interator,gameObject);
    }
    public void OnSelectExited(XRBaseInteractor interator){
        geometyFigureController.OnSelectExitedVertex(interator,gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
