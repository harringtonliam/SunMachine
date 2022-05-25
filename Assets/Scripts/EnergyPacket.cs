using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPacket : MonoBehaviour
{
    //paraemeters
    [SerializeField] int energyPacketSize = 5;
    [SerializeField] float rateofMovement = 10f;

    //Membervariables
    Vector3 targetPosition;

    //Properties
    public int EnergyPacketSize
    {
        get { return energyPacketSize; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        EnergyCollector energyCollector = FindObjectOfType<EnergyCollector>();
        if (energyCollector != null)
        {
            targetPosition = energyCollector.transform.position;
            transform.LookAt(targetPosition);
        }
        else
        {
            targetPosition = transform.position;
        }


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var movementThisFrame = rateofMovement * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);
   
    }
}
