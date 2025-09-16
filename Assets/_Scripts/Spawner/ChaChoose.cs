using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaChoose : MonoBehaviour
{
    [SerializeField] private Image chaImage;
    [SerializeField] private List<Sprite> charSprite;
    [SerializeField] private LevelController levelController;
    private int currentCha = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextChar()
    {
        currentCha++;
        if (currentCha >= charSprite.Count)
        {
            currentCha = 0;
        }

        chaImage.sprite = charSprite[currentCha];
    }

    public void PrevChar()
    {
        currentCha--;
        if (currentCha < 0)
        {
            currentCha = charSprite.Count - 1;
        }

        chaImage.sprite = charSprite[currentCha];
    }

    public void Cofirm()
    {
        GameManager.instance.selectChar = currentCha;
        levelController.LoadLevel1();
    }
}
