using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleColorSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    public Color checkedColor;
    public Color unCheckedColor;
    private Toggle toggle;
    private RawImage rawImage;
    void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
        rawImage = gameObject.GetComponent<RawImage>();
        toggle.onValueChanged.AddListener(toggleValueChanged);
    }

    void toggleValueChanged(bool val){
        rawImage.color = val ? checkedColor:unCheckedColor;
    }   
    // Update is called once per frame
    void Update()
    {
        
    }
}
