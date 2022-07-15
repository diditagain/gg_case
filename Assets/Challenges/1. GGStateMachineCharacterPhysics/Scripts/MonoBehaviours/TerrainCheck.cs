using Challenges._1._GGStateMachineCharacterPhysics.Scripts;
using Challenges._1._GGStateMachineCharacterPhysics.Scripts.States;
using GGPlugins.GGStateMachine.Scripts.Abstract;
using UnityEngine;
using System;


public class TerrainCheck : MonoBehaviour, IStateMachineUser
{
    public static TerrainCheck currentInstance;

    private IGGStateMachine _stateMachine;
    private Challenges._1._GGStateMachineCharacterPhysics.Scripts.MonoBehaviours.CharacterController characterController;

    public LayerMask characterBlocker;

    #region CharacterParams
    float _characterHeight;
    float _characterRadius;
    #endregion

    #region Local Vars
    private float _rayLength;
    private float _rayHeight;
    public bool isGrounded;
    #endregion
    public void SetStateMachine(IGGStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    private void Awake()
    {
        currentInstance = this;
    }
    void Start()
    {
        characterController = GetComponent<Challenges._1._GGStateMachineCharacterPhysics.Scripts.MonoBehaviours.CharacterController>();
        var characterConfig = characterController.GetConfigValues();
        _characterHeight = characterConfig.CharacterHeight;
        _characterRadius = characterConfig.CharacterRadius;
        _rayHeight = _characterHeight;
        _rayLength = _rayHeight + 1;

    }

    public event Action <bool> IsGrounded;
    void Update()
    {
        CheckGround();
        if (_stateMachine.CheckCurrentState<FallingState>())
        {
            IsGrounded(isGrounded);
        }
        


    }

    public void CheckGround()
    {
        Vector3 rayPos = new Vector3(transform.position.x, transform.position.y + _rayHeight, transform.position.z);
        Ray ray = new Ray(rayPos, -transform.up);
        RaycastHit tempHit = new RaycastHit();
        if (Physics.SphereCast(rayPos, 0.10f, -transform.up, out tempHit, _rayLength, characterBlocker))
        {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, tempHit.point.y + 0.10f, transform.position.z);
        }
        else
        {
            if (isGrounded)
            {
            _stateMachine.SwitchToState<FallingState>();
            } 
            isGrounded = false;
            
        }
    }


}
