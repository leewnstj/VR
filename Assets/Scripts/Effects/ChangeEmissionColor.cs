using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    public float emissionIntensity = 5f;
    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        target.material.SetColor("_EmissionColor", color * emissionIntensity);
    }
}
