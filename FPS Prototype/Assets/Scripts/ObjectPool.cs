using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objPrefab;
    public int createOnStart;
    private List<GameObject> pooledObj = new List<GameObject>();
    
    void Start() 
    {
        for(int i = 0; i < createOnStart; i++) 
        {
            CreateNewObject();
        }
    }

    GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        pooledObj.Add(obj);
    
        return obj;
    }

    public GameObject GetObject()
    {
        GameObject obj = pooledObj.Find(x => x.activeInHierarchy == false);
        
        if(obj == null)
        {
            obj = CreateNewObject();
        }
        obj.SetActive(true);

        return obj;
    }
}