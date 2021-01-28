using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ShowBladeOnActivate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blade;
    public XRBaseInteractable xRBaseInteractable;
	void Awake (){
		xRBaseInteractable = GetComponent<XRBaseInteractable>();
		xRBaseInteractable.onActivate.AddListener(OnActivate);
		xRBaseInteractable.onDeactivate.AddListener(OnDeactivate);
    }
    void Start()
    {
        blade.SetActive(false);
    }

    public void OnActivate(XRBaseInteractor interator){
        blade.SetActive(true);
        Debug.Log("Blade activate");
    }
	
    public void OnDeactivate(XRBaseInteractor interator){
        blade.SetActive(false);
        Debug.Log("Blade deactivate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
