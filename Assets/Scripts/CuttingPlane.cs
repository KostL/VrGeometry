using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingPlane : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cutedObject;
    public Vector2 size_padding = new Vector2(0.1f,0.1f);
    private Renderer cutedObjectRend;
    private bool isColide = true;
    void Start()
    { 
       cutedObjectRend  = cutedObject.GetComponent<Renderer>();
       Vector3 boudSize = cutedObjectRend.bounds.size;
       transform.localScale = new Vector3(boudSize.x+size_padding.x,transform.localScale.y,boudSize.z+size_padding.y);

    }

    public void Cut(){
        Debug.Log("Cut");
        if(!isColide){
            return;
        }
                Debug.Log("Cut");
				GameObject[] pieces = MeshCut.Cut(cutedObject, transform.position, -transform.up, cutedObjectRend.material);
				cutedObject = pieces[0];
                pieces[1].AddComponent<MeshCollider>();
				pieces[1].GetComponent<MeshCollider>().convex = true;
				pieces[1].AddComponent<Rigidbody>();
				pieces[1].tag = "VrActiveObject";
				Destroy(pieces[1], 1);
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision collision){
        Debug.Log("Cutting plane colide");
        if(collision.gameObject == cutedObject){
            isColide = true;
        }
    }
    void OnCollisionExit(Collision collision){
        Debug.Log("Cutting plane colide exit");
        if(collision.gameObject == cutedObject){
            isColide = false;
        }
    }
    void Update()
    {
       float clampX =  Mathf.Clamp(transform.position.x,cutedObjectRend.bounds.min.x,cutedObjectRend.bounds.max.x);
       float clampY =  Mathf.Clamp(transform.position.y,cutedObjectRend.bounds.min.y,cutedObjectRend.bounds.max.y);
       float clampZ =  Mathf.Clamp(transform.position.z,cutedObjectRend.bounds.min.z,cutedObjectRend.bounds.max.z);
       transform.position = new Vector3(clampX,clampY,clampZ);
    }
}
