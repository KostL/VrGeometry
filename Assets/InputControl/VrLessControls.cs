// GENERATED AUTOMATICALLY FROM 'Assets/InputControl/VrLessControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VrLessControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VrLessControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VrLessControls"",
    ""maps"": [
        {
            ""name"": ""EditorDebug"",
            ""id"": ""07598459-4bf3-4fc6-b9a5-5e42d35ebd4d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1dd66147-280b-4255-b5fc-c0b72256e359"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""3f82d5c8-a23c-45d6-8f94-a0be77ef12df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateTurnOn"",
                    ""type"": ""Value"",
                    ""id"": ""6ca18685-f879-4687-9869-767310e59856"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7787749c-7646-4166-92a1-0b8ace45d08e"",
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
                    ""id"": ""182df74b-c9a7-42d9-ad10-d5b64336e8e2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b6f6249b-9d67-43b5-a409-241909d070ca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e1759694-e7f6-4275-b5fc-5ee574df6e53"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""13f4fafa-273b-4966-9549-6565f2c4dab7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""19ffbefc-3be8-4b90-a521-9b22104bdb09"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41e154bb-17fd-498c-b49c-7d1a85395c5e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateTurnOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // EditorDebug
        m_EditorDebug = asset.FindActionMap("EditorDebug", throwIfNotFound: true);
        m_EditorDebug_Move = m_EditorDebug.FindAction("Move", throwIfNotFound: true);
        m_EditorDebug_Look = m_EditorDebug.FindAction("Look", throwIfNotFound: true);
        m_EditorDebug_RotateTurnOn = m_EditorDebug.FindAction("RotateTurnOn", throwIfNotFound: true);
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

    // EditorDebug
    private readonly InputActionMap m_EditorDebug;
    private IEditorDebugActions m_EditorDebugActionsCallbackInterface;
    private readonly InputAction m_EditorDebug_Move;
    private readonly InputAction m_EditorDebug_Look;
    private readonly InputAction m_EditorDebug_RotateTurnOn;
    public struct EditorDebugActions
    {
        private @VrLessControls m_Wrapper;
        public EditorDebugActions(@VrLessControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_EditorDebug_Move;
        public InputAction @Look => m_Wrapper.m_EditorDebug_Look;
        public InputAction @RotateTurnOn => m_Wrapper.m_EditorDebug_RotateTurnOn;
        public InputActionMap Get() { return m_Wrapper.m_EditorDebug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EditorDebugActions set) { return set.Get(); }
        public void SetCallbacks(IEditorDebugActions instance)
        {
            if (m_Wrapper.m_EditorDebugActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnLook;
                @RotateTurnOn.started -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnRotateTurnOn;
                @RotateTurnOn.performed -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnRotateTurnOn;
                @RotateTurnOn.canceled -= m_Wrapper.m_EditorDebugActionsCallbackInterface.OnRotateTurnOn;
            }
            m_Wrapper.m_EditorDebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @RotateTurnOn.started += instance.OnRotateTurnOn;
                @RotateTurnOn.performed += instance.OnRotateTurnOn;
                @RotateTurnOn.canceled += instance.OnRotateTurnOn;
            }
        }
    }
    public EditorDebugActions @EditorDebug => new EditorDebugActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IEditorDebugActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnRotateTurnOn(InputAction.CallbackContext context);
    }
}
