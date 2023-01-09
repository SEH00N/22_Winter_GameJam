using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDecistion : Decision
{
    bool trigget;
    public override bool Desition()
    {
        return trigget;
    }
    private void OnTriggerEnter(Collider other) {
        trigget= true;
    }
    private void OnTriggerExit(Collider other) {
        trigget= false;
    }
}
