using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Preview : MonoBehaviour
{
    [SerializeField]
    private GameObject createdObject;

    [SerializeField]
    private Material material;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000))
        {
            
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //transform.position = hit.point + (Vector3.up * .5f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(createdObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += new Vector3(0, Input.GetAxis("Mouse ScrollWheel"), 0);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
            material.color = new Color(255, 0, 0, .5f);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Box"))
        material.color = new Color(0, 255, 0, .5f);
    }
}
