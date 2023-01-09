using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float time;
    public void Move()
    {
        Physics.Raycast(transform.position, Vector3.down,out RaycastHit hitInfo,50,1<<6);
        transform.DOMove(hitInfo.point,time);
    }
}
