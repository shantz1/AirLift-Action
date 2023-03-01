using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    public AudioClip click;
    public AudioClip bikeCollision;
    public AudioClip Truck;
    public AudioClip reload;
    public AudioClip gameOver;
    public AudioClip bulletHit;
    public AudioClip healthGain;
    

   public void PlaySound(AudioClip clipName )
    {
        AudioSource.PlayClipAtPoint(clipName, Camera.main.transform.position);
    }
}
