using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float angle = 5f;

    void Update()
    {
        transform.Rotate(Vector3.up, angle, Space.World);
    }
}
