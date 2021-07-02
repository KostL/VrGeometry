using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskListController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> taskPrefabs;
    public List<Button> buttons;
    public Transform taskPos;
    public GameObject curTask;
    void Start()
    {
        buttons[0].onClick.AddListener(Button0Clicked);
        buttons[1].onClick.AddListener(Button1Clicked);
    }

    void Button0Clicked(){
        if (curTask != null){
            Destroy(curTask);
        }
           curTask = GameObject.Instantiate(taskPrefabs[0],taskPos);
           curTask.transform.localPosition = new Vector3(0,0,0);
    }
    void Button1Clicked(){
        if (curTask != null){
            Destroy(curTask);
        }
           curTask = GameObject.Instantiate(taskPrefabs[1],taskPos);
           curTask.transform.localPosition = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
