using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineContexMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button split2Button;
    public Button split3Button;
    public Button removeButton;
    public LineController lineController;
    void Start()
    {
        split2Button.onClick.AddListener(Split2Button_OnClick);
        split3Button.onClick.AddListener(Split3Button_OnClick);
        removeButton.onClick.AddListener(RemoveButton_OnClick);
    }

    void Split2Button_OnClick(){
        lineController.Split2Line();
    }
    void Split3Button_OnClick(){
        lineController.Split3Line();
    }
    void RemoveButton_OnClick(){
        lineController.RemoveLine();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
