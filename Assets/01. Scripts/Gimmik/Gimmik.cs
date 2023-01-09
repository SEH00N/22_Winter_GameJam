using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gimmik : MonoBehaviour
{
    [SerializeField] List<Decision> decisions = new(); 
    [SerializeField] UnityEvent action;
    void Update()
    {
        foreach(var decision in decisions){
            if(decision.Desition() == false)
                return;
        }        
            action.Invoke();
    }
}
