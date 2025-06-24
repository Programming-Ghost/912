using System.Collections;
using UnityEngine;

// Made by Rajendra Abhinaya, 2023 — Modified by Ahmad & Copilot

[RequireComponent(typeof(AudioSource))]
public class Despawn : MonoBehaviour
{
    [Header("Despawn Settings")]
    [SerializeField] private int despawnPercentage = 100;
    [SerializeField] private float despawnTime = 10f;
    [SerializeField] private float distanceFromPlayer = 20f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 1f;
    [SerializeField] private float volumeVariation = 0.1f;
    [SerializeField] private float pitchVariation = 0.1f;

    private GameObject player;
    private AudioSource audioSource;

    public void SetVariables(int despawnPercentage, float despawnTime, float distanceFromPlayer, GameObject player, AudioClip clip, float volume, float volumeVariation, float pitchVariation)
    {
        this.despawnPercentage = despawnPercentage;
        this.despawnTime = despawnTime;
        this.distanceFromPlayer = distanceFromPlayer;
        this.player = player;
        this.clip = clip;
        this.volume = volume;
        this.volumeVariation = volumeVariation;
        this.pitchVariation = pitchVariation;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomizedClip();
    }

    private void PlayRandomizedClip()
    {
        if (clip != null)
        {
            float pitch = 1f + Random.Range(-pitchVariation / 2f, pitchVariation / 2f);
            float vol = Mathf.Clamp01(volume + Random.Range(-volumeVariation, volumeVariation));
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clip, vol);
        }
    }

    public void BeginCoroutine(string mode)
    {
        switch (mode)
        {
            case "Timed":
                StartCoroutine(DespawnCoroutine());
                break;
            case "Distance from Player":
                if (player != null)
                    StartCoroutine(CheckDistance());
                break;
        }
    }

    private void DespawnDebris()
    {
        int totalChildren = transform.childCount;
        int despawnCount = Mathf.RoundToInt(totalChildren * despawnPercentage / 100f);

        for (int i = totalChildren - 1; i >= totalChildren - despawnCount; i--)
        {
            if (i >= 0)
                Destroy(transform.GetChild(i).gameObject);
        }
    }

    private IEnumerator CheckDistance()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            if (player == null) yield break;

            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > distanceFromPlayer)
            {
                DespawnDebris();
                yield break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator DespawnCoroutine()
    {
        yield return new WaitForSeconds(despawnTime);
        DespawnDebris();
    }
}