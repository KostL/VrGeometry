using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XrHighlighter : MonoBehaviour
{
    // Start is called before the first frame update
    public XRBaseInteractable interactable;
    public Color HoverColor;
    public Color SelectColor;
    public Color ActivateColor;
    private Color InitColor;
    private Renderer _renderer;
    void Awake(){
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(this.OnHoverEntered);
        interactable.onHoverExited.AddListener(this.OnHoverExited);
        interactable.onSelectEntered.AddListener(this.OnSelectEntered);
        interactable.onSelectExited.AddListener(this.OnSelectExited);
        _renderer = GetComponent<Renderer> ();
        InitColor = _renderer.material.color;
    }
    public void OnHoverEntered(XRBaseInteractor interator){
     if(HoverColor != null){
        _renderer.material.color = HoverColor;
     }
    }
    public void OnHoverExited(XRBaseInteractor interator){
        _renderer.material.color = InitColor;
    }
    public void OnSelectEntered(XRBaseInteractor interator){
     if(SelectColor != null){
     _renderer.material.color = SelectColor;
     }
    }
    public void OnSelectExited(XRBaseInteractor interator){
        _renderer.material.color = InitColor;
    }

    public void OnActivateEntered(XRBaseInteractor interator){
     
     if(ActivateColor != null){
         _renderer.material.color = ActivateColor;
     }
    }
    public void OnActivateExited(XRBaseInteractor interator){
        _renderer.material.color = InitColor;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
