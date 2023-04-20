using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrainBasedByY : MonoBehaviour
{
    [SerializeField]
    Defender Defenderer;

    public Damage DamageOverTime;

    public float DepthResistance;

    AdaptiveValue.AdaptiveLayer Mod;

    private void Start()
    {
        Mod = new AdaptiveValue.AdaptiveLayer();
        DamageOverTime.Value.AddLayer(Mod);
    }
    private void FixedUpdate()
    {
        Mod.ChangeValues(-transform.position.y / DepthResistance, 1);
        Defenderer.TakeDamage(DamageOverTime);
    }
}
