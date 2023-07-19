using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager sharedInstance;

    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>(); //Variable que contiene todos los LevelBlocks del juego

    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>(); //Variable que contiene los level blocks que estan en la escena

    public Transform levelStartPosition;  //Variable que indica donde se empieza a crear el primer bloque
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();  //se invoca el metodo para generar los bloques iniciales al ejecutar el juego
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevelBlock() //Metodo que agrega levelblocks
    {
        int ramdomIdx = Random.Range(0, allTheLevelBlocks.Count); //Generacion numero aleatorio entre 0 y el maximo disponible dentro de los levelblocks

        LevelBlock block;

        Vector3 spawnPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlocks[0]);

            spawnPosition = levelStartPosition.position; // Se iguala con la posición inicial

        }
        else
        {
            block = Instantiate(allTheLevelBlocks[ramdomIdx]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count-1].exitPoint.position;

        }

        block.transform.SetParent(this.transform, false);

        Vector3 correction = new Vector3(spawnPosition.x - block.startPoint.position.x,
                                        spawnPosition.y - block.startPoint.position.y, 0);

        block.transform.position = correction;
        currentLevelBlocks.Add(block);
    }
    public void RemoveLevelBlock()
    {

    }

    public void RemoveAllLevelBlocks()
    {

    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {
            AddLevelBlock();
        }
    }
}
