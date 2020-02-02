using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioStuff
{
  public enum Sounds
  {
    Sound1 = 0,

    TurnAround,
  

    Hit1,
    Hit2,


    None, // TODO: NO SERIOUSLY, WHY IS THIS HERE? SHOULDN't IT BE None = 0?
          // Don't just delete the comment, leave a new one explaining why.

    Music1,
    MenuMusic,
   
    Ambient1,
   
    Explosion,


    Length // Size of the enum
  };
}

public class AudioManager : MonoBehaviour
{
  private static AudioManager instance;
  private static AudioSource s_musicAudioSource;
  private static AudioSource s_bgMusicAudioSource;
  private static AudioSource s_ambientAudioSource;
  private static AudioSource s_EffectsAudioSource;
  private static AudioClip[] s_Sounds = new AudioClip[(int)AudioStuff.Sounds.Length];


  public float reduceMusicPitchTo = 0.8f;
  public float reducebgMusicPitchTo = 0.8f;
  public float reduceEffectsPitchTo = 0.8f;
  public float incrementMusicPitchTo = 1.1f;
  public float incrementbgMusicPitchTo = 1.1f;
  public float incrementEffectsPitchTo = 1.1f;
  public float normalMusicPitch = 1;
  public float normalBGMusicPitch = 1;
  public float normalEffectsPitch = 1;
  public float pitchSpeedChange = 4;
  public float normalMusicVolume = .125f;
  public float normalBGMusicVolume = .125f;
  public float normalEffectsVolume = .125f;
  public float reduceMusicVolumeTo = 0.05f;
  public float reduceEffectsVolumeTo = 0.05f;
  public float volumeSpeedChange = 4;

  void Awake()
  {
    AudioSource[] audioSources = GetComponentsInChildren<AudioSource>(); //GameObject.Find("GameManager").GetComponents<AudioSource>();
    s_musicAudioSource = audioSources[0];
    s_bgMusicAudioSource = audioSources[1];
    s_ambientAudioSource = audioSources[2];
    s_EffectsAudioSource = audioSources[3];

//    linkToEnum(AudioStuff.Sounds.Sound1, "Sounds/");

//    linkToEnum(AudioStuff.Sounds.Hit1, "Sounds/");
  //  linkToEnum(AudioStuff.Sounds.Hit2, "Sounds/");

    //linkToEnum(AudioStuff.Sounds.None, "Sounds/Flyboy/");

    linkToEnum(AudioStuff.Sounds.Music1, "Sounds/Music/Music1");
    linkToEnum(AudioStuff.Sounds.MenuMusic, "Sounds/Music/MenuMusic");

 //   linkToEnum(AudioStuff.Sounds.Ambient1, "Sounds/Ambient/");
   
   // linkToEnum(AudioStuff.Sounds.Explosion, "Sounds/Effects/");
 
    instance = this;
  }




  // Start is called before the first frame update
  void Start()
    {
    if (GameManager.GameMngr.GameState == GAME_STATE.mainScreen)
    {
      AudioManager.changeMusic(AudioStuff.Sounds.MenuMusic);
    }
    else if (GameManager.GameMngr.GameState == GAME_STATE.gamePlay)
    {
      AudioManager.changeMusic(AudioStuff.Sounds.Music1);
    }
  }

    // Update is called once per frame
    void Update()
    {
        
    }


  //Link a sound to the AudioStuff.Sounds enum
  void linkToEnum(AudioStuff.Sounds soundType, string location)
  {
    s_Sounds[(int)soundType] = Resources.Load<AudioClip>(location);
#if UNITY_EDITOR
    if (!s_Sounds[(int)soundType])
    {
      Debug.LogError(soundType + " not found at location: " + location);
    }
#endif
  }

  public static void loopMusic(bool loop)
  {
    s_musicAudioSource.loop = loop;
  }

  public static void loopbgMusic(bool loop)
  {
    s_bgMusicAudioSource.loop = loop;
  }

  public static void pauseAmbient()
  {
    s_ambientAudioSource.Pause();
  }

  public static void unPauseAmbient()
  {
    s_ambientAudioSource.UnPause();
  }

  public static void pausebgMusic()
  {
    s_bgMusicAudioSource.Pause();
  }

  public static void unPausebgMusic()
  {
    s_bgMusicAudioSource.UnPause();
  }

  public static void pauseMusic()
  {
    s_musicAudioSource.Pause();
  }

  public static void unPauseMusic()
  {
    s_musicAudioSource.UnPause();
  }

  public static void pauseEffects()
  {
    s_EffectsAudioSource.Pause();
  }


  public static void unPauseEffects()
  {
    s_EffectsAudioSource.UnPause();
  }

  public static void destroyInstance(GameObject inst)
  {
    //inst.GetComponent<AudioSource>().Pause();
    //inst.GetComponent<AudioSource>().volume = 0;
    Destroy(inst);
  }

  public static void changeMusicVolume(float newVolume)
  {
    s_musicAudioSource.volume = newVolume;
  }

  public static void changeMusicVolume(float newVolume, float volumeSpeedChange)
  {
    s_musicAudioSource.volume = Mathf.Lerp(s_musicAudioSource.volume, newVolume, Time.deltaTime * volumeSpeedChange);
  }


  public static void changebgMusicVolume(float newVolume, float volumeSpeedChange)
  {

    s_bgMusicAudioSource.volume = Mathf.Lerp(s_bgMusicAudioSource.volume, newVolume, Time.deltaTime * volumeSpeedChange);

  }

  public static void changebgMusicVolume(float newVolume)
  {
    s_bgMusicAudioSource.volume = newVolume;
  }

  public static void changeMusicPitchAndVolume(bool changePitch, bool changeVolume, float changeMusicPitchTo, float pitchSpeedChange, float changeMusicVolumeTo, float volumeSpeedChange)
  {
    if (changeVolume)
    {
      s_musicAudioSource.volume = Mathf.Lerp(s_musicAudioSource.volume, changeMusicVolumeTo, Time.deltaTime * volumeSpeedChange);
    }
    if (changePitch)
    {
      s_musicAudioSource.pitch = Mathf.Lerp(s_musicAudioSource.pitch, changeMusicPitchTo, Time.deltaTime * pitchSpeedChange);
    }
  }
  public static void changebgMusicPitchAndVolume(bool changePitch, bool changeVolume, float changeMusicPitchTo, float pitchSpeedChange, float changeMusicVolumeTo, float volumeSpeedChange)
  {
    if (changeVolume)
    {
      s_bgMusicAudioSource.volume = Mathf.Lerp(s_bgMusicAudioSource.volume, changeMusicVolumeTo, Time.deltaTime * volumeSpeedChange);
    }
    if (changePitch)
    {
      s_bgMusicAudioSource.pitch = Mathf.Lerp(s_bgMusicAudioSource.pitch, changeMusicPitchTo, Time.deltaTime * pitchSpeedChange);
    }
  }


  public static void changeMusic(AudioStuff.Sounds Music)
  {
    s_musicAudioSource.clip = s_Sounds[(int)Music];

    if (instance.enabled) s_musicAudioSource.Play();
  }

  public static void changebgMusic(AudioStuff.Sounds Music)
  {
    s_bgMusicAudioSource.clip = s_Sounds[(int)Music];
    if (instance.enabled) s_bgMusicAudioSource.Play();
  }

  public static void changeAmbient(AudioStuff.Sounds AmbientSound)
  {
    s_ambientAudioSource.clip = s_Sounds[(int)AmbientSound];
    if (instance.enabled) s_ambientAudioSource.Play();
  }

  public static void changeAmbientVolume(float newVolume, float volumeSpeedChange)
  {
    s_ambientAudioSource.volume = Mathf.Lerp(s_ambientAudioSource.volume, newVolume, Time.deltaTime * volumeSpeedChange);
  }

  public static float getEffectsVolume()
  {
    return instance.enabled ? 1 : 0;
  }

  //play sound in the default SFX audioSource. Additive sound, no instance needed
  public static void playSound(AudioStuff.Sounds sound)
  {
    if (instance.enabled)
      s_EffectsAudioSource.PlayOneShot(s_Sounds[(int)sound]);
  }

  public static void playSound(AudioStuff.Sounds sound, float Vol)
  {
    s_EffectsAudioSource.volume = Vol;
    s_EffectsAudioSource.PlayOneShot(s_Sounds[(int)sound]);
  }

  public static void playSound(AudioStuff.Sounds sound, float Vol, float Pitch)
  {
    s_EffectsAudioSource.volume = Vol;
    s_EffectsAudioSource.pitch = Pitch;
    s_EffectsAudioSource.PlayOneShot(s_Sounds[(int)sound]);
  }

  public static void playAmbientSound(AudioStuff.Sounds sound)
  {
    if (instance.enabled)
      s_ambientAudioSource.PlayOneShot(s_Sounds[(int)sound]);
  }

  //function with all settings. Instanciate a sound with custom settings and destroy when it ends
  public static void InstanciateCustomSound(
      AudioStuff.Sounds sound, int priority, float volume, float pitch, float StereoPan,
      float SpatialBlend, float reverbZoneMix, float dopplerLevel, float spread, float minDistance, float MaxDistance)
  {
    if (!instance.enabled) return;

    GameObject audioInstance = new GameObject(sound + "AudioInstance");
    AudioSource audioSource = audioInstance.AddComponent<AudioSource>();
    audioSource.priority = priority;
    audioSource.volume = volume;
    audioSource.pitch = pitch;
    audioSource.panStereo = StereoPan;
    audioSource.spatialBlend = SpatialBlend;
    audioSource.reverbZoneMix = reverbZoneMix;
    audioSource.dopplerLevel = dopplerLevel;
    audioSource.spread = spread;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = MaxDistance;
    audioSource.PlayOneShot(s_Sounds[(int)sound]);

    audioInstance.transform.parent = instance.transform;

    Destroy(audioInstance, s_Sounds[(int)sound].length);
  }

  //function with only important settings. Instanciate a sound with custom settings and destroy when it ends
  public static void InstanciateCustomSound(AudioStuff.Sounds sound, int priority, float volume, float pitch, float StereoPan, string nombre, bool loop)
  {
    if (!instance.enabled) return;

    GameObject audioInstance = new GameObject(sound + "AudioInstance");
    audioInstance.name = nombre;
    AudioSource audioSource = audioInstance.AddComponent<AudioSource>();
    audioSource.priority = priority;
    audioSource.volume = volume;
    audioSource.pitch = pitch;
    audioSource.panStereo = StereoPan;
    audioSource.loop = loop;

    audioSource.PlayOneShot(s_Sounds[(int)sound]);

    audioInstance.transform.parent = instance.transform;

    Destroy(audioInstance, s_Sounds[(int)sound].length);
  }

  public static void InstanciateCustomSound(
   AudioStuff.Sounds sound, int priority, float volume, float pitch, float StereoPan, string nombre)
  {
    if (!instance.enabled) return;

    GameObject audioInstance = new GameObject(sound + "AudioInstance");
    audioInstance.name = nombre;
    AudioSource audioSource = audioInstance.AddComponent<AudioSource>();
    audioSource.priority = priority;
    audioSource.volume = volume;
    audioSource.pitch = pitch;
    audioSource.panStereo = StereoPan;


    audioSource.PlayOneShot(s_Sounds[(int)sound]);

    audioInstance.transform.parent = instance.transform;

    Destroy(audioInstance, s_Sounds[(int)sound].length);
  }

  public static void InstanciateCustomSound(
     AudioStuff.Sounds sound, int priority, float volume, float pitch, float StereoPan)
  {
    if (!instance.enabled) return;

#if UNITY_EDITOR
    if (!s_Sounds[(int)sound])
    {
      Debug.LogError(sound + " was never initialized.");
    }
#endif

    GameObject audioInstance = new GameObject(sound + "AudioInstance");
    AudioSource audioSource = audioInstance.AddComponent<AudioSource>();
    audioSource.priority = priority;
    audioSource.volume = volume;
    audioSource.pitch = pitch;
    audioSource.panStereo = StereoPan;

    audioSource.PlayOneShot(s_Sounds[(int)sound]);

    audioInstance.transform.parent = instance.transform;

    Destroy(audioInstance, s_Sounds[(int)sound].length);
  }
}
