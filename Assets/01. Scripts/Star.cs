using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    List<GameObject> stars;

    private void Start() {
        GetComponentsInChildren<GameObject>(stars);
        stars.RemoveAt(0);
    }
    public void ChkStar(){
        int count = 0;
        foreach(GameObject star in stars){
            if(star.activeSelf)
                count++;
        }
        //몇개의 별인지 확인하는거
    }
}
