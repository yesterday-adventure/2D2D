using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public void cavinet(GameObject target) {

        target.SetActive(!target.activeSelf);
        //못 움직이게
    }
}
