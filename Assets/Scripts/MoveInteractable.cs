using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class MoveInteractable : XRBaseInteractable
{
    // Start is called before the first frame update
    protected XRBaseInteractor curInterator;
    protected bool isIntract = false;
    protected Quaternion startInteratorRotation;
    protected Quaternion startRotation;
    protected Vector3 startPosInterator;
    protected Vector3 startPos;
    private Transform originalParent;
    void Start()
    {
        onSelectEntered.AddListener(onSelectEnter1);
        onSelectExited.AddListener(onSelectExited1);
        
    }
    void onSelectEnter1(XRBaseInteractor interator){
        originalParent = transform.parent;
        transform.parent = interator.transform;
        curInterator = interator;
        startPosInterator = interator.transform.position;
        startPos = transform.position;
        isIntract = true;
    }
    void onSelectExited1(XRBaseInteractor interator){
        isIntract = false;
        transform.parent = originalParent;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
