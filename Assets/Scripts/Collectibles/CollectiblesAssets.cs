using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesAssets : MonoBehaviour
{
    public Transform ItemWorld;
    public Sprite poisonSprite;
    public Sprite acidSprite;
    public Sprite antidoteSprite;

    public static CollectiblesAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
