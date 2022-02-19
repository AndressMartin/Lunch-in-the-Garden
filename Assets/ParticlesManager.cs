using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParticlesManager : MonoBehaviour
{
    public GameObject sparklesPrefab; 
    private GameObject instantiatedSparkles;
    public void PlayParticles(GameObject obj)
    {
        if (obj.GetComponent<Interactable>().Undiscovered)
            instantiatedSparkles = Instantiate(sparklesPrefab, obj.transform.position, Quaternion.identity);
    }

    public void StopParticles()
    {
        if (instantiatedSparkles)
        {
            StartCoroutine(DestroyParticles());
        }
    }

    private IEnumerator DestroyParticles()
    {
        yield return new WaitForSeconds(.4f);
        instantiatedSparkles.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(2);
        Destroy(instantiatedSparkles);
    } 
}
