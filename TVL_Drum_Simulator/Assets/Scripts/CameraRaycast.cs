using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRaycast : MonoBehaviour
{
    public event Action<RaycastHit> OnRaycastHit;
    [SerializeField, Range(5, 100)] float detectionDistance = 0;
    [SerializeField] private bool drumDetect = false;
    [SerializeField] private Ray screenRay;
    [SerializeField] private LayerMask drumLayer;
    [SerializeField] private Stick stick = null;
    [SerializeField] private GameObject drumElementHit = null;
    [SerializeField] private Drumkit bassDrum = null;
    [SerializeField] private RaycastHit drumHit;

    #region inputs

    [SerializeField] private MyInputs controls = null;
    [SerializeField] private InputAction mousePos = null;
    [SerializeField] private InputsComponent inputs = null;

    #endregion

    private float initialDetectionDistance = 0;

    void Awake()
    {
        controls = new MyInputs();
    }

    void Start()
    {
        Init();
    }

    void Init()
    {
        initialDetectionDistance = detectionDistance;
        inputs = GetComponent<InputsComponent>();
    }

    void Update()
    {
        Detect();
    }

    void Detect()
    {
        Vector2 _pos2D = mousePos.ReadValue<Vector2>();
        Vector3 _pos = new Vector3(_pos2D.x, _pos2D.y, detectionDistance);
        screenRay = Camera.main.ScreenPointToRay(_pos);
        bool _hitDrum = Physics.Raycast(screenRay, out RaycastHit _drumHitResult, detectionDistance, drumLayer);
        Debug.DrawRay(screenRay.origin, screenRay.direction * 20);
        drumDetect = _hitDrum;

        if (drumDetect)
        {
            Debug.Log("Drum detected");
            drumHit = _drumHitResult;
            detectionDistance = _drumHitResult.distance + 2;
            UpdateStickPosition(_drumHitResult.point);
            inputs.Hit.performed += HitDrum;
            OnRaycastHit?.Invoke(_drumHitResult);
        }
        else
        {
            detectionDistance = initialDetectionDistance;
            inputs.Hit.performed -= HitDrum;
        }
    }

    public void HitDrum(InputAction.CallbackContext _context)
    {
        Debug.Log("Called HitDrum Input");
        InteractWithDrumElement(drumHit);
    }

    void UpdateStickPosition(Vector3 _pos)
    {
        stick.transform.position = _pos;
    }

    void InteractWithDrumElement(RaycastHit _hitResult)
    {
        if (!_hitResult.transform) return;
        drumElementHit = _hitResult.transform.gameObject;
        if (!drumElementHit) return;
        Drumkit _drumKitElement = drumElementHit.GetComponent<Drumkit>();
        if (!_drumKitElement) return;
        _drumKitElement.PlaySound();
    }

    void OnEnable()
    {
        mousePos = controls.Player.MousePos;
        mousePos.Enable();
    }
}