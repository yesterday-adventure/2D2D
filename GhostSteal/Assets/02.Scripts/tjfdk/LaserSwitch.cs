using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : Item
{
    [SerializeField] private List<GameObject> lasers = new List<GameObject>();

    private bool isOff = false;

    public override void item(GameObject target)
    {
        SoundManager.instance.PlaySE("MP_Chain Clink");

        if (!isOff)
        {
            Move.Instance.curItem = null;
            StartCoroutine(OffLaser());
            isOff = true;
        }
    }

    IEnumerator OffLaser()
    {
        foreach (GameObject obj in lasers)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                yield return new WaitForSeconds(0.15f);
            }
        }
        yield return StartCoroutine(OnLaser());
    }

    IEnumerator OnLaser()
    {
        foreach (GameObject obj in lasers)
        {
            if (obj != null)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.15f);
            }
        }
        isOff = false;
        yield return null;
    }
}
