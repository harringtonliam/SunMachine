using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnergy : MonoBehaviour
{
    [SerializeField] EnergyPacket energyPacketPrefab;
    [SerializeField] Transform towerPoint;
    [SerializeField] Transform energy;
    [SerializeField] Transform energyEndMovePoint;
    [SerializeField] bool towerActive = true;
    [Tooltip("In Seconds")][SerializeField] float rateOfProduction = 5f;
    [SerializeField] float energyMovementRate = 2f;

    //Member vaiables
    PlayerBase playerBase;
    Vector3 energyStartPoint;



    void Start()
    {
        playerBase = FindObjectOfType<PlayerBase>();
        StartCoroutine(ProduceEnergy());

        energyStartPoint = energy.position;

    }

    private void Update()
    {
        MoveEnergy();
    }

    private void MoveEnergy()
    {
        var movementthisFrame = energyMovementRate * Time.deltaTime;
        if (energy.position == energyEndMovePoint.position)
        {
            energy.position = energyStartPoint;
        }
        else
        {
            energy.position = Vector3.MoveTowards(energy.position, energyEndMovePoint.position, movementthisFrame);
        }
    }

    IEnumerator ProduceEnergy()
    {
        while(towerActive)
        {
            if (energyPacketPrefab != null)
            {
               EnergyPacket energyPacket =  Instantiate(energyPacketPrefab, towerPoint.position, transform.rotation);
               energyPacket.transform.parent = transform;
            }
            yield return new WaitForSeconds(rateOfProduction);

        }

    }

}
