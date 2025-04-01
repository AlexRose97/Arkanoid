using Unity.Mathematics.Geometry;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        gameObject.transform.transform.Translate(new Vector3(inputH, 0, 0) * moveSpeed * Time.deltaTime);
        
        float xDelimitada = Mathf.Clamp(transform.position.x, -4.25f, 4.25f);
        
        transform.position = new Vector3(xDelimitada, transform.position.y, transform.position.z);
    }
}