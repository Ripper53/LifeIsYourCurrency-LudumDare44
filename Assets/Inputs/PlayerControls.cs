// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerControls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class PlayerControls : InputActionAssetReference
{
    public PlayerControls()
    {
    }
    public PlayerControls(InputActionAsset asset)
        : base(asset)
    {
    }
    [NonSerialized] private bool m_Initialized;
    private void Initialize()
    {
        // Movement
        m_Movement = asset.GetActionMap("Movement");
        m_Movement_Direction = m_Movement.GetAction("Direction");
        // Harvest
        m_Harvest = asset.GetActionMap("Harvest");
        m_Harvest_Grab = m_Harvest.GetAction("Grab");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Movement = null;
        m_Movement_Direction = null;
        m_Harvest = null;
        m_Harvest_Grab = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Movement
    private InputActionMap m_Movement;
    private InputAction m_Movement_Direction;
    public struct MovementActions
    {
        private PlayerControls m_Wrapper;
        public MovementActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Direction { get { return m_Wrapper.m_Movement_Direction; } }
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
    }
    public MovementActions @Movement
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new MovementActions(this);
        }
    }
    // Harvest
    private InputActionMap m_Harvest;
    private InputAction m_Harvest_Grab;
    public struct HarvestActions
    {
        private PlayerControls m_Wrapper;
        public HarvestActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Grab { get { return m_Wrapper.m_Harvest_Grab; } }
        public InputActionMap Get() { return m_Wrapper.m_Harvest; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(HarvestActions set) { return set.Get(); }
    }
    public HarvestActions @Harvest
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new HarvestActions(this);
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get

        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.GetControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
}
