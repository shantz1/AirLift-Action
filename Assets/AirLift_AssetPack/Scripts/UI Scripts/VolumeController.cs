using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the slider UI element
    public AudioMixer audioMixer; // Reference to the audio mixer you want to control the volume of
    public string mixerGroup; // The name of the mixer group you want to control the volume of
    public GameObject sliderPanel; // Reference to the slider panel UI element
   

    void Start()
    {
        PanelDisable();



        float volume;
        audioMixer.GetFloat(mixerGroup + "MasterVolume", out volume); // Get the current volume of the mixer group
        volumeSlider.value = Mathf.Pow(10f, volume / 20f); // Convert the volume from decibels to linear and set the initial value of the slider

        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); }); // Attach an event listener to the slider so we can update the volume when it's changed

    
    }
    private void Update()
    {
        OnVolumeChanged();
    }
    public void OnVolumeChanged()
    {
        float volume = Mathf.Log10(volumeSlider.value) * 20f; // Convert the linear value of the slider to decibels
        audioMixer.SetFloat(mixerGroup + "Volume", volume); // Set the volume of the mixer group
    }

  
    public void Panelenable()
    {
        sliderPanel.SetActive(true);
    }

    public void PanelDisable()
    {
        sliderPanel.SetActive(false);
    }



}
