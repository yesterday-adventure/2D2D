using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool canMove = true; // 움직일 수 있는 상태인지
    public bool pot = false; // 움직이고 있는 상태인지 -> 안 쓰는데 지워버릴까
    public bool vent = false; // 밴트 타고있는지 아닌지

    private Rigidbody2D rigid;
    private PolygonCollider2D col;

    float x;
    float y;

    [SerializeField] private Item curItem;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask itemLayer;

    Vector3 dir;

    private void Awake() {
        
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
    }

    private void Update() {
        
        if (canMove)
            move();


        if (pot && x != 0) { // 움직일 땐 콜라이더 켜주고

            col.enabled = true;
        }
        else if (pot && x == 0) { // 아닐 땐 꺼주고

            col.enabled = false;
        }


        Vector3 raycastOrigin = transform.position;
        RaycastHit2D hit = Physics2D.CircleCast(raycastOrigin, 1f, Vector2.zero, 0f, itemLayer);

        if (hit) {

            if (Input.GetKeyDown(KeyCode.Space)) {

                curItem = hit.collider.gameObject.GetComponent<Item>();
                curItem.item(gameObject); // null
            }
        }
    }

    private void move() {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (vent)
            dir = new Vector3(x, y, 0f);
        else
            dir = new Vector3(x, 0, 0f);

        rigid.velocity = dir.normalized * speed;
    }

    void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}