using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class HighlightOnHover : MonoBehaviour
{
    // Start is called before the first frame update
    public XRBaseInteractable interactable;
    private Color tempColor;
    private Renderer renderer;
    void Awake(){
        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(this.OnHoverEntered);
        interactable.onHoverExited.AddListener(this.OnHoverExited);
        renderer = GetComponent<Renderer> ();
        tempColor = renderer.material.color;
    }
    public void OnHoverEntered(XRBaseInteractor interator){
     
     renderer.material.color = Color.red;
    }
    public void OnHoverExited(XRBaseInteractor interator){
        renderer.material.color = tempColor;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
