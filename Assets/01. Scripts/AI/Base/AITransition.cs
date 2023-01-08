using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AITransition : MonoBehaviour
{
    public List<AIDecision> decisions; //다른 상태로 넘어갈 수 있는 조건들

    public AIState positiveResult; //해당 조건이 참일 때 넘어갈 상태
    public AIState negativeResult; //해당 조건이 참이 아닐 때 넘어갈 상태

    [Space(10f)]
    public UnityEvent onPositiveEvent;
}
