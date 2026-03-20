using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] // crea uno slider nell'inspector
    public float volume = 0.7f;

    [Range(0.1f, 3f)] // crea uno slider nell'inspector
    public float pitch = 1;
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance; //riferimento statico, accessibile da ovunque, senza trascinare la reference

    public Sound[] musicSounds;
    public Sound[] sfxSounds;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(string name)
    {
        foreach (Sound s in musicSounds)
        {
            if (s.name == name)
            {
                musicSource.clip = s.clip;
                musicSource.volume = s.volume;
                musicSource.pitch = s.pitch;
                musicSource.Play();
                return;
            }
        }
        Debug.LogWarning("Musica non trovata: " + name);
    }

    public void PlaySFX(string name)
    {
        foreach (Sound s in sfxSounds)
        {
            if (s.name == name)
            {
                sfxSource.pitch = s.pitch;
                sfxSource.PlayOneShot(s.clip, s.volume);
                return;
            }
        }
        Debug.LogWarning("SFX non trovato: " + name);
    }

}
