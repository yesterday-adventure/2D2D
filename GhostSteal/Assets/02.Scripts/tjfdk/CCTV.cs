using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CCTV : MonoBehaviour
{
    private GameObject itemAnim;

    private void Awake() {
        
        itemAnim = gameObject.transform.GetChild(0).GetComponent<GameObject>();
    }
    
    private void Update() {

        cctv();
    }

    public void cctv() {

        gameObject.transform.DOScaleX(5f, 2f).SetLoops(-1, LoopType.Yoyo); // 왜 안 되지
    }
}
