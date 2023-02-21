//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Settings/PlayerInputConfig.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputConfig : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputConfig()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputConfig"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""4224a3da-c78e-496d-9047-7d0b0870a69f"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""789db34a-5e52-4448-a49d-8b85c3fac5a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4aff1d0c-513a-4bef-af25-dc76bdb7ddcd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Spawn"",
                    ""type"": ""Value"",
                    ""id"": ""7dba0681-8364-457d-bf67-37ffba16c81d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d89d1a0e-0c1d-4af3-bfd5-5821cf522fa3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ClickMove"",
                    ""type"": ""Button"",
                    ""id"": ""370eab74-6a50-4fed-917b-4fbcb8f2105d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b347ce2c-4071-4863-919d-e36908fa8a1b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""524d453c-2004-4862-b06f-580b55814e37"",
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
                    ""id"": ""2198c763-9c40-4f97-9e1a-7198930a648e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1cc2a80b-39ef-47d5-abcd-5f619eef04c1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae924c43-8428-416e-bb38-65224d6edf95"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a03fda9e-2a4a-4631-9e94-9d27ef27b20d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""094fa6f2-eb7b-48f6-8bee-6156cba9494b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89e31900-d03f-46a5-bc99-b4bbcac291af"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""731756ea-3d9d-43a0-9672-f419f1e86e8c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ClickMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Fire = m_GamePlay.FindAction("Fire", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Spawn = m_GamePlay.FindAction("Spawn", throwIfNotFound: true);
        m_GamePlay_MousePos = m_GamePlay.FindAction("MousePos", throwIfNotFound: true);
        m_GamePlay_ClickMove = m_GamePlay.FindAction("ClickMove", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Fire;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Spawn;
    private readonly InputAction m_GamePlay_MousePos;
    private readonly InputAction m_GamePlay_ClickMove;
    public struct GamePlayActions
    {
        private @PlayerInputConfig m_Wrapper;
        public GamePlayActions(@PlayerInputConfig wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_GamePlay_Fire;
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Spawn => m_Wrapper.m_GamePlay_Spawn;
        public InputAction @MousePos => m_Wrapper.m_GamePlay_MousePos;
        public InputAction @ClickMove => m_Wrapper.m_GamePlay_ClickMove;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Spawn.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSpawn;
                @Spawn.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSpawn;
                @Spawn.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSpawn;
                @MousePos.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMousePos;
                @ClickMove.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnClickMove;
                @ClickMove.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnClickMove;
                @ClickMove.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnClickMove;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Spawn.started += instance.OnSpawn;
                @Spawn.performed += instance.OnSpawn;
                @Spawn.canceled += instance.OnSpawn;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @ClickMove.started += instance.OnClickMove;
                @ClickMove.performed += instance.OnClickMove;
                @ClickMove.canceled += instance.OnClickMove;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSpawn(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
        void OnClickMove(InputAction.CallbackContext context);
    }
}
