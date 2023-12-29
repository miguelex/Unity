using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>(); //Lista que contiene todos los niveles qe se han creado
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>(); //Lista de bloques que tenemos ahora mismo en pantalla
    public Transform levelInitialPoint;

    private bool isGeneratingInitialBlock = false;
    void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateInitialBlock()
    {
        isGeneratingInitialBlock = true;
        for (int i =0; i<3; i++)
            AddNewBlock();
        isGeneratingInitialBlock = false;
    }

    public void AddNewBlock()
    {
        // Seleccionar un bloque aleatorio entre los que tenemos disponibles

        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

        if (isGeneratingInitialBlock)
        {
            randomIndex = 0;
        }
        LevelBlock block = (LevelBlock) Instantiate(allTheLevelBlocks[randomIndex]);
        block.transform.SetParent(this.transform, false);
        Vector3 blockPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            blockPosition = levelInitialPoint.position;
        }
        else
        {
            blockPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.position = blockPosition;
        currentLevelBlocks.Add(block);
    }

    public void RemoveOldBlock()
    {
        LevelBlock block = currentLevelBlocks[0];
        currentLevelBlocks.Remove(block);
        Destroy((block.gameObject));
    }

    public void RemoveAllTheBlocks()
    {
        while (currentLevelBlocks.Count > 0)
        {
            RemoveOldBlock();
        }
    }
}
