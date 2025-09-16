
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpawnPlayer : MonoBehaviour
{

    [SerializeField] private List<GameObject> prefaps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCharacter()
    {
        int index = GameManager.instance.selectChar;

        // spawn prefab
        Instantiate(prefaps[index], transform.position, transform.rotation);
    }
}
