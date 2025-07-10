using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Drumkit : MonoBehaviour
{
    [SerializeField] public enum DrumTypes {
        None,
        HIGH,
        MEDIUM,
        LOW,
        SNARE,
        SNARE_NOSNARE,
        BASS,
        CHARLESTON,
        CRASH,
        RIDE
    };

    public DrumTypes drumType;
    [SerializeField] AudioSource soundSource = null;

    [SerializeField] AudioClip soundToPlay = null;
    [SerializeField] AudioClip highTomsound = null;
    [SerializeField] AudioClip mediumTomSound = null;
    [SerializeField] AudioClip lowTomSound = null;
    [SerializeField] AudioClip snareSound = null;
    [SerializeField] AudioClip bassSound = null;
    [SerializeField] AudioClip charlestonSound = null;
    [SerializeField] AudioClip crashSound = null;
    [SerializeField] AudioClip rideSound = null;

    #region Accessors 
    public AudioSource SoundSource
    {
        get { return soundSource; }
        set { soundSource = value; }
    }
    public AudioClip HighTomSound
    {
        get { return highTomsound; }
        set { highTomsound = value; }
    }

    public AudioClip MediumTomSound
    {
        get { return mediumTomSound; }
        set { mediumTomSound = value; }
    }

    public AudioClip LowTomSound
    {
        get { return lowTomSound; }
        set { lowTomSound = value; }
    }

    public AudioClip SnareSound
    {
        get { return snareSound; }
        set { snareSound = value; }
    }

    public AudioClip BassSound
    {
        get { return bassSound; }
        set { bassSound = value; }
    }

    public AudioClip CharlestonSound
    {
        get { return charlestonSound; }
        set { charlestonSound = value; }
    }

    public AudioClip CrashSound
    {
        get { return crashSound; }
        set { crashSound = value; }
    }

    public AudioClip RideSound
    {
        get { return rideSound; }
        set { rideSound = value; }
    }

    #endregion

    void Start()
    {
        Init();
        InitSwitchDrumType();
        InitSoundSourceClip();
    }
    void Init()
    {
        soundSource = GetComponent<AudioSource>();
     

        // Initialize each sourcSource to its own
    }
    void InitSoundSourceClip()
    {
        if (!soundSource) return;
        soundSource.clip = soundToPlay;
    }

    void InitSwitchDrumType()
    {
        switch (drumType)
        {
            case DrumTypes.HIGH:
                SetSoundToPlay(highTomsound);
                break;
            case DrumTypes.MEDIUM:
                SetSoundToPlay(mediumTomSound);
                break;

            case DrumTypes.LOW:
                SetSoundToPlay(lowTomSound);
                break;

            case DrumTypes.BASS:
                SetSoundToPlay(bassSound);
                break;

            case DrumTypes.CHARLESTON:
                SetSoundToPlay(charlestonSound);
                break;

            case DrumTypes.CRASH:
                SetSoundToPlay(crashSound);
                break;
            case DrumTypes.RIDE:
                SetSoundToPlay(rideSound);
                break;
            case DrumTypes.SNARE:
                SetSoundToPlay(snareSound);
                break;

        }
    }

    public void PlaySound()
    {
        soundSource.clip = soundToPlay;
        soundSource.Play();
    }

    public void SetSoundToPlay(AudioClip _soundToPlay)
    {
        soundToPlay = _soundToPlay;
    }

}
