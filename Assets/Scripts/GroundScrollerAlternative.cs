using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float bgspeed;
    public Renderer bgRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset = new Vector2(bgspeed * Time.time, 0f);
    }
}
