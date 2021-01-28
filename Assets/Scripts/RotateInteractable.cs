using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateInteractable : XRBaseInteractable
{
    // Start is called before the first frame update
    public float rotateScale = 1.0f;
    private XRBaseInteractor curInterator;
    private bool isIntract = false;
    private Quaternion startInteratorRotation;
    private Quaternion startRotation;
    private Vector3 _oldRotate;
    void Start()
    {
        onSelectEntered.AddListener(onSelectEnter1);
        onSelectExited.AddListener(onSelectExited1);
    }
    void onSelectEnter1(XRBaseInteractor interator){
        curInterator = interator;
        isIntract = true;
        startInteratorRotation = interator.transform.rotation;
        startRotation = transform.rotation;
        _oldRotate = calcOffsteRotate().eulerAngles;
    }
    void onSelectExited1(XRBaseInteractor interator){
        isIntract = false;
    }
    // Update is called once per frame
    Quaternion calcOffsteRotate(){
        return Quaternion.Euler(curInterator.transform.rotation.eulerAngles - startInteratorRotation.eulerAngles);
    }
    void Update()
    {
        if (isIntract){
            Quaternion rotate = calcOffsteRotate();
            transform.RotateAround(transform.position,Vector3.up,(_oldRotate.y - rotate.eulerAngles.y) * rotateScale);
            transform.RotateAround(transform.position,Vector3.forward,(_oldRotate.z - rotate.eulerAngles.z) * rotateScale);
            transform.RotateAround(transform.position,Vector3.left,(_oldRotate.x - rotate.eulerAngles.x) * rotateScale);
            _oldRotate = rotate.eulerAngles;
        }
        else {
            
        }
        
    }
}
