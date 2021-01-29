using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateInteractable : XRBaseInteractable
{
    // Start is called before the first frame update
    public float rotateScale = 1.0f;
    protected XRBaseInteractor curInterator;
    protected bool isIntract = false;
    protected Quaternion startInteratorRotation;
    protected Quaternion startRotation;
    protected Vector3 _oldRotate;
   protected void Start()
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

 protected  void UpdateRotate(){
                if (isIntract){
            Quaternion rotate = calcOffsteRotate();
            transform.Rotate(curInterator.transform.up,(_oldRotate.y - rotate.eulerAngles.y) * rotateScale, Space.World);
            transform.Rotate(curInterator.transform.forward,(_oldRotate.z - rotate.eulerAngles.z) * rotateScale, Space.World);
            transform.Rotate(curInterator.transform.right,(_oldRotate.x -rotate.eulerAngles.x) * rotateScale, Space.World);
            _oldRotate = rotate.eulerAngles;
        }
        else {
            
        }
    }
    void Update()
    {
        UpdateRotate();
        
    }
}
