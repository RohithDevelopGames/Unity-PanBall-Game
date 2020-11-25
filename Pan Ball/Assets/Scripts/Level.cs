using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // config params
    [SerializeField] int breakableBlocks;

    // cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableObjects()
    {
        breakableBlocks++;
    }

    public void DecreaseBreakableObjects()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}