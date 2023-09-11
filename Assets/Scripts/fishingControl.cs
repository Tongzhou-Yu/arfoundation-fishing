using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingControl : MonoBehaviour
{
    public GameObject Rope;
    public GameObject fixedpoint1;
    public GameObject Rod;
    public GameObject fixedpoint2;
    public void fishing()
    {

            if (Rope.gameObject.active == false) {fixedpoint1.gameObject.transform.position= fixedpoint2.gameObject.transform.position; Rope.gameObject.SetActive(true);Rod.gameObject.SetActive(true); } else { Rope.gameObject.SetActive(false); Rod.gameObject.SetActive(false); }

    }
}
