using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CCTV : Item
{
    private GameObject itemAnim;
    private GameObject tlqlkf;

    private void Awake() {
        
        itemAnim = gameObject.transform.GetChild(0).GetComponent<GameObject>();
        tlqlkf = gameObject.transform.GetChild(1).GetComponent<GameObject>();
    }
    
    private void Update() {

        gameObject.transform.DOScaleX(5f, 2f).SetLoops(-1, LoopType.Yoyo); // 왜 안 되지
    }

    public void cctv() {

        
    }
}
