using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnButton : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject spawnerObject;
    public SpawnerPrefabsList spawnlist;
    Button button;
    Spawner spawner; 
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        spawner = spawnerObject.GetComponent<Spawner>();
    }
    void OnClick(){
        int index = spawnlist.selectedIndex;
        if(index > -1){
            spawner.SpawnObject(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
