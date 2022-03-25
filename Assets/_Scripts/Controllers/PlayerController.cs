using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _staff;
    [SerializeField] private float _speed;
    private bool _canDodge = true;
    private Vector2 _moveInput;
    private Vector2 _rotateInput;
    private Rigidbody2D _rb;

    void OnEnable()
    {
        EventManager.StartListening(Events.Player.Move, OnMove);
        EventManager.StartListening(Events.Player.Stop, OnStop);
        EventManager.StartListening(Events.Player.MouseRotate, OnMouseRotate);
        EventManager.StartListening(Events.Player.JoystickRotate, OnJoystickRotate);
        EventManager.StartListening(Events.Player.Dodge, OnDodge);
    }
    void OnDisable()
    {
        EventManager.StopListening(Events.Player.Move, OnMove);
        EventManager.StopListening(Events.Player.Stop, OnStop);
        EventManager.StopListening(Events.Player.MouseRotate, OnMouseRotate);
        EventManager.StopListening(Events.Player.JoystickRotate, OnJoystickRotate);
        EventManager.StopListening(Events.Player.Dodge, OnDodge);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _staff = Instantiate(_staff, Vector3.zero, Quaternion.identity, transform);
    }
    void Upddate()
    {

    }
    void FixedUpdate()
    {
        _rb.velocity = _moveInput * _speed;
        _staff.transform.rotation = Rotate(_rotateInput);
    }

    void OnMove(object obj)
    {
        _moveInput = (Vector2)obj;
    }
    void OnStop(object obj)
    {
        _moveInput = Vector2.zero;
    }
    void OnMouseRotate(object obj)
    {
        Vector2 mouseScreenPosition = (Vector2)obj;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector2 targetDirection = mouseWorldPosition - _rb.position;

        _rotateInput = targetDirection;
    }

    void OnJoystickRotate(object obj)
    {
        Vector2 targetDirection = ((Vector2)obj).normalized;

        _rotateInput = targetDirection;
    }
    void OnDodge(object obj)
    {
        StartCoroutine(Dodge());
    }
    Quaternion Rotate(Vector2 joystickDirection)
    {
        float angle = Mathf.Atan2(joystickDirection.y, joystickDirection.x) * Mathf.Rad2Deg;

        return Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
    IEnumerator Dodge()
    {
        if (_canDodge)
        {
            _canDodge = false;
            _speed = _speed * 3f;

            yield return new WaitForSeconds(0.15f);

            _speed = _speed / 3f;
            _canDodge = true;
        }
    }
}
