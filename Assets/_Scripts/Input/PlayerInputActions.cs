// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""205578fb-3465-4593-8cc2-1b713d5ddd10"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""66925de7-d243-4c44-aac5-eeea29da5508"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRotate"",
                    ""type"": ""Value"",
                    ""id"": ""e5965a68-1f2e-4073-888b-2532cf178623"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoystickRotate"",
                    ""type"": ""Value"",
                    ""id"": ""49e3d7e5-3713-43d2-9e81-d073811a1e7b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""e4bcbce7-f533-45ba-a629-d08d114e0984"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defense"",
                    ""type"": ""Button"",
                    ""id"": ""6c95f4c3-9064-4b4c-9b16-545e5498ee9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atack_1"",
                    ""type"": ""Button"",
                    ""id"": ""6cc47216-2a59-4bf4-8940-ae203740d575"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atack_2"",
                    ""type"": ""Button"",
                    ""id"": ""2a3abdf0-3b78-469a-b424-0dc76eb341b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atack_3"",
                    ""type"": ""Button"",
                    ""id"": ""9626b8b0-b1ee-489f-8f8d-e9941de7c2e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atack_4"",
                    ""type"": ""Button"",
                    ""id"": ""9ac99257-29eb-459a-be8c-e1ca80d0cbc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item_1"",
                    ""type"": ""Button"",
                    ""id"": ""b20bd6a4-a41b-4f59-84d3-01e8e5657912"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item_2"",
                    ""type"": ""Button"",
                    ""id"": ""388a6c5c-7f12-49b0-bbd8-81d9fbe436ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item_3"",
                    ""type"": ""Button"",
                    ""id"": ""0abe2308-351d-46a8-87d5-d26de0a2d605"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""dd580f00-30a1-40ce-b4ba-b933206c8a8a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""36980735-9bfa-4b48-9232-b03a9f11594b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1d75d1af-4efa-4156-bc6c-8192224ee5e5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f244edbe-8bad-4733-8e06-bf835df5f7d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5d64438f-52e5-4df6-9ec5-6bc60344e30b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e870ed85-8c94-45b0-ae71-950f4a2e26ff"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbd96622-6aea-4aff-9b50-6469aec8ec27"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e92c6619-c518-458a-b053-7e8220e43115"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f43b3c4-95b5-49f3-bd54-88c8dc9c9f65"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MouseRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d95cdb99-86e7-4f45-b074-1e22ed7f03f5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""JoystickRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2044796-3754-4689-8562-20474bca4fe8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Atack_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7661a5b6-4728-4e82-b433-4f68142e1df8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Atack_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b98aa25d-047d-40fc-bd17-ac5dbb4d705a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Atack_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab012b68-7be2-445d-98e9-9b1752a4e66b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Atack_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88ed127a-ab42-41e4-994b-4675e5c6065b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Atack_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a6de73a-e93a-4408-84c6-6ac21a8ddbb0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Atack_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1111477-534a-448d-b37b-5fb5d8d50050"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Atack_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39f36171-dfa3-4a05-ab46-23315d3525df"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Atack_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef2ab991-05da-4fb3-9754-f917e173f9c9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Item_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64975df0-03e7-48e8-8536-9ce96e9360f4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b3378d7-20d9-44a0-a458-00169c99bac9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Item_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d2836ad-8f7e-4b6f-8f7e-99df6cb35782"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72f54709-44ec-4d58-bf83-a067ee954ce8"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Item_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc34a27b-4311-495e-8dee-d10625158fa4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Item_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8f32275-31b0-4fc5-ad1f-10169f770363"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Defense"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de197790-cd8f-458c-b6ad-d83f6e138c60"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Defense"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_MouseRotate = m_Player.FindAction("MouseRotate", throwIfNotFound: true);
        m_Player_JoystickRotate = m_Player.FindAction("JoystickRotate", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_Defense = m_Player.FindAction("Defense", throwIfNotFound: true);
        m_Player_Atack_1 = m_Player.FindAction("Atack_1", throwIfNotFound: true);
        m_Player_Atack_2 = m_Player.FindAction("Atack_2", throwIfNotFound: true);
        m_Player_Atack_3 = m_Player.FindAction("Atack_3", throwIfNotFound: true);
        m_Player_Atack_4 = m_Player.FindAction("Atack_4", throwIfNotFound: true);
        m_Player_Item_1 = m_Player.FindAction("Item_1", throwIfNotFound: true);
        m_Player_Item_2 = m_Player.FindAction("Item_2", throwIfNotFound: true);
        m_Player_Item_3 = m_Player.FindAction("Item_3", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_MouseRotate;
    private readonly InputAction m_Player_JoystickRotate;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_Defense;
    private readonly InputAction m_Player_Atack_1;
    private readonly InputAction m_Player_Atack_2;
    private readonly InputAction m_Player_Atack_3;
    private readonly InputAction m_Player_Atack_4;
    private readonly InputAction m_Player_Item_1;
    private readonly InputAction m_Player_Item_2;
    private readonly InputAction m_Player_Item_3;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @MouseRotate => m_Wrapper.m_Player_MouseRotate;
        public InputAction @JoystickRotate => m_Wrapper.m_Player_JoystickRotate;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @Defense => m_Wrapper.m_Player_Defense;
        public InputAction @Atack_1 => m_Wrapper.m_Player_Atack_1;
        public InputAction @Atack_2 => m_Wrapper.m_Player_Atack_2;
        public InputAction @Atack_3 => m_Wrapper.m_Player_Atack_3;
        public InputAction @Atack_4 => m_Wrapper.m_Player_Atack_4;
        public InputAction @Item_1 => m_Wrapper.m_Player_Item_1;
        public InputAction @Item_2 => m_Wrapper.m_Player_Item_2;
        public InputAction @Item_3 => m_Wrapper.m_Player_Item_3;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @MouseRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseRotate;
                @MouseRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseRotate;
                @MouseRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseRotate;
                @JoystickRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJoystickRotate;
                @JoystickRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJoystickRotate;
                @JoystickRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJoystickRotate;
                @Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Defense.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefense;
                @Defense.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefense;
                @Defense.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefense;
                @Atack_1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_1;
                @Atack_1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_1;
                @Atack_1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_1;
                @Atack_2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_2;
                @Atack_2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_2;
                @Atack_2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_2;
                @Atack_3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_3;
                @Atack_3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_3;
                @Atack_3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_3;
                @Atack_4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_4;
                @Atack_4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_4;
                @Atack_4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtack_4;
                @Item_1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_1;
                @Item_1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_1;
                @Item_1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_1;
                @Item_2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_2;
                @Item_2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_2;
                @Item_2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_2;
                @Item_3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_3;
                @Item_3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_3;
                @Item_3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem_3;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MouseRotate.started += instance.OnMouseRotate;
                @MouseRotate.performed += instance.OnMouseRotate;
                @MouseRotate.canceled += instance.OnMouseRotate;
                @JoystickRotate.started += instance.OnJoystickRotate;
                @JoystickRotate.performed += instance.OnJoystickRotate;
                @JoystickRotate.canceled += instance.OnJoystickRotate;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Defense.started += instance.OnDefense;
                @Defense.performed += instance.OnDefense;
                @Defense.canceled += instance.OnDefense;
                @Atack_1.started += instance.OnAtack_1;
                @Atack_1.performed += instance.OnAtack_1;
                @Atack_1.canceled += instance.OnAtack_1;
                @Atack_2.started += instance.OnAtack_2;
                @Atack_2.performed += instance.OnAtack_2;
                @Atack_2.canceled += instance.OnAtack_2;
                @Atack_3.started += instance.OnAtack_3;
                @Atack_3.performed += instance.OnAtack_3;
                @Atack_3.canceled += instance.OnAtack_3;
                @Atack_4.started += instance.OnAtack_4;
                @Atack_4.performed += instance.OnAtack_4;
                @Atack_4.canceled += instance.OnAtack_4;
                @Item_1.started += instance.OnItem_1;
                @Item_1.performed += instance.OnItem_1;
                @Item_1.canceled += instance.OnItem_1;
                @Item_2.started += instance.OnItem_2;
                @Item_2.performed += instance.OnItem_2;
                @Item_2.canceled += instance.OnItem_2;
                @Item_3.started += instance.OnItem_3;
                @Item_3.performed += instance.OnItem_3;
                @Item_3.canceled += instance.OnItem_3;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseRotate(InputAction.CallbackContext context);
        void OnJoystickRotate(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnDefense(InputAction.CallbackContext context);
        void OnAtack_1(InputAction.CallbackContext context);
        void OnAtack_2(InputAction.CallbackContext context);
        void OnAtack_3(InputAction.CallbackContext context);
        void OnAtack_4(InputAction.CallbackContext context);
        void OnItem_1(InputAction.CallbackContext context);
        void OnItem_2(InputAction.CallbackContext context);
        void OnItem_3(InputAction.CallbackContext context);
    }
}
