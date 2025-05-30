using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestColliderEvent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print($"OnCollisionEnter2D: {name} with {collision.gameObject.name}");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print($"OnCollisionStay2D: {name} with {collision.gameObject.name}");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print($"OnCollisionExit2D: {name} with {collision.gameObject.name}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print($"OnTriggerEnter2D: {name} with {collision.gameObject.name}");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print($"OnTriggerStay2D: {name} with {collision.gameObject.name}");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print($"OnTriggerExit2D: {name} with {collision.gameObject.name}");
    }
}
