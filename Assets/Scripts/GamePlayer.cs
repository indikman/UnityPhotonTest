using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    public float MoveSpeed, RotationalSpeed;

    float Horizontal, Vertical;

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * MoveSpeed * Vertical * Time.deltaTime);
        transform.Rotate(Vector3.up * Horizontal * Time.deltaTime * RotationalSpeed);
    }
}
