using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorMoveEmulator : MonoBehaviour
{
#if UNITY_EDITOR
    // Start is called before the first frame update
    public Vector2 speedRotate =  new Vector2(0.5f,0.5f);
    public Vector2 speedMove =  new Vector2(2.0f,2.0f);
    public float height = 1.5f;
    private Vector2 _curMoveDir;
    private Vector2 _curLookDir;
    private bool _rotateTurnedOn = false;
    private VrLessControls _vrLessControls;

    void Awake(){
        _vrLessControls = new VrLessControls();
        _curLookDir = new Vector2(transform.localEulerAngles.x,transform.localEulerAngles.y);
    }

    void OnEnable(){
        _vrLessControls.Enable();
    }
    void OnDisable(){
        _vrLessControls.Disable();
    }

    // Use this for initialization

    void Start()
    {
        
        _curLookDir = new Vector2(transform.forward.x,transform.forward.y);
        return;
    }

    // Update is called once per frame
    void Update()
    {
      _curMoveDir = _vrLessControls.EditorDebug.Move.ReadValue<Vector2>();
      if(_rotateTurnedOn){
        Vector2 mouseVector = _vrLessControls.EditorDebug.Look.ReadValue<Vector2>();
       _curLookDir += new Vector2(-mouseVector.y*speedRotate.x*Time.deltaTime,mouseVector.x*speedRotate.y*Time.deltaTime);
        }
        _rotateTurnedOn = _vrLessControls.EditorDebug.RotateTurnOn.ReadValue<float>() > 0;
    
    transform.position = new Vector3(transform.position.x,height,transform.position.z);
    transform.Translate(Vector3.forward * _curMoveDir.y*Time.deltaTime*speedMove.y);
    transform.Translate(Vector3.right * _curMoveDir.x*Time.deltaTime*speedMove.x);
    transform.localRotation = Quaternion.Euler(_curLookDir.x,_curLookDir.y,0.0f);

    }
    #endif
}
