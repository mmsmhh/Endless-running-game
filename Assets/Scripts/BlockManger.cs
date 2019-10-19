using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManger : MonoBehaviour
{
    public GameObject block;
    public GameObject[] items;

    private Transform playerTransform;

    private static float spawnZ;
    private float blockLength;
    private int numberOfBlocksOnScreen;

    private static List<GameObject> exsistingBlocks;

    private float safeZone;

    void Start()
    {
        spawnZ = -20.0f;
        blockLength = 20f;
        numberOfBlocksOnScreen = 25;
        safeZone = 25;
    

        exsistingBlocks = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        InitBlocks();
    }


    public void InitBlocks()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnBlock();
        }

        for (int i = 0; i < 19; i++)
        {
            SpawnBlock(1);
        }
    }

    void Update()
    {

        if ((!Player.IsPlayerAlive()))
        {
            return;
        }

        if ((playerTransform.position.z - safeZone > (spawnZ - numberOfBlocksOnScreen * blockLength)))
        {
                SpawnBlock(1);
                DeleteBlock();
        }
       
    }

    private void SpawnBlock(int prefabIndex = -1)
    {
        GameObject go;

        go = Instantiate(block) as GameObject;
        go.transform.SetParent(gameObject.transform);
        go.transform.position = Vector3.forward * spawnZ;

        if (prefabIndex != -1)
        {
            float [] x = { -7.5f, 0f, 7.5f };
            float [] z = { -5f, 5f };

            for (int i = 0; i < x.Length; i++)
            {
                for(int j = 0; j< z.Length; j++)
                {
                    GameObject item = Instantiate(items[Random.Range(0, items.Length)]) as GameObject;
                    item.transform.SetParent(go.transform);
                    item.transform.position = new Vector3(x[i], 1, go.transform.position.z + z[j]);
                }
            }
            
        }

        spawnZ += blockLength;
        exsistingBlocks.Add(go);
    }

    private static void DeleteBlock()
    {
        Destroy(exsistingBlocks[0]);
        exsistingBlocks.RemoveAt(0);
    }

}
