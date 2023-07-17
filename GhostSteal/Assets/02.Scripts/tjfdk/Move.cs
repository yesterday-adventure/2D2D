using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool canMove = true; // 움직일 수 있는 상태인지
    public bool isMove = true; // 움직이고 있는 상태인지

    private Rigidbody2D rigid;

    [SerializeField] private Item curItem;
    [SerializeField] private float speed;

    Vector3 dir;

    private void Awake() {
        
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        
        if (canMove)
            move();
    }

    private void move() {

        dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        dir.Normalize();       
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        Debug.Log("충돌중");

        if (Input.GetKeyDown(KeyCode.Space)) {

            curItem = other.GetComponent<Item>();
            curItem.item();
        }
    }
}