using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLight : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent = null;
    void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
    }

    void Update()
    {
        movementComponent.Move(transform.gameObject);
    }
}
