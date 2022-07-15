using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GGPlugins.GGStateMachine.Scripts.Abstract;
using UnityEngine;

namespace Challenges._1._GGStateMachineCharacterPhysics.Scripts.States
{
    public class MovingState : GGStateBase<Vector3>
    {
        Transform _transform;
        float _acceleration;
        float _maxSpeed;
        

        Vector3 _direction;
        Vector3 _velocity;
        float _speed = 10;
        public MovingState(float maxSpeed, float acceleration, Transform transform)
        {
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            _transform = transform;
        }
        public override void Setup(Vector3 direction)
        {
            _direction = direction;
            _velocity = (direction * _speed * Time.fixedDeltaTime);

        }

        public override async UniTask Entry(CancellationToken cancellationToken)
        {
            _transform.Translate(_velocity);
            Debug.Log(_velocity);
            Debug.Log("ExampleState: Entry");
            //await UniTask.Delay(TimeSpan.FromSeconds(2f), cancellationToken: cancellationToken);
            StateMachine.SwitchToState<IdleState>();
        }

        public override async UniTask Exit(CancellationToken cancellationToken)
        {
            Debug.Log("ExampleState: Exit");
        }

        public override void CleanUp()
        {
        }
    }
}