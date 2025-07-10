using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Drumkit;

public class DrumKitController : MonoBehaviour
{
    [SerializeField] public AudioSource bassSoundSource = null;
    [SerializeField] public AudioSource highTomSoundSource = null;
    [SerializeField] public AudioSource mediumTomSoundSource = null;
    [SerializeField] public AudioSource lowTomSoundSource = null;
    [SerializeField] public AudioSource snareSoundSource = null;
    [SerializeField] public AudioSource charlestonSoundSource = null;
    [SerializeField] public AudioSource crashSoundSource = null;
    [SerializeField] public AudioSource rideSoundSource = null;

    // drumKitList needs to be filled with every single element of the drumkit
    [SerializeField] List<Drumkit> drumKitList = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        InputsComponent inputs = GetComponent<InputsComponent>();

        inputs.Bass.performed += (c) => InteractWithDrumKit(c,DrumTypes.BASS);
        inputs.HighTom.performed += (c) => InteractWithDrumKit(c, DrumTypes.HIGH);
        inputs.MediumTom.performed += (c) => InteractWithDrumKit(c, DrumTypes.MEDIUM);
        inputs.LowTom.performed += (c) => InteractWithDrumKit(c, DrumTypes.LOW);
        inputs.Snare.performed += (c) => InteractWithDrumKit(c, DrumTypes.SNARE);
        inputs.Charleston.performed += (c) => InteractWithDrumKit(c, DrumTypes.CHARLESTON);
        inputs.Crash.performed += (c) => InteractWithDrumKit(c, DrumTypes.CRASH);
        inputs.Ride.performed += (c) => InteractWithDrumKit(c, DrumTypes.RIDE);
    }

    private void InteractWithDrumKit(InputAction.CallbackContext context, DrumTypes _drumType)
    {
        int _size = drumKitList.Count;
        for (int i = 0; i < _size; i++)
        {
            if (drumKitList[i].drumType == _drumType)
                drumKitList[i].PlaySound();
        }
    }
}
