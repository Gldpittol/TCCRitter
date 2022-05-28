using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMine : MonoBehaviour
{
    public GameObject minePrefab;
    public Transform mineSpawnPos;

    private Animator animator;
    private EnemyController myController;
    private bool canMove = true;
    private Vector2 moveDestination;
    private Vector2 originalPos;
    private float currentTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        myController = GetComponent<EnemyController>();
        DeployNextBomb();
    }

    private void Update()
    {
        currentTime+=Time.deltaTime / myController.delayBetweenAttacks;
        if (canMove)
        {
            transform.position = Vector2.Lerp(originalPos, moveDestination, currentTime);
        }
    }

    public void DeployNextBomb()
    {
        canMove = true;
        currentTime = 0;
        CalculateDirection();
        StartCoroutine(DeployBombCoroutine());
    }

    private void CalculateDirection()
    {
        moveDestination = PlayerManager.Instance.transform.position;
        originalPos = transform.position;

        float scaleX = Mathf.Abs(transform.localScale.x);
        if (moveDestination.x < transform.position.x) scaleX = -scaleX;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);   
    }

    public void SpawnBomb()
    {
        GameObject temp = Instantiate(minePrefab, mineSpawnPos.position, Quaternion.identity);
        temp.GetComponent<Mine>().damage = myController.baseDamage;
        canMove = true;
    }

    public IEnumerator DeployBombCoroutine()
    {
        yield return new WaitForSeconds(myController.delayBetweenAttacks);
        animator.Play("EnemyMineDeploy");
        canMove = false;
        while (!canMove) yield return null;
        animator.Play("EnemyMineRun");
        DeployNextBomb();
    }
}
