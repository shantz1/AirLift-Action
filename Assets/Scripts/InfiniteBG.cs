using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBG : MonoBehaviour
{
    //public GameObject[] backgrounds;
    //private Camera mainCamera;
    //private Vector2 screenBounds;


    public float speed = 0;

    void Start()
    {
        //mainCamera = GetComponent<Camera>();
        //screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        //foreach (GameObject obj in backgrounds)
        //{
        //    LoadChildObject(obj);
        //}
    }


    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }


    //void LoadChildObject(GameObject obj)
    //{
    //    float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
    //    int childWant = (int)Mathf.Ceil(screenBounds.x * 2/ objectWidth);
    //    GameObject clone = Instantiate(obj) as GameObject;
    //    for (int i = 0; i <= childWant; i++)
    //    {
    //        GameObject c = Instantiate(clone) as GameObject;
    //        c.transform.SetParent(obj.transform);
    //        c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
    //        c.name = obj.name + i;
    //    }
    //    Destroy(clone);
    //    Destroy(obj.GetComponent<SpriteRenderer>());
    //    Destroy(obj.GetComponent<PolygonCollider2D>());
    //}


}
