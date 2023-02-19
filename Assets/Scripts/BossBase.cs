using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK
    }

    public class BossBase : MonoBehaviour
    {
        [Header("Lerp")]
        public Transform target;
        public float lerpSpeed = 1f;
        private Vector3 _pos;
        public float _currentSpeed;

        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;
        private StateMachine<BossAction> stateMachine;
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.RegisterStates(BossAction.INIT, new BossStatesInit());
        }
        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            SwitchState(BossAction.INIT);
        }
        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this, gameObject, transform, this);
        }
        public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }
        void Update()
        {
            _pos = target.position;
            _pos.y = target.position.y;
            _pos.z = target.position.z;
            transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
            transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        }
    }
}
