using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    public float hueMin = 0f;
    public float hueMax = 1f;

    public float saturationMin = 0.7f;
    public float saturationMax = 1f;
    public float valueMin = 0.7f;
    public float valueMax = 1f;

    public float arrangeRange = 0.5f;

    public float emissionIntensity = 5f;

    public float destroyDelay = 1f;
    private bool isDestroyed = false;

    public ParticleSystem environmentParticle;
    public MeshRenderer holeMeshRenderer;
    private NavMeshAgent agent;

    public ParticleSystem destroyParticle;
    public AudioSource destroyAudio;
    public GameObject modelObject;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.SetDestination(new Vector3(-3f, 5f, 2f));
        agent.speed *= Random.Range(0.8f, 1.5f);

        RandomColor();

        Invoke(nameof(Destroy),3f);
    }

    private void RandomColor()
    {
        var color = Random.ColorHSV(hueMin, hueMax, saturationMin,saturationMax,valueMin,valueMax);
        var main = environmentParticle.main;

        main.startColor = new ParticleSystem.MinMaxGradient(color,color * Random.Range(1f - arrangeRange, 1f + arrangeRange));

        var renderer = environmentParticle.GetComponent<ParticleSystemRenderer>();
        renderer.material.SetColor("_EmissionColor", color * emissionIntensity);
        holeMeshRenderer.material.SetColor("_EmissionColor", color * emissionIntensity);

        main = destroyParticle.main;

        main.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1f - arrangeRange, 1f + arrangeRange));

        renderer = destroyParticle.GetComponent<ParticleSystemRenderer>();
        renderer.material.SetColor("_EmissionColor", color * emissionIntensity);
    }

    private void Destroy()
    {
        if(isDestroyed) return;

        isDestroyed = true;

        destroyParticle.Play();
        destroyAudio.Play();

        environmentParticle.Stop();
        agent.enabled = false;
        modelObject.SetActive(false);

        Destroy(gameObject, destroyDelay);
    }
}
