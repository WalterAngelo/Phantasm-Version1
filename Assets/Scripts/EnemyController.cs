using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public bool isDead = false;
    public bool isIdle = false;

    private float _speed = 2f;
    private Animator _animator;
    private float _deathDelay = 2f;
    private float _deathTimer = 0;

    private void Start()
    {
        _animator = gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(_animator != null)
        {
            if(!isIdle)
            {
                _animator.SetTrigger("CrawlFast");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
                Vector3 direction = Vector3.RotateTowards(Vector3.forward, player.transform.position - transform.position, 2f, 0f);
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }

        if(isDead)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _deathTimer += Time.deltaTime;
            if(_deathTimer >= _deathDelay)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        _deathTimer = 0;
        GetComponent<AudioSource>().Play();
    }
}
