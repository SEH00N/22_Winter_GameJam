using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [SerializeField] List<AIAction> actions = null; //내가 현재 상태에서 수행해야 할 액션들
    [SerializeField] List<AITransition> transitions = null; //다른 상태로 넘어갈 수 있는 조건들

    private AIBrain brain = null;

    private void Awake()
    {
        brain = transform.parent.parent.GetComponent<AIBrain>();
    }
    
    public void UpdateState()
    {
        foreach(AIAction action in actions) //현재 상태에서 수행햐여 될 액션 모두 실행
            action.TakeAction();

        foreach(AITransition transition in transitions) //다음 상태 선정을 위한 트랜지션 확인
        {
            bool result = false;

            foreach(AIDecision decision in transition.decisions) //다른 상태로 넘어갈 수 있는 조건 확인
            {
                if(decision == null) continue;

                result = decision.MakeDecision();
                if(!result) break;
            }

            if(result) //모든 조건이 참일 때
            {
                if(transition.positiveResult != null)
                {
                    brain.ChangeToState(transition.positiveResult); //positive 상태로 현재 상태 변경
                    transition.onPositiveEvent?.Invoke();
                }
            }
            else //참이 아닌 조건이 있을 때
            {
                if(transition.negativeResult != null) 
                    brain.ChangeToState(transition.negativeResult); //negative 싱태로 현재 상태 변경
            }
        }
    }
}
