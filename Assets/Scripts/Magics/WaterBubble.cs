using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubble : MonoBehaviour
{
    public AudioClip explodeClip;
    private List<GameObject> damagedEnemiesList = new List<GameObject>();
    private Collider2D myCollider;
    private SpriteRenderer myRenderer;
    [SerializeField] private MagicData magic;
    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WaterBubbleCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (damagedEnemiesList.Contains(col.gameObject)) return;
            
            damagedEnemiesList.Add(col.gameObject);
            var enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(GetComponent<SpellDamager>().damage);
        }
    }
    
    private IEnumerator WaterBubbleCoroutine()
    {
        myCollider.enabled = false;
        myRenderer.color = new Color(myRenderer.color.r, myRenderer.color.g, myRenderer.color.b, 0.2f);
        
        yield return new WaitForSeconds(magic.delayBetweenHits);
        myCollider.enabled = true;
        myRenderer.color = new Color(myRenderer.color.r, myRenderer.color.g, myRenderer.color.b, 1f);
        GetComponent<AudioSource>().PlayOneShot(explodeClip);
        
        yield return new WaitForSeconds(magic.duration);
        Destroy(gameObject);
    }
}
