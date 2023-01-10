using Cinemachine;
using UnityEngine;

public static class DEFINE
{
    public const int RotatorLayer = 1 << 6;
    public const int PlayerLayer = 1 << 7;

    private static BallController ball = null;
    public static BallController Ball {
        get {
            if(ball == null)
                //ball = GameObject.Find("Ball").GetComponent<Ball>();
                ball = GameObject.FindObjectOfType<BallController>();
            return ball;
        }
    }

    private static Transform staticCanvas = null;
    public static Transform StaticCanvas {
        get {
            if(staticCanvas == null)
                staticCanvas = GameObject.Find("GameManager/StaticCanvas").transform;
            
            return staticCanvas;
        }
    }
    
    private static Camera mainCam = null;
    public static Camera MainCam {
        get {
            if(mainCam == null)
                mainCam = Camera.main;

            return mainCam;
        }
    }

    private static CinemachineVirtualCamera cmMainCam = null;
    public static CinemachineVirtualCamera CmMainCam  {
        get {
            if(cmMainCam == null)
                cmMainCam = GameObject.Find("CmMainCam").GetComponent<CinemachineVirtualCamera>();

            return cmMainCam;
        }
    }
}
