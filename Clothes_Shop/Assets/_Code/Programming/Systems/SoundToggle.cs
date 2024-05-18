using UnityEngine;
using UnityEngine.Audio;

public class SoundToggle : MonoBehaviour
{
    public AudioMixerGroup sFXMixer, bGMMixer;
    
    public void ToggleSFX()
    {
        float volume;
        sFXMixer.audioMixer.GetFloat("SFX", out volume);

        if (volume < 0) sFXMixer.audioMixer.SetFloat("SFX", 0);
        else sFXMixer.audioMixer.SetFloat("SFX", -100);   
    }


    public void ToggleBGM()
    {
        float volume;
        bGMMixer.audioMixer.GetFloat("BGM", out volume);

        if (volume < 0) bGMMixer.audioMixer.SetFloat("BGM", 0);
        else bGMMixer.audioMixer.SetFloat("BGM", -100);
    }
}