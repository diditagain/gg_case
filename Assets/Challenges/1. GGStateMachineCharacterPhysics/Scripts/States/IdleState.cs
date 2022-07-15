using System.Threading;
using Cysharp.Threading.Tasks;
using GGPlugins.GGStateMachine.Scripts.Abstract;
using Challenges._1._GGStateMachineCharacterPhysics.Scripts.MonoBehaviours;
using UnityEngine;

namespace Challenges._1._GGStateMachineCharacterPhysics.Scripts.States
{
    /// <summary>
    /// You can edit this
    /// </summary>
    public class IdleState : GGStateBase
    {
    

        public override void Setup()
        {
        }

        public override async UniTask Entry(CancellationToken cancellationToken)
        {
            Debug.Log("idle");
        }

        public override async UniTask Exit(CancellationToken cancellationToken)
        {
        }

        public override void CleanUp()
        {
        }
    }
}
