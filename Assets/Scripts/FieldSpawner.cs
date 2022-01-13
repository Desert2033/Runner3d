using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{

    public GameObject[] fieldBlockPrefabs;
    public GameObject startBlock;

    float blockXPos = 0;
    int blocksCount = 7;
    float blockLength = 0;
    int safeZone = 50;

    float speed = 5;

    public Transform playerTransform;
    List<GameObject> currentBlocks = new List<GameObject>();


    void Start()
    {
        blockXPos = startBlock.transform.position.x;
        blockLength = startBlock.GetComponent<Transform>().localScale.x;

        currentBlocks.Add(startBlock);
        for (int i = 0; i < blocksCount; i++)
        {
            SpawnBlock();
        }

    }

    private void Update()
    {
       // Vector3 newPos = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
       // transform.position = newPos;  
        CheckFroSpawn();
    }

    private void CheckFroSpawn()
    {
        if (playerTransform.position.x - safeZone > (blockXPos - blocksCount * blockLength))
        {
            SpawnBlock();
            DestroyBlock();
        }
    }

    private void SpawnBlock()
    {
        GameObject block = Instantiate(fieldBlockPrefabs[Random.Range(0, fieldBlockPrefabs.Length)], transform);

        blockXPos += blockLength;

        block.transform.position = new Vector3(blockXPos, 0, 0);

        currentBlocks.Add(block);

    }

    private void DestroyBlock()
    {
        Destroy(currentBlocks[0]);
        currentBlocks.RemoveAt(0);
    }


}
