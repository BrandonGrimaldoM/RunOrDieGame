using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> CurrentLevelBlocks = new List<LevelBlock>();

    public Transform levelStartPosition;
    void Awake()
    {
        if (sharedInstance ==null)
        {
            sharedInstance = this;
        }   
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddLevelBlock()
    {
        int randonIdx = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block;
        Vector3 spawnPosition = Vector3.zero;

        if(CurrentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allTheLevelBlocks[randonIdx]);
            spawnPosition = CurrentLevelBlocks[CurrentLevelBlocks.Count-1].exitPoint.position;
        }

        block.transform.SetParent(this.transform,false);
        Vector3 correction = new Vector3(spawnPosition.x-block.startPoint.position.x, spawnPosition.y-block.startPoint.position.y,0);
        block.transform.position = correction;
        CurrentLevelBlocks.Add(block);
    }
    public void RemoveLevelBolck()
    {
        LevelBlock oldBlock = CurrentLevelBlocks[0];
        CurrentLevelBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void RemoveAllLevelBolcks()
    {
        while (CurrentLevelBlocks.Count > 0)
        {
            RemoveLevelBolck();
        }
    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i<2;i++)
        {
            AddLevelBlock();
        }
    }
}
