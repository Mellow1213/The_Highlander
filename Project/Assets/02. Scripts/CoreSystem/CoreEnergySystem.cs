using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreEnergySystem : MonoBehaviour
{
    [SerializeField] private float coreEnergy;

    public void setCoreEnergy(float coreEnergy) { this.coreEnergy = coreEnergy; }
    public float getCoreEnergy() { return coreEnergy; }

}
