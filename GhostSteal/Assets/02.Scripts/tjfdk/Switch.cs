using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Item
{
    [SerializeField] private List<GameObject> cctvs = new List<GameObject>();
    [SerializeField] private NpcMove npc;
    private bool isOff = false;

    private Transform[] lights = new Transform[100];
    int idx = 0;
    Transform[] obj;

    public override void item(GameObject target)
    {
        SoundManager.instance.PlaySE("MP_Chain Clink");

        if (!isOff)
        {
            Move.Instance.curItem = null;
            OffCCTV();
            isOff = true;
        }
    }

    public void OffCCTV()
    {
        idx = 0;
        foreach (GameObject c in cctvs)
        {
            obj = c.GetComponentsInChildren<Transform>();
            foreach (Transform obj2 in obj)
            {
                if (obj2 != c.transform)
                {
                    obj2.gameObject.SetActive(false);
                    lights[idx++] = obj2;
                }
            }
        }
        npc.OnCCTV(transform);
    }
    public void OnCCTV()
    {
        Debug.Log("�����󤿤�!");
        for(int i = 0; i <= idx; i++)
        {
            if (lights[i] != null)
                lights[i].gameObject.SetActive(true);
        }
        isOff = false;
    }
}