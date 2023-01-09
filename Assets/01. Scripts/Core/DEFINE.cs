using Cinemachine;
using UnityEngine;

public class DEFINE
{
    public const int GroundLayer = 1 << 6;

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
