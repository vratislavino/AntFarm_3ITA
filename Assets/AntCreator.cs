using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCreator : MonoBehaviour
{
    public AntMove antPrefab;

    public Transform topLeftCorner;
    public Transform bottomRightCorner;

    public float newAntInterval = 1;
    public int count;

    List<AntMove> ants = new List<AntMove>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateAnts());
    }

    IEnumerator CreateAnts()
    {
        while (true)
        {
            CreateNewAnts(count);
            yield return new WaitForSeconds(newAntInterval);
        }
    }

    public void CreateNewAnts(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreateNewAnt();
        }
    }

    public void CreateNewAnt()
    {

        var ant = Instantiate(antPrefab, transform.position, Quaternion.identity);
        ant.topLeftCorner = topLeftCorner;
        ant.bottomRightCorner = bottomRightCorner;
        ants.Add(ant);
    }

}
