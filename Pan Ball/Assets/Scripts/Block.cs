using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip blockDamageSound;
    [SerializeField] GameObject starParticleEffectVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] sprites;

    //cached references
    Level level;

    // state variables
    [SerializeField] int timesHit;  //TODO serialized just for debugging purpose

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableObjects();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AfterHitProcess();
    }

    private void AfterHitProcess()
    {
        timesHit += 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            int spriteIndex = timesHit - 1;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.DecreaseBreakableObjects();
        TriggerStarParticleVFX();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(blockDamageSound, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore();
    }

    private void TriggerStarParticleVFX()
    {
        GameObject Sparkle = Instantiate(starParticleEffectVFX, transform.position, transform.rotation);
        Destroy(Sparkle, 2f);
    }


}