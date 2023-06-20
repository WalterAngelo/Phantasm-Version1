using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public PlayerController playerController;
    public float sphereRadius;
    public float maxDistance;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public GameObject currentHitObject;
    public GameObject currentHitObjectRay;
    public GameObject flashlight;

    public LayerMask layerMask;
    public Transform flashlightTransform;

    private float _currentHitDistance;
    private float _currentHitDistanceRay;
    public void Start()
    {
        flashlight.SetActive(false);
    }

    public void Update()
    {
        if(flashlight.activeInHierarchy)
        {
            if (Physics.SphereCast(flashlightTransform.position, sphereRadius, flashlightTransform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
            {
                currentHitObject = hitinfo.transform.gameObject;
                _currentHitDistance = hitinfo.distance;
                if (hitinfo.collider.tag == "ShadowEnemy")
                {
                    currentHitObject.GetComponent<EnemyController>().isDead = true;
                }
            }
            else
            {
                currentHitObject = null;
                _currentHitDistance = maxDistance;
            }

            if(Physics.Raycast(flashlightTransform.position, flashlightTransform.TransformDirection(Vector3.forward), out RaycastHit hitinfoRay, maxDistance))
            {
                currentHitObjectRay = hitinfoRay.transform.gameObject;
                _currentHitDistanceRay = hitinfoRay.distance;
                if (hitinfoRay.collider.tag == "ShadowEnemy")
                {
                    currentHitObjectRay.GetComponent<EnemyController>().isDead = true;
                }else if(hitinfoRay.collider.tag == "FirstShadowEnemy")
                {
                    playerController.RunFirstEnemyMonologue();
                    currentHitObjectRay.GetComponent<EnemyController>().isDead = true;
                }
            }
            else
            {
                currentHitObjectRay = null;
                _currentHitDistanceRay = maxDistance;
            }
        }
    }
    public void ToggleFlashlight()
    {
        if (flashlight.activeInHierarchy)
        {
            turnOff.Play();
        }else
        {
            turnOn.Play();
        }
        flashlight.SetActive(!flashlight.activeInHierarchy);
    }
}
