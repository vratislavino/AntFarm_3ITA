using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeromoneCreator : MonoBehaviour
{
    public Feromone homeFeromonePrefab;
    public Feromone foodFeromonePrefab;

    private float feromoneCooldown = 0.5f;
    private float currentFeromoneCooldown = 0.5f;

    public bool hasFood = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentFeromoneCooldown < 0)
        {
            CreateFeromone();
            currentFeromoneCooldown = feromoneCooldown;
        } else
        {
            currentFeromoneCooldown -= Time.deltaTime;
        }
    }

    private void CreateFeromone()
    {
        Feromone feromone = Instantiate(hasFood ? foodFeromonePrefab : homeFeromonePrefab, transform.position, Quaternion.identity);
    }
}
