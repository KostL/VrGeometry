using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> spawnPrefabs;
    private GameObject curObject;
    private int curIndex;
    public void SpawnObject(int index){
        if(curObject != null){
            Destroy(curObject);
        }
        Debug.Log("Spwan"+index+" object!");
        curObject = (GameObject)Instantiate(spawnPrefabs[index],transform.position,transform.rotation,transform);
        curIndex = index;
    }
    public void RestObject(){
        Debug.Log("Reset object!");
        if(curObject != null){
            Destroy(curObject);
            SpawnObject(curIndex);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
