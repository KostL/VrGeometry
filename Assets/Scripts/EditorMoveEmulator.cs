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

    private Vector2 _curMoveDir = new Vector2(0,0);
    private Vector2 _curLookDir = new Vector2(0,0);
    private bool _rotateTurnedOn = false;
    private VrLessControls _vrLessControls;

    void Awake(){
        _vrLessControls = new VrLessControls();
        
    }

    void OnEnable(){
        _vrLessControls.Enable();
    }
    void OnDisable(){
        _vrLessControls.Disable();
    }

    // Use this for initialization


    public void OnRatateTurnOn(InputAction.CallbackContext inputCntx){
        
    }
    void Start()
    {

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
    
    transform.position = new Vector3(transform.position.x,1.5f,transform.position.z);
    transform.Translate(Vector3.forward * _curMoveDir.y*Time.deltaTime*speedMove.y);
    transform.Translate(Vector3.right * _curMoveDir.x*Time.deltaTime*speedMove.x);
    transform.rotation = Quaternion.Euler(_curLookDir.x,_curLookDir.y,0.0f);

    }
    #endif
}
