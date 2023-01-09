
using DG.Tweening;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float time = 0.1f;
    public void Move()
    {
        bool saveBool = Physics.Raycast(transform.position, Vector3.down,out RaycastHit hitInfo,100,1<<6);
        if(hitInfo.point != Vector3.zero)
            transform.DOMove(hitInfo.point,time);
    }
}
