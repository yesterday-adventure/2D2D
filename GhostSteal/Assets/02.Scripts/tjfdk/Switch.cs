using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Item
{
    [SerializeField] private List<GameObject> cctvs = new List<GameObject>();
    private bool isOff = false;

    public override void item(GameObject target) {

        if(!isOff)
        {
            OffCCTV();
            isOff = true;
        }
    }

    public void OffCCTV()
    {
        foreach (GameObject c in cctvs)
        {
            Transform[] obj = c.GetComponentsInChildren<Transform>();
            foreach (Transform obj2 in obj)
            {
                if(obj2 != c.transform)
                {
                    obj2.gameObject.SetActive(false);
                }
            }
        }
    }

    public void OnCCTV()
    {
        foreach (GameObject c in cctvs)
        {
            Transform[] obj = c.GetComponentsInChildren<Transform>();
            foreach (Transform obj2 in obj)
            {
                if (obj2 != c.transform)
                {
                    obj2.gameObject.SetActive(true);
                }
            }
        }
    }
}