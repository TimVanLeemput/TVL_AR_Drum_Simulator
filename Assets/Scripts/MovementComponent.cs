using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public event Action<bool> OnPositionReached;
    Vector3 initialPosition = Vector3.zero;

    [SerializeField] CustomLight lightToMove = null;
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    [SerializeField] bool canMove = false;
    [SerializeField] float maxDistance = 3.1f;
    [SerializeField] float maxDistanceOffset = .8f;

    /// <summary>
    /// Used to start the movement component from outside this class
    /// </summary>
    public bool CanMove
    { get { return canMove; } set { canMove = value; } }


    void Start()
    {
        Init(); 
    }


    public void SetCanMove(bool _value)
    {
        canMove = _value;
        Debug.Log("called SetCanMove");
    }

    void Init()
    {
        initialPosition = transform.position;
        if (!lightToMove) return;
        MovementComponent _moveCompo = lightToMove.GetComponent<MovementComponent>();
        OnPositionReached += (value) => _moveCompo.SetCanMove(!value);
    }

    public void Move(GameObject _gameObjectToMove)
    {
        if (canMove && CheckDistanceMoved() <= maxDistance)
        {
            _gameObjectToMove.transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else if (CheckDistanceMoved() > maxDistance && canMove == true)
            canMove = false;
        else if (CheckDistanceMoved() > maxDistance - maxDistanceOffset && canMove == true)
        {
            OnPositionReached?.Invoke(true);
            if (!lightToMove) return;
            lightToMove.GetComponent<MovementComponent>().CanMove = true;
        }
    }

    void Update()
    {
        Move(transform.gameObject);
    }

    float CheckDistanceMoved()
    {
        return Vector3.Distance(initialPosition, transform.position);
    }


}
