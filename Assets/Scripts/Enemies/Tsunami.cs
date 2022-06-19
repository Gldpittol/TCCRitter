using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tsunami : MonoBehaviour
{
   private bool pushLeft = false;
   private BoxCollider2D myCol;
   private float delayBeforePush;
   private float forceIntensity;
   private float timeBeforeDestroy;
   private float tweenSpeed;
   private float tweenSize;
   private float animatorSpeed;

   public void Initialize(float delay, bool left, float intensity, float timeToDestroy, float speedTween, float sizeTween, float newAnimatorSpeed)
   {
      myCol = GetComponent<BoxCollider2D>();
      myCol.enabled = false;
      delayBeforePush = delay;
      pushLeft = left;
      forceIntensity = intensity;
      timeBeforeDestroy = timeToDestroy;
      tweenSpeed = speedTween;
      tweenSize = sizeTween;
      animatorSpeed = newAnimatorSpeed;
      StartCoroutine(PushCoroutine());
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Player"))
      {
         PlayerCollision.Instance.PlayerTakeDamage(1000);
      }
   }

   public IEnumerator PushCoroutine()
   {
      yield return new WaitForSeconds(delayBeforePush);
      transform.DOScale(new Vector3(tweenSize, tweenSize, tweenSize), tweenSpeed);
      GetComponent<Animator>().speed = animatorSpeed;
      myCol.enabled = true;
      Vector2 forceVector = new Vector2(pushLeft ? -1 : 1, 0);
      PlayerMovement.Instance.beingPushed = true;
      PlayerManager.Instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      PlayerManager.Instance.GetComponent<Rigidbody2D>().AddForce(forceVector * forceIntensity, ForceMode2D.Impulse);
      yield return new WaitForSeconds(1f);
      PlayerMovement.Instance.beingPushed = false;
      Destroy(gameObject);
   }
}
