using System.IO.MemoryMappedFiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField] private float speed;

    Vector3 dir;
    Transform child;

    RaycastHit2D hit;
    Ray ray;

    private void Awake() {
        
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        
        move();

        hit = Physics2D.Raycast(transform.position, Vector3.right, 2f);

        if (hit.collider != null) {
            
            Debug.Log(hit.transform.name);

            if (Input.GetKeyDown(KeyCode.Space)) {
                
                child = hit.transform;

                if (transform.childCount != 0) {
                    
                    // 현재 들어있는 child를 밖으로 내보낸다 (setparent)
                    // transform.GetChild(0).SetParent();
                    // 위치는 새로 충돌한 hit의 위치로 지정해준다.
                    // 콜라이더를 다시 켜준다.

                    
                }

                child.SetParent(transform);
                child.localPosition = Vector3.zero;
                child.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }

        Debug.DrawRay(transform.position, Vector3.right * 2f, Color.red);
    }

    private void move() {

        dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        dir.Normalize();       
        rigid.velocity = dir * speed;
    }
}