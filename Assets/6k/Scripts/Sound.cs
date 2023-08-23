using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public enum AudioTypes { soundEffect, music };
	public AudioTypes audioTypes;

	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = .75f;

	public bool loop = false;

	public AudioMixerGroup mixerGroup;

	[HideInInspector]
	public AudioSource source;

}
