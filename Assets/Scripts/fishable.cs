using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "hook")
        {
            HingeJoint attached = this.gameObject.AddComponent<HingeJoint>();
            attached.connectedBody = collision.collider.attachedRigidbody;
        }
    }
}
