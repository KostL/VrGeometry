using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineContexMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button splitButton;
    public Button removeButton;
    public LineController lineController;
    void Start()
    {
        splitButton.onClick.AddListener(SplitButton_OnClick);
        removeButton.onClick.AddListener(RemoveButton_OnClick);
    }

    void SplitButton_OnClick(){
        lineController.SplitLine();
    }
    void RemoveButton_OnClick(){
        lineController.RemoveLine();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
