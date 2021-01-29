using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class MeshBlade : MonoBehaviour
{
    public Material capMaterial;
    public Transform reycastStartPos;
	public float lenght;
	private bool activated = false;
	public XRBaseInteractable xRBaseInteractable;
	private RaycastHit? _old_hit;
	// Use this for initialization
	void Awake (){
		xRBaseInteractable = GetComponent<XRBaseInteractable>();
		xRBaseInteractable.onActivate.AddListener(OnActivate);
		xRBaseInteractable.onDeactivate.AddListener(OnDeactivate);
	}
	void Start () {

		
	}
	public void OnActivate(XRBaseInteractor interator){
        activated = true;
        Debug.Log("Saber activate");
    }
	
    public void OnDeactivate(XRBaseInteractor interator){
        activated = false;
        Debug.Log("Saber deactivate");
    }
	void EnterRaycast(RaycastHit hit){
		Debug.Log("EnterRaycast");
	}
	void ExitRaycast(RaycastHit hit){
		Debug.Log("ExitRaycast");
		if (hit.collider.gameObject.tag == "VrActiveObject"){
				GameObject victim = hit.collider.gameObject;
                Debug.Log("Cut");
				GameObject[] pieces = MeshCut.Cut(victim, transform.position, -transform.right, capMaterial);
				pieces[1].AddComponent<MeshCollider>();
				pieces[1].GetComponent<MeshCollider>().convex = true;
				pieces[1].AddComponent<Rigidbody>();
				pieces[1].tag = "VrActiveObject";
				Destroy(pieces[1], 2);
        }
	}
	void UpdateRaycast(){
		RaycastHit hit;
			if(Physics.Raycast(reycastStartPos.position, reycastStartPos.forward, out hit)){
				Debug.DrawLine(reycastStartPos.position, hit.point);
				if (hit.distance < lenght){
					if(_old_hit == null){
						_old_hit = hit;
						EnterRaycast(hit);
					}
					if(_old_hit.Value.collider != hit.collider){
						ExitRaycast(_old_hit.Value);
						EnterRaycast(hit);
						_old_hit = hit;
				}
			}
			else{
				if(_old_hit != null){
					ExitRaycast(_old_hit.Value);
					_old_hit = null;
					Debug.Log("ExitRaycastNull");
				}
			}
			}
				
			else{
				if(_old_hit != null){
					ExitRaycast(_old_hit.Value);
					_old_hit = null;
					Debug.Log("ExitRaycastNull");
				}
			}
		}
	void Update(){
		if(activated){
			UpdateRaycast();
		}
		else{
			_old_hit = null;
		}
	}
}
