using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button_Play : UI_Button
{
    public event Action<bool> OnCameraSwapped;

    [SerializeField] GameObject toHide = null;
    [SerializeField] Camera cameraToControl = null;
    [SerializeField] Camera cameraToHide = null;
    [SerializeField] List<MovementComponent> moveComponentsList = null;
    protected override void Execute()
    {
        // Call camera change and hide UI
        Hide(toHide);
        SetControledCamera(cameraToControl);
        SwapControlledCamera();
        SwapAudioListener();
    }

    protected override void Init()
    {
        base.Init();
        OnCameraSwapped += (value) => InitializeMovementComponent(value);
    }

    private void Hide(GameObject _hide)
    { 
        _hide.SetActive(false);
    }
    private void SetControledCamera(Camera _camera)
    {
        if (!_camera) return;
        cameraToControl = _camera;
    }

    private void SwapControlledCamera()
    {
        cameraToHide.enabled = false;
        cameraToHide.gameObject.SetActive(false);
        if (!cameraToControl) return;
        cameraToControl.enabled = true;
        cameraToControl.gameObject.SetActive(true);

        OnCameraSwapped?.Invoke(true);
    }

    private void InitializeMovementComponent(bool _value)
    { 
        foreach (MovementComponent _moveComponent in moveComponentsList) 
        {
            _moveComponent.SetCanMove(_value);
        }
    }

    private void SwapAudioListener()
    {
        if (!cameraToHide) return;
        AudioListener _listenerToDisable =  cameraToHide.GetComponent<AudioListener>();
        _listenerToDisable.enabled = false;
        AudioListener _listenerToEnable =  cameraToControl.GetComponent<AudioListener>();
        _listenerToEnable.enabled = true;
    }
}
