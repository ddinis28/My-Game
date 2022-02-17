using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

	// Use this for initialization
	void Awake () {

        if (instance == null)
            instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
           

            DontDestroyOnLoad(gameObject);

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop; 
        }
	}

    private void Start()
    {
        Play("intro");
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
