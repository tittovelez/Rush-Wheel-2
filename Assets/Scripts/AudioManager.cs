using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
        ApplySavedVolumes();
    }

    void ApplySavedVolumes()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        audioMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
    }
}

