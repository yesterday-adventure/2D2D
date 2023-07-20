using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CCTV : Item
{
    [SerializeField] private GameObject view;
    
    private void Update() {

        view.transform.DOScaleX(5f, 2f).SetLoops(-1, LoopType.Yoyo); // 왜 안 되지
    }

    public override void item() {

        Anim();
        view.SetActive(!view.activeSelf);
    }
}
