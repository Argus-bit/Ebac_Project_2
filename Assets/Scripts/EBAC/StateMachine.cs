using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

/*ublic class Test
{
    public enum Test2
    {
        NONE
    }
    public void Aa()
    {
        StateMachine<Test2> stateMachine = new StateMachine<Test2>();
        stateMachine.RegisterStates(Test.Test2.NONE, new StateBase());
    }

}*/
namespace Ebac.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dicionaryState;
        private StateBase _currentstate;
        public float timeToStartGame = 1f;

        //chave
        //public Dictionary<StateType, StateBase> dictionaryState;
        //public static StateMachine Instance;

        public StateBase CurrentState
        {
            get { return _currentstate; }
        }
        public void Init()
        {
            dicionaryState = new Dictionary<T, StateBase>();
        }
        public void RegisterStates(T typeEnum, StateBase state)
        {
            dicionaryState.Add(typeEnum, state);
        }
        public void SwitchState(T state, params object[] objs)
        {
            if (_currentstate != null) _currentstate.OnStateExit();
            _currentstate = dicionaryState[state];
            _currentstate.OnStateEnter(objs);
        }


        public void Update()
        {
            if (_currentstate != null) _currentstate.OnStateStay();
        }

        /*private void Awake()
        {
            dictionaryState = new Dictionary<StateType, StateBase>();
            dictionaryState.Add(StateType.NONE, new StateBase());
            SwitchState(StateType.NONE);
            Invoke(nameof(StartGame), timeToStartGame);
        }
        [Button]
        private void StartGame()
        {
            SwitchState(StateType.NONE);
        }
        public void SwitchState(StateType state)
        {
            if (_currentstate != null) _currentstate.OnStateExit();
            _currentstate = dictionaryState[state];
            _currentstate.OnStateEnter();
        }
    #if UNITY_EDITOR
    # region DEBUG
        [Button]
        private void ChangeStateToStarteX()
        {
            SwitchState(StateType.NONE);
        }
        [Button]
        private void ChangeStateToStarteY()
        {
            SwitchState(StateType.NONE);
        }
        #endregion
    #endif
        private void Update()
        {
            if (_currentstate != null) _currentstate.OnStateStay();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //SwitchState(StateType.DEAD);
            }
        }

        /*public void ResetPosition()
        {
            SwitchState(StateType.RESET_POSITION);
        }*/
    }
}

