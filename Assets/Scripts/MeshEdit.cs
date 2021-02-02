using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEdit : MonoBehaviour
{
    // Start is called before the first frame update Mesh oMesh;
    Mesh oMesh;
    Mesh cMesh;
    MeshFilter oMeshFilter;
    int[] triangles;

    [HideInInspector]
    public Vector3[] vertices;

    [HideInInspector]
    public List<GameObject> selectedEditPoints{
        get{
            List<GameObject> list = new List<GameObject>();
                foreach(var editPoint in editPoints){
                     if(editPoint.Key.GetComponent<Select>().isSelect){
                         list.Add(editPoint.Key);
                     }
                }
            return list;
        }
    }

    [HideInInspector]
    public bool isCloned = false;

    public GameObject editPointPrefab;
    private List<KeyValuePair<GameObject,int>> editPoints;
    void Start()
    {
        editPoints = new List<KeyValuePair<GameObject,int>>();
        InitMesh();
        //createEditPoints();
        
    }
    public void DestroyEitPoints(){
        foreach(var pair in editPoints){
            Destroy(pair.Key);
        }

        editPoints.Clear();
    }
    public void createEditPoints(){
        InitMesh();
        List<int> uniqueVertices = new List<int>();
        List<int> delVertices = new List<int>();
        
        for (int i = 0; i < vertices.Length; i++)
        {
            if (delVertices.FindIndex(0,(int d)=> d==i) < 0){
            List<int> relatedVertices = FindRelatedVertices(vertices[i], false);
            uniqueVertices.Add(relatedVertices[0]);
            relatedVertices.RemoveAt(0);
            delVertices.AddRange(relatedVertices);
            }
        }

        for (int i = 0; i < uniqueVertices.Count; i++)
        {
             GameObject newObj;
             Vector3 point = transform.TransformPoint(vertices[uniqueVertices[i]]);
             newObj = Instantiate<GameObject>(editPointPrefab,point,editPointPrefab.transform.rotation);
             newObj.transform.parent = transform;
             editPoints.Add(new KeyValuePair<GameObject, int>(newObj,uniqueVertices[i]));
        }
    }
    public void InitMesh()
    {
        oMeshFilter = GetComponent<MeshFilter>();
        oMesh = oMeshFilter.sharedMesh;

        cMesh = new Mesh();
        cMesh.name = "clone";
        cMesh.vertices = oMesh.vertices;
        cMesh.triangles = oMesh.triangles;
        cMesh.normals = oMesh.normals;
        cMesh.uv = oMesh.uv;
        cMesh.RecalculateNormals();
        oMeshFilter.mesh = cMesh;

        vertices = cMesh.vertices;
        triangles = cMesh.triangles;
        isCloned = true;
        Debug.Log("Init & Cloned");
    }


    public void Reset()
    {
        if (cMesh != null && oMesh != null)
        {
            cMesh.vertices = oMesh.vertices;
            cMesh.triangles = oMesh.triangles;
            cMesh.normals = oMesh.normals;
            cMesh.uv = oMesh.uv;
            oMeshFilter.mesh = cMesh;
            // update local vars..
            vertices = cMesh.vertices;
            triangles = cMesh.triangles;
        }
    }



    public void DoAction(int index, Vector3 localPos)
    {
        // specify methods here
        // PullOneVertex (index, localPos);
        PullSimilarVertices(index, localPos);
    }


    // returns List of int that is related to the targetPt.
    private List<int> FindRelatedVertices(Vector3 targetPt, bool findConnected)
    {
        // list of int
        List<int> relatedVertices = new List<int>();

        int idx = 0;
        Vector3 pos;

        // loop through triangle array of indices
        for (int t = 0; t < triangles.Length; t++)
        {
            // current idx return from tris
            idx = triangles[t];
            // current pos of the vertex
            pos = vertices[idx];
            // if current pos is same as targetPt
            if (pos == targetPt)
            {
                // add to list
                relatedVertices.Add(idx);
                // if find connected vertices
                if (findConnected)
                {
                    // min 
                    // - prevent running out of count
                    if (t == 0)
                    {
                        relatedVertices.Add(triangles[t + 1]);
                    }
                    // max 
                    // - prevent runnign out of count
                    if (t == triangles.Length - 1)
                    {
                        relatedVertices.Add(triangles[t - 1]);
                    }
                    // between 1 ~ max-1 
                    // - add idx from triangles before t and after t 
                    if (t > 0 && t < triangles.Length - 1)
                    {
                        relatedVertices.Add(triangles[t - 1]);
                        relatedVertices.Add(triangles[t + 1]);
                    }
                }
            }
        }
        // return compiled list of int..
        return relatedVertices;
    }


    // Pulling only one vertex pt, results in broken mesh.
    private void PullOneVertex(int index, Vector3 newPos)
    {
        vertices[index] = newPos;
        cMesh.vertices = vertices;
        cMesh.RecalculateNormals();
    }


    private void PullSimilarVertices(int index, Vector3 newPos)
    {
        Vector3 targetVertexPos = vertices[index];
        List<int> relatedVertices = FindRelatedVertices(targetVertexPos, false);
        foreach (int i in relatedVertices)
        {
            vertices[i] = newPos;
        }
        cMesh.vertices = vertices;
        cMesh.RecalculateNormals();
    }
    void Update(){
        foreach(var pair in editPoints){
            DoAction(pair.Value,transform.InverseTransformPoint(pair.Key.transform.position));
        }
    }

}
