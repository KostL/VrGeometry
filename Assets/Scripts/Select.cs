using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSelect;
    public Color onSelectColor;
    private Renderer rend;
    private Color tempColor;
    void Start()
    {
        rend = GetComponent<Renderer> ();
        tempColor = rend.material.color;
    }

    public void OnActivate(){
        isSelect = !isSelect;
        rend.material.color = isSelect ? onSelectColor : tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
