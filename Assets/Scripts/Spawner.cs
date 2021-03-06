using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> spawnPrefabsList;
    public GameObject editPointPrefab;
    public GameObject cuttingPlanePrefab;
    private GameObject curObject;
    private List<GameObject> cuttingPlaneList;
    private int curIndex;
    public void SpawnObject(int index){
        DestroyCuttinPlanes();
        if(curObject != null){
            Destroy(curObject);
        }
        Debug.Log("Spwan"+index+" object!");
        curObject = (GameObject)Instantiate(spawnPrefabsList[index],transform.position,spawnPrefabsList[index].transform.rotation,transform);
        var meshEdit = curObject.GetComponent<MeshEdit>();
        if(meshEdit != null){
            meshEdit.editPointPrefab = editPointPrefab;
        }
        curIndex = index;
    }
    public void ResetObject(){
        Debug.Log("Reset object!");
        if(curObject != null){
            Destroy(curObject);
            SpawnObject(curIndex);
        }
    }

    public void ShowEditPoints(){
        var meshEdit = curObject.GetComponent<MeshEdit>();
        if(meshEdit != null){
            meshEdit.createEditPoints();
        }
    }
    public void HideEditPoints(){
        var meshEdit = curObject.GetComponent<MeshEdit>();
        if(meshEdit != null){
            meshEdit.DestroyEitPoints();
        }
    }
    
   public void DestroyCuttinPlanes(){
        foreach(GameObject cuttingPlane in cuttingPlaneList){
            Destroy(cuttingPlane);
        }
        cuttingPlaneList.Clear();
    }
    public void AddCuttingPlane(){
        if(curObject != null){
        GameObject newObj = Instantiate<GameObject>(cuttingPlanePrefab,transform.position,new Quaternion(0,0,0,0),transform);
        newObj.GetComponent<CuttingPlane>().cutedObject = curObject;
        newObj.GetComponent<CuttingPlane>().reference_points = curObject.GetComponent<MeshEdit>().selectedEditPoints;
        cuttingPlaneList.Add(newObj);
        }
    }
    public void CutByAllCuttingPlane(){
        foreach(GameObject cuttingPlane in cuttingPlaneList){
            cuttingPlane.GetComponent<CuttingPlane>().Cut();
        }
    }

    void Start()
    {
        cuttingPlaneList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
