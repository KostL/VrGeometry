using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Painter : MonoBehaviour
{
    /// <summary>
    /// Brush color
    /// </summary>
    public Color32 penColor;

    public Transform rayOrigin;
    public float paintDistance = 0.1f;

    private RaycastHit hitInfo;
    //This brush is not being clutching the handle
    private bool IsGrabbing;
    private static DrawingBoard board;//Members to set type, rather than members of the type instance, as a board all brushes are made of the same

    private void Start()
    {
        //The brush member is provided to the color pen, the pen color for identifying
        foreach (var renderer in GetComponentsInChildren<MeshRenderer>())
        {
            if (renderer.transform == transform)
            {
                continue;
            }
            renderer.material.color = penColor;
        }
        if (!board)
        {
            board = FindObjectOfType<DrawingBoard>();
        }
      
    }

    private void Update()
    {
        Ray r = new Ray(rayOrigin.position, rayOrigin.forward);
        if (Physics.Raycast(r, out hitInfo, paintDistance))
        {
            if (hitInfo.collider.tag == "DrawingBoard")
            {
                
                //Provided corresponding to the position where brush picture slate UV coordinates 
                board.SetPainterPositon(hitInfo.textureCoord.x, hitInfo.textureCoord.y);
                //The current color of the pen
                board.SetPainterColor(penColor);
                board.IsDrawing = true;
                IsGrabbing = true;
            }
        }
        else if(IsGrabbing)
        {
            board.IsDrawing = false;
            IsGrabbing = false;
        }
    }

}