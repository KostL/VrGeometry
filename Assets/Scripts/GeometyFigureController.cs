using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Line{
    public Transform vertex_1;
    public Transform vertex_2;
     [HideInInspector]
    public GameObject prefabInstance;
}
public class GeometyFigureController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Line> lines;
    public GameObject linePrefab;
    void Start()
    {
        UpdateLines();
    }

    void UpdateLines(){
        foreach (var line in lines){
            if(line.prefabInstance != null){
                GameObject.Destroy(line.prefabInstance);
            }
            Vector3 linePos = (line.vertex_1.position / 2) + (line.vertex_2.position / 2);
            Vector3 heading = line.vertex_1.position - line.vertex_2.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            line.prefabInstance = GameObject.Instantiate<GameObject>(linePrefab,linePos,linePrefab.transform.rotation,transform);
            line.prefabInstance.transform.right = direction;
            line.prefabInstance.transform.localScale = new Vector3(distance,
                                                                   line.prefabInstance.transform.localScale.y,
                                                                   line.prefabInstance.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
