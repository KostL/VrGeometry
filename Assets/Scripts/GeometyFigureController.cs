using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


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
    public GameObject initLinePrefab; 
    public GameObject runtimeLinePrefab;
    public GameObject pointLinePrefab;
    void Start()
    {
        UpdateLines();
    }

    public static Vector3 GetWorldScale(Transform transform)
    {
        Vector3 worldScale = transform.localScale;
        Transform parent = transform.parent;
       
        while (parent != null)
        {
            worldScale = Vector3.Scale(worldScale,parent.localScale);
            parent = parent.parent;
        }
       
        return worldScale;
    }
    public void SetLineTrasform2points(GameObject lineObject,Vector3 point_1,Vector3 point_2){
            Vector3 linePos = (point_1 / 2) + (point_2 / 2);
            Vector3 heading = point_1 - point_2;
            var distance = heading.magnitude;
            var direction = heading / distance;

            lineObject.transform.position = linePos;
            lineObject.transform.right = direction;
            var parent_world_scale = GetWorldScale(lineObject.transform.parent.transform);
            lineObject.transform.localScale = new Vector3(distance / parent_world_scale.x,
                                                          lineObject.transform.localScale.y/ parent_world_scale.y,
                                                          lineObject.transform.localScale.z/ parent_world_scale.z);
    }

    public void AddLine(Transform vertex1, Transform vertex2){
        Line newLine = new Line();
        newLine.vertex_1 = vertex1;
        newLine.vertex_2 = vertex2;
        newLine.prefabInstance = GameObject.Instantiate<GameObject>(runtimeLinePrefab,transform);
        SetLineTrasform2points(newLine.prefabInstance,newLine.vertex_1.position,newLine.vertex_2.position);
        lines.Add(newLine);
    }
    public void RemoveLine(GameObject lineObject){
        int lineIndex = lines.FindIndex((Line line)=>line.prefabInstance==lineObject);
        Destroy(lines[lineIndex].prefabInstance);
        lines.RemoveAt(lineIndex);
    }
    void UpdateLines(){
        foreach (var line in lines){
            if(line.prefabInstance != null){
                GameObject.Destroy(line.prefabInstance);
            }
            line.prefabInstance = GameObject.Instantiate<GameObject>(initLinePrefab,transform);
            SetLineTrasform2points(line.prefabInstance,line.vertex_1.position,line.vertex_2.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isVertexSelected = false;
    private GameObject curVertexSelected;
    private GameObject curVertexHovered;
    private GameObject curLinePointer;
    private GameObject curInterator;
     public void OnHoverEnteredVertex(XRBaseInteractor interator,GameObject vertex){  //навелось на 2 вершину
         if(isVertexSelected && vertex != curVertexSelected){
             if(curLinePointer != null){
                 Destroy(curLinePointer);
                curLinePointer = null;
            }
            curVertexHovered = vertex;
            curLinePointer = GameObject.Instantiate<GameObject>(pointLinePrefab,transform);
            SetLineTrasform2points(curLinePointer,curVertexSelected.transform.position,curVertexHovered.transform.position);
         }

    }
    public void OnHoverExitedVertex(XRBaseInteractor interator,GameObject vertex){ //отпустить курок не на вернише
        if(isVertexSelected){
            curVertexHovered = null;
         }
        if(curLinePointer != null){
            Destroy(curLinePointer);
            curLinePointer = null;
        }
    }

    public void OnSelectEnteredVertex(XRBaseInteractor interator,GameObject vertex){ //выбрать и нажать
         if(vertex != curVertexSelected &&isVertexSelected){
            if(curLinePointer != null){
                Destroy(curLinePointer);
                curLinePointer = null;
            }
            AddLine(curVertexSelected.transform,vertex.transform);
            curVertexSelected = null;
            isVertexSelected = false;
            curVertexHovered = null;
            curInterator = null;
            return;
        }
        if(vertex == curVertexSelected && isVertexSelected){
            curVertexSelected = null;
            isVertexSelected = false;
            curVertexHovered = null;
            curInterator = null;
            return;
        }
        if(isVertexSelected == false){
            curVertexSelected = vertex;
            isVertexSelected = true;
            curInterator = interator.gameObject;

            return;
        }

    }
    public void OnSelectExitedVertex(XRBaseInteractor interator,GameObject vertex){
        


    }
}
