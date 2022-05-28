using System;
using System.Collections;
using UnityEngine;

public class SpawnVFX : MonoBehaviour
{
    [SerializeField] private PoolObject _poolObject;

    [SerializeField] private int _count = 2;

    [SerializeField] private EnumAbilities _enumAbilities;
    
    

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        StartCoroutine(SpawnAbility());
    }

    IEnumerator SpawnAbility()
    {
        var count = 0;
        while (count < _count)
        {
            var forward = transform.forward;
            var prefab = _poolObject.GetObject(_enumAbilities.ToString());
            prefab.transform.position = transform.position + forward * (count * 2.4f);// + forward * 2f;
            if (prefab.TryGetComponent(out Pillars pillars))
                pillars.Install(count + 1);
            prefab.transform.forward = forward;

            yield return new WaitForSeconds(.2f);
            count++;
        }
    }
}