using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _rotationSpeed = 30f;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Animator _animator;

    public event Action Fired = default;
    public event Action Droped = default;

    private void Awake()
    {
        _input = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Move(_input.Player.Move.ReadValue<Vector2>());
        MouseRotation(_input.Player.MousePosition.ReadValue<Vector2>());
        Shoot();
        GrenadeDroped();
    }

    private void Move(Vector2 input)
    {
        if (input.x != 0 || input.y != 0)
            _animator.SetBool("Move", true);
        else
            _animator.SetBool("Move", false);
        
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        _rigidbody.velocity = moveDirection.normalized * _moveSpeed;
    }

    private void MouseRotation(Vector2 mousePosition)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (_input.Player.Shoot.triggered)
        {
            _animator.SetBool("Shoot", true);
            Fired?.Invoke();
        }
        else
            _animator.SetBool("Shoot", false);
            
    }
    
    private void GrenadeDroped()
    {
        if (_input.Player.DropGrenade.triggered)
        {
            _animator.SetBool("Drop", true);
            Droped?.Invoke();
        }
        else
            _animator.SetBool("Drop", false);

    }
}
