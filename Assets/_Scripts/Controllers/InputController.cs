using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInputActions _playerInput;

    private InputController _instance;

    public InputController Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        _playerInput = new PlayerInputActions();
    }

    void OnEnable()
    {
        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OnStop;
        _playerInput.Player.MouseRotate.performed += OnMouseRotate;
        _playerInput.Player.JoystickRotate.performed += OnJoystickRotate;
        _playerInput.Player.Dodge.started += OnDodge;
        _playerInput.Player.Defense.started += OnDefense;
        _playerInput.Player.Atack_1.started += OnAtack_1;
        _playerInput.Player.Atack_2.started += OnAtack_2;
        _playerInput.Player.Atack_3.started += OnAtack_3;
        _playerInput.Player.Atack_4.started += OnAtack_4;
        _playerInput.Player.Item_1.started += OnItem_1;
        _playerInput.Player.Item_2.started += OnItem_2;
        _playerInput.Player.Item_3.started += OnItem_3;

        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Player.Move.canceled -= OnStop;
        _playerInput.Player.MouseRotate.performed -= OnMouseRotate;
        _playerInput.Player.JoystickRotate.performed -= OnJoystickRotate;
        _playerInput.Player.Dodge.started -= OnDodge;
        _playerInput.Player.Defense.started += OnDefense;
        _playerInput.Player.Atack_1.started -= OnAtack_1;
        _playerInput.Player.Atack_2.started -= OnAtack_2;
        _playerInput.Player.Atack_3.started -= OnAtack_3;
        _playerInput.Player.Atack_4.started -= OnAtack_4;
        _playerInput.Player.Item_1.started -= OnItem_1;
        _playerInput.Player.Item_2.started -= OnItem_2;
        _playerInput.Player.Item_3.started -= OnItem_3;

        _playerInput.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        EventManager.TriggerEvent(Events.Player.Move, inputVector);
    }
    void OnStop(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Stop);
    }
    void OnMouseRotate(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        EventManager.TriggerEvent(Events.Player.MouseRotate, inputVector);
    }
    void OnJoystickRotate(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        EventManager.TriggerEvent(Events.Player.JoystickRotate, inputVector);
    }
    void OnDodge(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Dodge);
    }
    void OnDefense(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Defense);
    }
    void OnAtack_1(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Atack_1);
    }
    void OnAtack_2(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Atack_2);
    }
    void OnAtack_3(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Atack_3);
    }
    void OnAtack_4(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Atack_4);
    }
    void OnItem_1(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Item_1);
    }
    void OnItem_2(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Item_2);
    }
    void OnItem_3(InputAction.CallbackContext context)
    {
        EventManager.TriggerEvent(Events.Player.Item_3);
    }

}
