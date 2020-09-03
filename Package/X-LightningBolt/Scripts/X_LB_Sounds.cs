using UnityEngine;
using System.Collections;

public class X_LB_Sounds : MonoBehaviour {

	public AudioClip soundImpact;
	public AudioClip[] soundsFlicker;

	public AudioSource soundStreamHigh;
	public AudioSource soundStreamLow;

	AudioSource sound;

	public void Init(AudioSource sound) {
		this.sound = sound;
	}

	public void PlaySound(AudioClip clip) {
		sound.clip = clip; 
		sound.pitch = PitchFlicker();
		sound.Play();
	}

	public void PlayRandomSound(AudioClip[] randomClip) {
		if (randomClip.Length == 0)
			return;
		sound.clip = randomClip[Random.Range (0,randomClip.Length)]; 
		sound.pitch = PitchFlicker();
		sound.Play();
	}

	public void PlayStreamSound() {
		if (soundStreamHigh.isPlaying == false) {
			soundStreamHigh.Play ();
		}
		if (soundStreamLow.isPlaying == false) {
			soundStreamLow.Play ();
		}
	}

	public void BalanceStreamSound (float branchAmount) {
		soundStreamLow.volume = 1 - branchAmount / 50f;
		soundStreamHigh.volume = (branchAmount / 50f);
	}

	public void PitchStreamSound(float flickeringStrength) {
		soundStreamLow.pitch = 1 + ((flickeringStrength-2.5f) / 10f);
		soundStreamHigh.pitch = 1 + ((flickeringStrength-2.5f) / 10f);
	}

	public void StopStreamSound() {
		soundStreamHigh.Stop ();
		soundStreamLow.Stop ();
	}

	float PitchFlicker() {
		return (1 + Random.Range(-0.2f,0.2f));
	}

}