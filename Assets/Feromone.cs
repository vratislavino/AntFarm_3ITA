using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feromone : MonoBehaviour
{
    public float timeToLive = 5f;
    public float remainingTime;

    public FeromoneType FeromoneType;

    public Transform graphics;

    private void Start()
    {
        remainingTime = timeToLive;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        graphics.localScale = Vector3.one * (remainingTime / timeToLive);
        if(remainingTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

public enum FeromoneType
{
    Home,
    Food
}
