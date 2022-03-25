using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    Transform antTrans;
    FeromoneCreator feromoneCreator;

    public float moveSpeed = 10;
    public float rotSpeed = 3;

    public float rotationChangeCooldown = 2;
    private float currentRotationCooldown = 0;


    public Transform topLeftCorner;
    public Transform bottomRightCorner;

    private Vector3 targetPosition;

    private Transform target;

    public Transform headPosition;
    
    public LayerMask searchingForFoodLayermask;
    public LayerMask searchingForHomeLayermask;

    public LayerMask CurrentLayermask => 
        feromoneCreator.hasFood ? 
        searchingForHomeLayermask : 
        searchingForFoodLayermask;

    // Start is called before the first frame update
    void Start()
    {
        antTrans = transform;
        feromoneCreator = GetComponent<FeromoneCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSurroundings();

        antTrans.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if(currentRotationCooldown > 0)
        {   float dist = Vector3.Distance(targetPosition, antTrans.position);
            if(dist < 0.1f)

            {
                currentRotationCooldown = rotationChangeCooldown;
                GenerateRandomRotation();
            }

            currentRotationCooldown -= Time.deltaTime;
            var dir = transform.position - targetPosition;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        } else
        {
            currentRotationCooldown = rotationChangeCooldown;
            GenerateRandomRotation();
        }
    }

    private void CheckForSurroundings()
    {
        // layermask
        //Debug.DrawRay(headPosition.position, headPosition.forward, Color.cyan, 0.1f);
        var hits = Physics2D.RaycastAll(headPosition.position, headPosition.forward, 0.5f, CurrentLayermask);
        if(hits != null && hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider.name);
            }
        }
    }

    private void GenerateRandomRotation()
    {
        targetPosition = new Vector3(
            Random.Range(topLeftCorner.position.x, bottomRightCorner.position.x), 
            Random.Range(bottomRightCorner.position.y, topLeftCorner.position.y),
            0
            );
        if (target == null)
        {
            target = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            Destroy(target.GetComponent<Collider>());
            target.localScale = Vector3.one * 0.3f;
        }
        target.position = targetPosition;
    }
}
