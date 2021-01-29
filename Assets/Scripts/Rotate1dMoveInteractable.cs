using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Rotate1dMoveInteractable : RotateInteractable
{
    // Start is called before the first frame update
    public float scaleMove = 1.0f;
    protected Vector3 startPosInterator;
    protected Vector3 startPos;
    new void Start()
    {
        base.Start();
        onSelectEntered.AddListener(onSelectEnter1);
        onSelectExited.AddListener(onSelectExited1);
    }
    void onSelectEnter1(XRBaseInteractor interator){
        startPosInterator = interator.transform.position;
        startPos = transform.position;
    }
    void onSelectExited1(XRBaseInteractor interator){
    }

    void UpdateMove(){
        if (isIntract){
            transform.position =startPos + Vector3.Scale((curInterator.transform.position - startPosInterator),-transform.up);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateRotate();
        UpdateMove();
    }
}
