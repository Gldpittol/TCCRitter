using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThirdBoss : MonoBehaviour
{
    public float delayBeforeStarting = 4f;

    private EnemyController myController;
    private float maxHP;
    private void Start()
    {
        myController = GetComponent<EnemyController>();
        maxHP = myController.health;
        StartCoroutine(DelayBeforeStartingCoroutine());
        PlayerSpellCasting.Instance.UltimateBlock();
    }

    private IEnumerator DelayBeforeStartingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeStarting);
        /*SpawnLongFire();
        SpawnPermanentFire();
        SpawnMissile();*/
    }
}
