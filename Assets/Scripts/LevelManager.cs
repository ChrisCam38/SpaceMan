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

    public void AddLevelBlock()
    {

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
