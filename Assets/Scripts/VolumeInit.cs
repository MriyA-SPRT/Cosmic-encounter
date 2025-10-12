using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter,  -80f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }

}
