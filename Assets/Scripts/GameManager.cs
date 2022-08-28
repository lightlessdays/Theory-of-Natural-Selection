using System.Collections.Generic;
using UnityEngine;
//system.linq => for sorting list without using sorting algorithms (i am lazy, lol)
using System.Linq;

public class GameManager : MonoBehaviour
{
    //personPrefab is the person we have to instantiate
    [SerializeField] private GameObject personPrefab;
    //here goes the number of people we have to instantiate
    [SerializeField] private int populationSize = 10;
    //this list will store all of the people we instantiated
    List<GameObject> population = new List<GameObject>();
    //this will calculate the time elapsed since the generation appeared.
    public static float timeElapsed = 0;
    //this is the time each generation will last. 10 seconds is the default.
    [SerializeField] private int trialTime = 10;
    //this is the number of generation.
    private int generation = 1;
    //Instantiating GUIStyle (#This is the AWT of C Sharp)
    GUIStyle guiStyle = new GUIStyle();

    //Frontend Code <3
    private void OnGUI()
    {
        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + generation, guiStyle);
        GUI.Label(new Rect(10, 65, 100, 20), "Trial Time: " + timeElapsed, guiStyle);
    }


    private void Start()
    {

        //Instantiating populationSize number of personPrefabs and adding them to the list.
        for(int i = 0; i < populationSize; i++)
        {
            //the position of object instantiated is random and so are colour and size.
            Vector3 pos = new Vector3(Random.Range(-9f, 9f), Random.Range(-4.5f,4.5f), 0f);
            GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
            go.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            //i have limited the size of instantiated objects between 0.25 and 0.5 because i do not want them to be too large or too small.
            go.GetComponent<DNA>().size = Random.Range(0.25f, 0.5f);

            //finally adding everything to the list.
            population.Add(go); 
        }
    }

    private void Update()
    {

        //this will keep on calculating the time that is elapsed.
        timeElapsed += Time.deltaTime;
        //if timeElapsed becomes greater than the trialTime, which is 10 by default, the present generation dies. LMAO DEAD XD.
        //also a new generation is born and elapsed time becomes 0 again.
        if (timeElapsed > trialTime) { 
                BreedNewPopulation();
                timeElapsed = 0;
        }
    }

    
    //this method allows us to breed new generation.
    void BreedNewPopulation()
    {
        //this orders the list of population is ascending order based upon their time of death. this will help us find the fittest organism out there.
        List<GameObject> sortedList = population.OrderBy(i => i.GetComponent<DNA>().timeToDie).ToList();
        population.Clear();

        //this divides the sortedList into two and only considers the fittest half. after this, it breeds organism number i and organism number i+1 with each other twice.

        for(int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }
        //we then destroy the older game objects and increase the generation
        foreach (GameObject i in sortedList)
        {
            Destroy(i);
        }
        generation++;
    }


    //BREEDING ALGORITHM: The breeding algorithm is probably the simplest of all, first, it chooses a random number between 1 and 10. If the number is greater than 5, it returns true and if it is less than 5, it returns false. If it is true, the child is exact replica of parent1 and if it is false, it is the exact replica of parent2.
    //but since we are using different things it might happen that the child inherits r and b values from parent1 and g and size values from parent2, so it is basically a mixture of the properties of both parents... and it is completely pseudo randomized.
    //finally we form an offspring and return it as a gameobject.
    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
        GameObject offSpring = Instantiate(personPrefab, pos, Quaternion.identity);
        if (Random.Range(1, 1000) > 5) {
            DNA dna1 = parent1.GetComponent<DNA>();
            DNA dna2 = parent2.GetComponent<DNA>();
            DNA offSpringDNA = offSpring.GetComponent<DNA>();
            offSpringDNA.r = Random.Range(0, 10) > 5 ? dna1.r : dna2.r;
            offSpringDNA.g = Random.Range(0, 10) > 5 ? dna1.g : dna2.g;
            offSpringDNA.b = Random.Range(0, 10) > 5 ? dna1.b : dna2.b;
            offSpringDNA.size = Random.Range(0, 10) > 5 ? dna1.size : dna2.size;
        }
        else
        {
            DNA offSpringDNA = offSpring.GetComponent<DNA>();
            offSpringDNA.r = Random.Range(0.0f, 1.0f);
            offSpringDNA.g = Random.Range(0.0f, 1.0f);
            offSpringDNA.b = Random.Range(0.0f, 1.0f);
            offSpringDNA.size = Random.Range(0.25f, 5f);
        }
        
        return offSpring;
    }
} 
