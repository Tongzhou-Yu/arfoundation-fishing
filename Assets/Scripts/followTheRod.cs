using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTheRod : MonoBehaviour
{
    public GameObject Rod;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Rod.gameObject.transform.position;
    }
}
