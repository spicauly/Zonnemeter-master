using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WijzerControl : MonoBehaviour {

    public Transform target;
    
    public enum SpriteRotation
    {
        Up = -90,
        Right = 0,
        Down = 90,
        Left = 180

    }

    public Camera mainCamera;
    public SpriteRotation initialRotation;

    private Vector2 _direction;
    private Vector2 _mousePosition;
    private Transform _transform;

    private float _angle;
    public float speed;
    public float maxSpeed = 2f;

    // Use this for initialization
    void Start () {
        _transform = transform;

        if (!mainCamera)
            mainCamera = Camera.main;
    }

    void FixedUpdate()
    {

        _mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _direction = (_mousePosition - (Vector2)_transform.position).normalized;

        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg + (int)initialRotation;
        _transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);

    }
}
