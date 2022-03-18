using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feromone : MonoBehaviour
{
    public float timeToLive = 5f;

    public FeromoneType FeromoneType;

    private void Start()
    {
        LeanTween.scale(gameObject, Vector3.zero, timeToLive).setOnComplete(() => { 
            Destroy(gameObject);
        });
    }
}

public enum FeromoneType
{
    Home,
    Food
}
