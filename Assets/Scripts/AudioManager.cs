using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    public string soundName; // Name of the sound
    public AudioClip clip;   // The audio clip to play
}

[System.Serializable]
public class MusicTrack
{
    public string trackName;  // Name of the music track
    public AudioClip clip;    // The music audio clip
}

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager instance;

    // List of sound effects and music tracks
    public List<SoundEffect> soundEffects = new List<SoundEffect>();
    public List<MusicTrack> musicTracks = new List<MusicTrack>();

    // Reference to the AudioSource for sound effects
    private AudioSource sfxAudioSource;

    // Reference to the AudioSource for music
    private AudioSource musicAudioSource;

    void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize audio sources
        sfxAudioSource = gameObject.AddComponent<AudioSource>(); // AudioSource for sound effects
        musicAudioSource = gameObject.AddComponent<AudioSource>(); // AudioSource for music
        musicAudioSource.loop = true; // Set music to loop
    }

    // Method to play a sound effect
    public void PlaySound(string soundName)
    {
        foreach (SoundEffect soundEffect in soundEffects)
        {
            if (soundEffect.soundName == soundName)
            {
                sfxAudioSource.PlayOneShot(soundEffect.clip);
                return;
            }
        }
        Debug.LogWarning("Sound not found: " + soundName);
    }

    // Method to play background music
    public void PlayMusic(string trackName)
    {
        foreach (MusicTrack musicTrack in musicTracks)
        {
            if (musicTrack.trackName == trackName)
            {
                musicAudioSource.clip = musicTrack.clip;
                musicAudioSource.loop = true;
                musicAudioSource.volume = 0.1f; 
                musicAudioSource.Play();
                return;
            }
        }
        Debug.LogWarning("Music track not found: " + trackName);
    }

    // Method to stop the music
    public void StopMusic()
    {
        musicAudioSource.Stop();
    }
}