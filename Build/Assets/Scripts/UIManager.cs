using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject createdObject;
    public void Created()
    {
        Instantiate(createdObject, Vector3.zero, Quaternion.identity);
    }
}
