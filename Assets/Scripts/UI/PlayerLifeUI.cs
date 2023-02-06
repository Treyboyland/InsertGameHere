using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeUI : MonoBehaviour
{
    [SerializeField]
    GameObject heart;

    public bool Active
    {
        get => heart.activeInHierarchy;
        set => heart.SetActive(value);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
