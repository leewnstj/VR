using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    public float destroyDelay = 1f;
    private bool isDestroyed = false;

    private void Start()
    {
        OnCreated?.Invoke();

        Invoke(nameof(Destroy),3f);
    }

    private void Destroy()
    {
        if(isDestroyed) return;

        isDestroyed = true;

        Destroy(gameObject, destroyDelay);
        OnDestroyed?.Invoke();
    }
}
