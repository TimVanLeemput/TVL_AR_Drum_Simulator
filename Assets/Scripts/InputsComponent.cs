using UnityEngine;
using UnityEngine.InputSystem;

public class InputsComponent : MonoBehaviour
{
    [SerializeField] InputAction charleston = null;
    [SerializeField] InputAction crash = null;
    [SerializeField] InputAction highTom = null;
    [SerializeField] InputAction mediumTom = null;
    [SerializeField] InputAction lowTom = null;
    [SerializeField] InputAction ride = null;
    [SerializeField] InputAction bass = null;
    [SerializeField] InputAction snare = null;
    [SerializeField] InputAction hit = null;

    [SerializeField] MyInputs controls = null;

    #region Accessors
    public InputAction Charleston
    {
        get { return charleston; }
        set { charleston = value; }
    }

    public InputAction Crash
    {
        get { return crash; }
        set { crash = value; }
    }

    public InputAction HighTom
    {
        get { return highTom; }
        set { highTom = value; }
    }

    public InputAction MediumTom
    {
        get { return mediumTom; }
        set { mediumTom = value; }
    }

    public InputAction LowTom
    {
        get { return lowTom; }
        set { lowTom = value; }
    }

    public InputAction Ride
    {
        get { return ride; }
        set { ride = value; }
    }

    public InputAction Bass
    {
        get { return bass; }
        set { bass = value; }
    }

    public InputAction Hit
    {
        get { return hit; }
        set { hit = value; }
    }
    public InputAction Snare
    {
        get { return snare; }
        set { snare = value; }
    }

    #endregion

    private void Awake()
    {
        controls = new MyInputs();

    }
    void Start()
    {
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        hit = controls.Player.Hit;
        hit.Enable();

        charleston = controls.Player.Charleston;
        charleston.Enable();

        crash = controls.Player.Crash;
        crash.Enable();

        ride = controls.Player.Ride;
        ride.Enable();

        highTom = controls.Player.HighTom;
        highTom.Enable();

        mediumTom = controls.Player.MediumTom;
        mediumTom.Enable();

        lowTom = controls.Player.LowTom;
        lowTom.Enable();

        bass = controls.Player.Bass;
        bass.Enable();

        snare = controls.Player.Snare;
        snare.Enable();
    }
}
