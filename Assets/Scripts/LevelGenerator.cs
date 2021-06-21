using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<LevelBlock> legoBlocks = new List<LevelBlock>();
    List<LevelBlock> currentBlocks = new List<LevelBlock>();
    public Transform initialPoint;
    private static LevelGenerator _sharedInstance;
    public static LevelGenerator sharedInstance
    {
        get 
        {
            return _sharedInstance;
        }
    }

    void Awake()
    {
        _sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewBlock()
    {
        int randNumber = Random.Range(0, legoBlocks.Count - 1);
        var block = Instantiate(legoBlocks[randNumber]);
        block.transform.SetParent(this.transform);
        Vector3 blockPosition = Vector3.zero;
        if(currentBlocks.Count == 0){
            blockPosition = initialPoint.position;
        } else {
            int lastBlockPos = (currentBlocks.Count)-1;
            blockPosition = currentBlocks[lastBlockPos].exitPoint.position;
        }
        block.transform.position = blockPosition;
        currentBlocks.Add(block);
    }
}
