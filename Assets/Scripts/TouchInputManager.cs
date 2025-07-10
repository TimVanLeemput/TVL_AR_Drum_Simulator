using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputManager : MonoBehaviour
{
    private MyInputs controls = null;
    private InputAction touchPress = null;
    private InputAction touchPosition = null;

    [SerializeField] private GameObject thingToMove = null;

    private void Awake()
    {
        controls = new MyInputs();
    }

    private void OnEnable()
    {
        // Enable and initialize the touchPress input action
        touchPress = controls.Touch.TouchPress;
        touchPress.Enable();
        touchPress.started += ctx => StartTouch();

        // Enable and initialize the touchPosition input action
        touchPosition = controls.Touch.TouchPosition;
        touchPosition.Enable();
    }

    private void StartTouch()
    {
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true) // Continuously check
        {
            float touchValue = touchPress.ReadValue<float>();
            Debug.Log("Touch value: " + touchValue);
            yield return null;
        }
    }



    private void OnDisable()
    {
        // Disable input actions when script is disabled
        touchPress.Disable();
        touchPosition.Disable();
    }

    private void OnDestroy()
    {
        // Release input actions resources when the script is destroyed
        touchPress.Dispose();
        touchPosition.Dispose();
    }
}
