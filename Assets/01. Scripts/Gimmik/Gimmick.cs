using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gimmick : PoolableMono
{
    [SerializeField] List<Decision> decisions = new(); 
    [SerializeField] UnityEvent action;

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        foreach(var decision in decisions){
            if(decision.Desition() == false)
                return;
        }        
            action.Invoke();
    }
}
