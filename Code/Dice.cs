using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    //From Youtube (besides this one everything below the other comments until the next avaliable function is from youtube)
    private Sprite[] diceSides;

    
    private SpriteRenderer rend;

    
    public GameObject otherDice;

    
    private int finalSide;

    
    [SerializeField] private GameObject EnemyWaves;

    private EnemyWaves waveSpawner;

    
    private static bool isRolling = false;

    private void Start()
    {
        //From Youtube
        rend = GetComponent<SpriteRenderer>();

        
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");

        
        if (EnemyWaves != null)
        {
            waveSpawner = EnemyWaves.GetComponent<EnemyWaves>();
        }
    }

    
    private void OnMouseDown()
    {
        if (!isRolling) 
        {
            StartCoroutine(RollBothDice());
        }
    }

    
    private IEnumerator RollBothDice()
    {
        isRolling = true; 

        
        yield return StartCoroutine(RollTheDice());

        
        int totalPoints = finalSide; 

        if (otherDice != null)
        {
            Dice otherDiceScript = otherDice.GetComponent<Dice>();
            if (otherDiceScript != null)
            {
                yield return StartCoroutine(otherDiceScript.RollTheDice());
                totalPoints += otherDiceScript.finalSide; 
            }
        }

        
        Debug.Log($"Total points from both dice: {totalPoints}");

        
        AddPoints(totalPoints);

        
        if (waveSpawner != null)
        {
            waveSpawner.StartNextWave();
        }

        isRolling = false; 
    }

    //From Youtube
    public IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;

        
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        
        finalSide = randomDiceSide + 1;

        
        Debug.Log($"Dice rolled: {finalSide}");
    }

    
    private void AddPoints(int points)
    {
        
        PlayerPointsManager.Instance.AddPoints(points);
    }
}
