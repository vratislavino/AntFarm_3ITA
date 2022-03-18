using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    Transform antTrans;
    public float moveSpeed = 10;
    public float rotSpeed = 3;

    public float rotationChangeCooldown = 2;
    private float currentRotationCooldown = 0;

    private float targetZRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        antTrans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        antTrans.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if(currentRotationCooldown > 0)
        {
            currentRotationCooldown -= Time.deltaTime;
            //antTrans.rotation = Quaternion.Lerp(antTrans.rotation, Quaternion.Euler(0, 0, targetZRot), rotSpeed * Time.time);
        } else
        {
            currentRotationCooldown = rotationChangeCooldown;
            GenerateRandomRotation();
        }
    }

    private void GenerateRandomRotation()
    {
        targetZRot = Random.Range(-180, 180);
        LeanTween.rotateZ(gameObject, targetZRot, 2f);
    }
}
