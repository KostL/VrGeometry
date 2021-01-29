using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpawnerPrefabsList : MonoBehaviour
{
    // Start is called before the first frame update
    public Spawner spawner;
    public RawImage rawImagePrefab;
    [HideInInspector]
    public int selectedIndex{
        get{
            return imageList.FindIndex(
                (RawImage rawImage) => rawImage.gameObject == EventSystem.current.currentSelectedGameObject);
        }
    }
    public Color backgroundImageColor;
    private List<RawImage> imageList;
    private SnapshotCamera snapshotCamera;
    private Texture2D texture;
    private ToggleGroup  toggleGroup;
    void Start()
    {
        snapshotCamera = SnapshotCamera.MakeSnapshotCamera("SnapshotLayer");
        toggleGroup = GetComponent<ToggleGroup>();
        Populate();
        
    }

    void Populate()
	{
        RawImage newImage;
        imageList = new List<RawImage>();
		foreach(GameObject prefab in spawner.spawnPrefabsList){
            newImage = (RawImage)Instantiate(rawImagePrefab,transform);
            newImage.texture = snapshotCamera.TakePrefabSnapshot(
                prefab,backgroundImageColor,positionOffset:snapshotCamera.defaultPositionOffset,rotation: Quaternion.Euler(snapshotCamera.defaultRotation + prefab.transform.rotation.eulerAngles),scale:prefab.transform.localScale*2);
            newImage.gameObject.GetComponent<Button>().onClick.AddListener(onClickImage);
            //newImage.gameObject.GetComponent<Toggle>().group = toggleGroup;
            imageList.Add(newImage);
        }

	}
    void onClickImage(){
        spawner.SpawnObject(selectedIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
