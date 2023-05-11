using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Calls functionality when a collision occurs
/// </summary>
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class OnBallCollision : MonoBehaviour
{
    [Serializable] public class CollisionEvent : UnityEvent<Collision> { }

    // When the object enters a collision
    public CollisionEvent OnEnter = new CollisionEvent();

    // When the object exits a collision
    public CollisionEvent OnExit = new CollisionEvent();

    // collision sound delay
    float soundDelay = 0.0f;

    // get components
    AudioSource audioSource;
    Rigidbody rigidBody;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // update sound delay
    void Update()
    {
        if (soundDelay > 0)
            soundDelay -= Time.deltaTime;
    }

    // play sound on collision if delay is zero
    private void OnCollisionEnter(Collision collision)
    {
        OnEnter.Invoke(collision);

        // abort sound if too many collisions at once
        if (soundDelay > 0)
            return;
        else soundDelay = 0.1f;
        // get object's current velocity
        float velocity = rigidBody.velocity.magnitude;
        // play impact sound based on velocity
        float volume = Math.Clamp(velocity / 2, 0, 6);
        audioSource.PlayOneShot(audioSource.clip, volume);
        Debug.Log("Velocity: " + rigidBody.velocity.magnitude + ", Volume: " + volume);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnExit.Invoke(collision);
    }

    //SelectEnterEvent = myEvent
    /*
    private int myEvent()
    {
        Debug.Log("IM AWAKE!!!");
        return 0;
    }
    */

    private void OnValidate()
    {
        if (TryGetComponent(out Collider collider))
            collider.isTrigger = false;
    }
}