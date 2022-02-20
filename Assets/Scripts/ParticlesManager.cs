using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParticlesManager : MonoBehaviour
{
    public GameObject particlesPrefab; 
    private GameObject instantiatedSparkles;
    public void PlayParticles(GameObject obj)
    {
        if (!obj.GetComponent<Interactable>()) return;
        if (obj.GetComponent<Interactable>().Undiscovered)
            instantiatedSparkles = Instantiate(particlesPrefab, obj.transform.position, Quaternion.identity);
    }

    public void PlayParticlesForRecipe(GameObject obj)
    {
        instantiatedSparkles = Instantiate(particlesPrefab, obj.transform.position, Quaternion.identity);
    }

    public void StopParticles()
    {
        if (instantiatedSparkles)
        {
            StartCoroutine(DestroyParticles());
        }
    }

    public void DelayedStopParticles()
    {
        if (instantiatedSparkles)
        {
            StartCoroutine(DestroyParticlesDelay());
        }
    }

    private IEnumerator DestroyParticles()
    {
        yield return new WaitForSeconds(.4f);
        instantiatedSparkles.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(2);
        Destroy(instantiatedSparkles);
    }
    
    private IEnumerator DestroyParticlesDelay()
    {
        yield return new WaitForSeconds(3f);
        instantiatedSparkles.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(2);
        Destroy(instantiatedSparkles);
    }
}
