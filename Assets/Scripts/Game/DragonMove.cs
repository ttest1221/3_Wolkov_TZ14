using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    private Dragon _dragon;
    private void Start()
    {
        _dragon = FindAnyObjectByType<Dragon>();
    }
    private void OnMouseDown()
    {
        _dragon.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }
}
