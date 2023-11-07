//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Jogador"",
            ""id"": ""cee8acfd-0b1a-4676-86ce-ebdb7db3f7ea"",
            ""actions"": [
                {
                    ""name"": ""Movimento"",
                    ""type"": ""Value"",
                    ""id"": ""c5e6192c-e317-4441-9a44-ce872771f2c8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Usar"",
                    ""type"": ""Button"",
                    ""id"": ""67c818a3-1c4c-4bfe-9311-08e5fdfcba69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""4717721d-5235-4458-a91a-2cd1e1d303ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Help"",
                    ""type"": ""Button"",
                    ""id"": ""e5196b55-5d0d-4bde-bf90-2214cfcbfe08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Correr"",
                    ""type"": ""Button"",
                    ""id"": ""c6640a55-29e6-468a-b2b7-9e9f68a916bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Soltar"",
                    ""type"": ""Button"",
                    ""id"": ""d1aa936a-03c1-425e-bd45-3922161f1e0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f5509f01-a72e-4cda-9b68-dda97b5d576b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Teclado WASD"",
                    ""id"": ""f412a464-0216-45a2-9e06-fbcf0a046976"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4e157a59-24da-4653-a583-1f5fd938c656"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e9fbe675-03a5-495d-9811-81c914410b2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fb43b54d-5f8c-439a-b3f0-640c5e48d48b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee0c2ab7-45f3-4845-bbba-fb432662af5b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Teclado setas"",
                    ""id"": ""f964fe63-3b8b-43c5-849e-0f1ea2798b9d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""94bc2fb0-214b-40cc-8e36-7ee47b695aaf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""52166b3d-a59f-4a02-9490-b50f465b25e3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc3bd8fc-834a-4dec-8b04-d07a76f03c96"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8dffa961-a625-4ac4-be18-a6226ae0adeb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""2eb6ff53-7ee3-4a91-824a-5016221170e2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a9709fe2-ad9e-4763-b12d-26f879955952"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""48b83b0e-46ae-45d0-8ae8-7bfe28cf17ac"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b77a20d8-6270-4c7d-a8ae-95f660b8fad6"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d8f712d5-4858-4308-92c8-b5d060e72428"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad Analog"",
                    ""id"": ""77e0399f-9cd3-4297-9be6-1c4600269867"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4985b099-df95-4da1-9d06-827fcfdce4ca"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8426c283-ad22-4cb9-a571-7ac905b53327"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7bb2e3ae-b10f-4527-ad94-bb83ef44ba24"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8c06f2a-35f2-4d74-b782-c5b3e0040bdf"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""520df617-a096-4e48-a7ca-804c0dfdf29e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08654fd6-a40f-4111-a1d5-75be4ffaf0b9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c16e9a7f-6896-4d92-a666-38356a1586de"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Help"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b077e09-a77a-44c6-ab09-37ca0c109825"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Help"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a7fff0e-4e21-4c15-a904-2b08fe778aea"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f33df76f-816c-42ed-b8b4-7019739339a5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8d14d54-cba3-42c0-8526-fded98681ff6"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Soltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28efc21c-f6db-44c8-bc2b-e79b9de7580e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Soltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""611b5f96-60c4-49f6-a0d2-ea31cadc9117"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f73b3a54-c834-4274-9aed-8659783f3f20"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cb13ea9-894c-47e5-95e4-8bb811003808"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Usar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8f11e97-d6b5-4941-8106-3c4edec817f7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Usar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Jogador
        m_Jogador = asset.FindActionMap("Jogador", throwIfNotFound: true);
        m_Jogador_Movimento = m_Jogador.FindAction("Movimento", throwIfNotFound: true);
        m_Jogador_Usar = m_Jogador.FindAction("Usar", throwIfNotFound: true);
        m_Jogador_Start = m_Jogador.FindAction("Start", throwIfNotFound: true);
        m_Jogador_Help = m_Jogador.FindAction("Help", throwIfNotFound: true);
        m_Jogador_Correr = m_Jogador.FindAction("Correr", throwIfNotFound: true);
        m_Jogador_Soltar = m_Jogador.FindAction("Soltar", throwIfNotFound: true);
        m_Jogador_Pause = m_Jogador.FindAction("Pause", throwIfNotFound: true);
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

    // Jogador
    private readonly InputActionMap m_Jogador;
    private List<IJogadorActions> m_JogadorActionsCallbackInterfaces = new List<IJogadorActions>();
    private readonly InputAction m_Jogador_Movimento;
    private readonly InputAction m_Jogador_Usar;
    private readonly InputAction m_Jogador_Start;
    private readonly InputAction m_Jogador_Help;
    private readonly InputAction m_Jogador_Correr;
    private readonly InputAction m_Jogador_Soltar;
    private readonly InputAction m_Jogador_Pause;
    public struct JogadorActions
    {
        private @PlayerInputActions m_Wrapper;
        public JogadorActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimento => m_Wrapper.m_Jogador_Movimento;
        public InputAction @Usar => m_Wrapper.m_Jogador_Usar;
        public InputAction @Start => m_Wrapper.m_Jogador_Start;
        public InputAction @Help => m_Wrapper.m_Jogador_Help;
        public InputAction @Correr => m_Wrapper.m_Jogador_Correr;
        public InputAction @Soltar => m_Wrapper.m_Jogador_Soltar;
        public InputAction @Pause => m_Wrapper.m_Jogador_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Jogador; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JogadorActions set) { return set.Get(); }
        public void AddCallbacks(IJogadorActions instance)
        {
            if (instance == null || m_Wrapper.m_JogadorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JogadorActionsCallbackInterfaces.Add(instance);
            @Movimento.started += instance.OnMovimento;
            @Movimento.performed += instance.OnMovimento;
            @Movimento.canceled += instance.OnMovimento;
            @Usar.started += instance.OnUsar;
            @Usar.performed += instance.OnUsar;
            @Usar.canceled += instance.OnUsar;
            @Start.started += instance.OnStart;
            @Start.performed += instance.OnStart;
            @Start.canceled += instance.OnStart;
            @Help.started += instance.OnHelp;
            @Help.performed += instance.OnHelp;
            @Help.canceled += instance.OnHelp;
            @Correr.started += instance.OnCorrer;
            @Correr.performed += instance.OnCorrer;
            @Correr.canceled += instance.OnCorrer;
            @Soltar.started += instance.OnSoltar;
            @Soltar.performed += instance.OnSoltar;
            @Soltar.canceled += instance.OnSoltar;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IJogadorActions instance)
        {
            @Movimento.started -= instance.OnMovimento;
            @Movimento.performed -= instance.OnMovimento;
            @Movimento.canceled -= instance.OnMovimento;
            @Usar.started -= instance.OnUsar;
            @Usar.performed -= instance.OnUsar;
            @Usar.canceled -= instance.OnUsar;
            @Start.started -= instance.OnStart;
            @Start.performed -= instance.OnStart;
            @Start.canceled -= instance.OnStart;
            @Help.started -= instance.OnHelp;
            @Help.performed -= instance.OnHelp;
            @Help.canceled -= instance.OnHelp;
            @Correr.started -= instance.OnCorrer;
            @Correr.performed -= instance.OnCorrer;
            @Correr.canceled -= instance.OnCorrer;
            @Soltar.started -= instance.OnSoltar;
            @Soltar.performed -= instance.OnSoltar;
            @Soltar.canceled -= instance.OnSoltar;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IJogadorActions instance)
        {
            if (m_Wrapper.m_JogadorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJogadorActions instance)
        {
            foreach (var item in m_Wrapper.m_JogadorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JogadorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JogadorActions @Jogador => new JogadorActions(this);
    public interface IJogadorActions
    {
        void OnMovimento(InputAction.CallbackContext context);
        void OnUsar(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnHelp(InputAction.CallbackContext context);
        void OnCorrer(InputAction.CallbackContext context);
        void OnSoltar(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
