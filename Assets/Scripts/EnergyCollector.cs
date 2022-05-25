using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCollector : MonoBehaviour
{
    //Memeber Variables
    PlayerBase playerBase;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = FindObjectOfType<PlayerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        EnergyPacket energyPacket = otherGameObject.GetComponent<EnergyPacket>();
        if (energyPacket != null)   
        {
            if (playerBase != null)
            {
                playerBase.AddEnergy(energyPacket.EnergyPacketSize);
            }
            Destroy(otherGameObject);
        }
        
    }
}
