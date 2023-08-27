using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioMixerGroup soundEffectsMixerGroup;
	public static AudioManager instance;

	public Sound[] sounds;
	private string currSounds;
	private bool checker = false;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = soundEffectsMixerGroup;
		}
	}

    private void Update()
    {
		if (checker)
        {
			Sound s = Array.Find(sounds, item => item.name == currSounds);
			if (!s.source.isPlaying)
            {
				DialougeSystem.GetInstance().DisableTalkingAnimation();
				checker = false;
            }
        }
    }

    public void Play(string sound)
	{
		currSounds = sound;
		Sound s = Array.Find(sounds, item => item.name == sound);
		checker = true;
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();
	}

	public void Stop()
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i] != null)
			{
				sounds[i].source.Stop();
			}
		}
	}
}
