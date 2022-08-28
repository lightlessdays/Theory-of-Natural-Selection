# 🧬 Genetic Algorithms
A genetic algorithm is a search heuristic that is inspired by [Charles Darwin’s theory of natural selection](https://www.khanacademy.org/science/ap-biology/natural-selection/natural-selection-ap/a/darwin-evolution-natural-selection). This algorithm reflects the process of natural selection where the fittest individuals are selected for reproduction in order to produce offspring of the next generation. Genetic Algorithms are being widely used in different real-world applications, for example, electronic circuits, code-breaking, image processing, and artificial creativity.

## 🪲 The Process of Natural Selection
The process of natural selection starts with the selection of fittest individuals from a population. They produce offspring which inherit the characteristics of the parents and will be added to the next generation. If parents have better fitness, their offspring will be better than parents and have a better chance at surviving. This process keeps on iterating and at the end, a generation with the fittest individuals will be found. For instance, there are red bugs and green bugs in a hypothetical environment where predators (such as birds) prefer the taste of the green bugs, the red ones are more likely to survive. Soon there will be many red bugs and few green bugs. The red bugs will reproduce and make more red bugs, leading to a reality in which nearly all of the bugs born into this area will be red.

<p align="center">
<img src="https://github.com/lightlessdays/Unity-Genetic-Algorithm/blob/main/naturalselection.png" width=30% align="middle">
</p>

## ⚙️ Intialization of Genetic Algorithm

The process begins with a set of individuals which is called a Population. Each individual is a solution to the problem you want to solve. An individual is characterized by a set of parameters (variables) known as Genes. Genes are joined into a string to form a Chromosome (solution). In a genetic algorithm, the set of genes of an individual is represented using a string, in terms of an alphabet. Usually, binary values are used (string of 1s and 0s). We say that we encode the genes in a chromosome.

<p align="center">
<img src="https://github.com/lightlessdays/Unity-Genetic-Algorithm/blob/main/genepool.png" width=30%></p>

In our project, our population starts with a population of 10 individuals. They have four genes in their chromosome- R,G,B and size. The R,G,B (as the name suggest) stores R,G and B values for our individuals. It gives colour to the indiviual. The size gene, obviously, determines the size of our characters. 

```
    //genes for color of gameobject
    public float r;
    public float g;
    public float b;
    private float a = 1;

    //genes for size of gameObject
    public float size;


    //gene for storing age. this will allow us to find the longest lived person in the gene pool.
    public float timeToDie = 0;
```

## 🏋️ Fitness Assignment of Genetic Algorithm

Fitness function is used to determine how fit an individual is? It means the ability of an individual to compete with other individuals. In every iteration, individuals are evaluated based on their fitness function. The fitness function provides a fitness score to each individual. This score further determines the probability of being selected for reproduction. The high the fitness score, the more chances of getting selected for reproduction. In our project, we determine the fitness of an individual by how long they live. The longer they live, the more is their fitness score. This is stored in a variable named timeToDie.

## 🤔 Selection Phase of Genetic Algorithm
The selection phase involves the selection of individuals for the reproduction of offspring. All the selected individuals are then arranged in a pair of two to increase reproduction. Then these individuals transfer their genes to the next generation. The selection can proceed in one of the three ways:
1. Roulette Wheel Selection
2. Tournament Selection
3. Rank Based Selection

In our project, we have used the Rank Based Selection method to select the fittest organism.

```
        //this orders the list of population is ascending order based upon their time of death. this will help us find the fittest organism out there.
        List<GameObject> sortedList = population.OrderBy(i => i.GetComponent<DNA>().timeToDie).ToList();
        population.Clear();

        //this divides the sortedList into two and only considers the fittest half. after this, it breeds organism number i and organism number i+1 with each other twice.

        for(int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }
```

## 🍆 Reproduction Phase of Genetic Algorithm
After selection of the fittest organism, we breed the organisms to produce a new offspring with qualities of the fittest organism. This process involves taking genes from both parents and merging them to create a new organism. In our project, we randomly take r,g,b and size genes from two fittest organism and breed them to produce a healthy offspring.

```
    //BREEDING ALGORITHM: The breeding algorithm is probably the simplest of all, first, it chooses a random number between 1 and 10. If the number is greater than 5, it returns true and if it is less than 5, it returns false. If it is true, the child is exact replica of parent1 and if it is false, it is the exact replica of parent2. but since we are using different things it might happen that the child inherits r and b values from parent1 and g and size values from parent2, so it is basically a mixture of the properties of both parents... and it is completely pseudo randomized.
    //finally we form an offspring and return it as a gameobject.
    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
        GameObject offSpring = Instantiate(personPrefab, pos, Quaternion.identity);
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();
        DNA offSpringDNA = offSpring.GetComponent<DNA>();
        offSpringDNA.r = Random.Range(0, 10) > 5 ? dna1.r : dna2.r;
        offSpringDNA.g = Random.Range(0, 10) > 5 ? dna1.g : dna2.g;
        offSpringDNA.b = Random.Range(0, 10) > 5 ? dna1.b : dna2.b;
        offSpringDNA.size = Random.Range(0, 10) > 5 ? dna1.size : dna2.size;
        return offSpring;
    }
```
In some genetic algorithms, there is a thing called mutation. The mutation operator inserts random genes in the offspring (new child) to maintain the diversity in the population. It can be done by flipping some bits in the chromosomes. There are three kinds of mutations in genetic algorithm: 
1. Flip Bit Mutation
2. Gaussian Mutation
3. Exchange/Swap Mutation

In our project, the mutation happens in 5 of every 1000 organisms (or 1 of every 200 organisms). The mutation is handled by the else clause in GameManager script.
```
            DNA offSpringDNA = offSpring.GetComponent<DNA>();
            offSpringDNA.r = Random.Range(0.0f, 1.0f);
            offSpringDNA.g = Random.Range(0.0f, 1.0f);
            offSpringDNA.b = Random.Range(0.0f, 1.0f);
            offSpringDNA.size = Random.Range(0.25f, 5f);
```
## ⚠️ Termination Phase of Genetic Algorithm
After the reproduction phase, a stopping criterion is applied as a base for termination. The algorithm terminates after the threshold fitness solution is reached. It will identify the final solution as the best solution in the population. Our project does not have a termination criteria because it can go on infinitely, as long as mutations keep occuring.

## ✨ Test out this project
This project is hosted using GitHub actions. You can test out this project by clicking [here](https://lightlessdays.github.io/Unity-Genetic-Algorithm/). Clicking on an organism will kill that organism. Each generation will last for 10 seconds. In the end, only the most desirable traits will remain (with some mutations in 1 of every 200 organisms).

You can download the Unity project for this repository from Releases. Cheers! 🍻

## 📜 Flowchart of the project 
<img src="https://github.com/lightlessdays/Unity-Genetic-Algorithm/blob/main/flowchart.png" width=100%>

## 🌳 Resources
1. [How Artificial intelligence learns | Genetic Algorithm explained](https://youtu.be/VnwjxityDLQ)
2. [13. Learning: Genetic Algorithms | MIT OpenCourseWare](https://youtu.be/kHyNqSnzP8Y)
