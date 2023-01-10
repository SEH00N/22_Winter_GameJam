using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private List<BallRotator> rotators = new List<BallRotator>(); 
    private BallController ballController = null;

    [SerializeField] float rotatorDetectRadius = 10f;
    public int stageIndex = 0;

    public void Init(int stageIndex)
    {
        this.stageIndex = stageIndex;

        ballController = transform.Find("Ball").GetComponent<BallController>();
        transform.GetComponentsInChildren<BallRotator>(rotators);

        rotators.ForEach(rotator => rotator.Init(rotatorDetectRadius));
        ballController.Init(rotatorDetectRadius);
    }
}
