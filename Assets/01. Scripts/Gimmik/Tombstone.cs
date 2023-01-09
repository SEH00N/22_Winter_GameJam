using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tombstone : MonoBehaviour
{
    public float time = 0.1f;

    public void Move()
    {
        bool saveBool = Physics.Raycast(transform.position, Vector3.up,out RaycastHit hitInfo,100,1<<6);
        if(hitInfo.point != Vector3.zero)
            transform.DOMove(hitInfo.point,time);
    }
}
