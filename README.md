# Genetic Algorithm in Unity
A genetic algorithm is a search heuristic that is inspired by Charles Darwin’s theory of natural evolution. This algorithm reflects the process of natural selection where the fittest individuals are selected for reproduction in order to produce offspring of the next generation. Genetic Algorithms are being widely used in different real-world applications, for example, electronic circuits, code-breaking, image processing, and artificial creativity.

## The Process of Natural Selection
The process of natural selection starts with the selection of fittest individuals from a population. They produce offspring which inherit the characteristics of the parents and will be added to the next generation. If parents have better fitness, their offspring will be better than parents and have a better chance at surviving. This process keeps on iterating and at the end, a generation with the fittest individuals will be found. For instance, there are red bugs and green bugs in a hypothetical environment where predators (such as birds) prefer the taste of the green bugs, the red ones are more likely to survive. Soon there will be many red bugs and few green bugs. The red bugs will reproduce and make more red bugs, leading to a reality in which nearly all of the bugs born into this area will be red.

<center><img src="https://github.com/lightlessdays/Unity-Genetic-Algorithm/blob/main/naturalselection.png" width=30% align="middle"></center>

## Intialization of Genetic Algorithm

The process begins with a set of individuals which is called a Population. Each individual is a solution to the problem you want to solve. An individual is characterized by a set of parameters (variables) known as Genes. Genes are joined into a string to form a Chromosome (solution). In a genetic algorithm, the set of genes of an individual is represented using a string, in terms of an alphabet. Usually, binary values are used (string of 1s and 0s). We say that we encode the genes in a chromosome.
