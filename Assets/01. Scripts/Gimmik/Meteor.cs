using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed;
    [SerializeField] Vector3 targetPos;
    public void Move()
    {
        transform.DOMove(targetPos,speed);
    }
}
