using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMov : MonoBehaviour
{
    
    [SerializeField] private Vector2 speed = new Vector2(20,20);

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
