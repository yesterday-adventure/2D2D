using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    [SerializeField] private Transform otherVent;
    [SerializeField] protected GameObject itemAnim;

    private float cool = 1f;
    private bool isSelectPlayer = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Move.Instance.vent = true;
            isSelectPlayer = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isSelectPlayer && cool >= 1f)
        {
            item(GameManager.Instance.player);
        }

        cool += Time.deltaTime;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Move.Instance.vent = false;
            isSelectPlayer = false;
        }
    }

    public void item(GameObject target)
    {
        SoundManager.instance.PlaySE("MP_Mario Jumping");
        
        Anim();

        if (otherVent == null)
        {
            Debug.LogError($"{transform} : Vent Script otherVent is null!");
        }

        target.transform.position = new Vector3(otherVent.position.x,
            target.transform.position.y - transform.position.y + otherVent.position.y,
            target.transform.position.z);

        Invoke("Anim", 1f);
    }

    protected void Anim()
    {
        itemAnim.SetActive(!itemAnim.activeSelf);
    }
}