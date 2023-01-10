using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DEFINE;

public class Portal : Gimmick
{
    [SerializeField] Transform exitTrm;
    public override void ActiveGimmick()
    {
        Ball.transform.position = exitTrm.transform.position;
    }
}
