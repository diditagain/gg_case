using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GGPlugins.GGStateMachine.Scripts.Abstract;
using UnityEngine;


namespace Challenges._1._GGStateMachineCharacterPhysics.Scripts.States {
    public class FallingState : GGStateBase
    {
        float _gravity;
        Transform _transform;
        Vector3 _velocity;
        bool _isGrounded;
        float _speed = 0;

        public FallingState(float gravity, Transform transform)
        {
            _gravity = gravity;
            _transform = transform;
        }

        public override void Setup()
        {
            TerrainCheck.currentInstance.IsGrounded += CheckGrounded;

        }

        public override async UniTask Entry(CancellationToken cancellationToken)
        {
            while (!_isGrounded)
            {
                StartFall();
                await UniTask.Yield(cancellationToken);
            }
            StateMachine.SwitchToState<IdleState>();
        }

        public override async UniTask Exit(CancellationToken cancellationToken)
        {
        }

        public void StartFall()
        {
            
            _speed += _gravity * 5/6 * Time.fixedDeltaTime;
            _velocity = (Vector3.down * _speed);
            _transform.Translate(_velocity);
            Debug.Log(_velocity);
        }


        public override void CleanUp()
        {
            _isGrounded = false;
        }

        public void CheckGrounded(bool isGrounded)
        {
            _isGrounded = isGrounded;
            Debug.Log("From interface" + _isGrounded);
        }
        

        #region The following overrides are optional and independent of parameter count

        /// <summary>
        /// Called when the machine starts
        /// </summary>
        public override void OnMachineStarted()
        {
            base.OnMachineStarted();
        }

        /// <summary>
        /// Called when the machine starts and this is the first state
        /// </summary>
        public override void OnMachineStartState()
        {
            base.OnMachineStartState();
        }

        /// <summary>
        /// Called after all the states have exit & cleaned up and the machine is exiting
        /// </summary>
        public override void OnMachineExit()
        {
            base.OnMachineExit();
        }

        #endregion
    }
}


