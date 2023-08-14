using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip>();
    public AudioSource audioSource;
    //Refernce to audio source

    public AudioClip goodAudioClip;
    public AudioClip badAudioclip;
    public AudioClip consecutiveAudioClip;
    public AudioClip gameoverAudioClip;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Fill in the data to the dictionary
        soundEffects.Add(key: "Good", goodAudioClip);
        soundEffects.Add(key: "Bad", badAudioclip);
        soundEffects.Add(key: "Consecutive", consecutiveAudioClip);
        soundEffects.Add(key: "GameOver", gameoverAudioClip);
    }
    public void PlaySoundEffect(string key)
    {// check if key exists
        if (soundEffects.ContainsKey(key))
        {
            //play sound effects
            audioSource.clip = soundEffects[key];
            audioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
