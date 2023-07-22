using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject distination;
    [SerializeField] protected GameObject itemAnim;

    private float cool = 1f;
    private bool isSelectPlayer = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isSelectPlayer && cool >= 1f)
        {
            item(GameManager.Instance.player);
        }

        cool += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Move.Instance.elevator = true;
            isSelectPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Move.Instance.elevator = false;
            isSelectPlayer = false;
        }
    }

    public void item(GameObject target)
    {
        Anim();
        cool = 0f;
        target.transform.position = new Vector3(target.transform.position.x,
            target.transform.position.y + distination.transform.position.y - transform.position.y,
            target.transform.position.z);
        Invoke("Anim", 1f); 
    }

    protected void Anim()
    {

        itemAnim.SetActive(!itemAnim.activeSelf);
    }
}
