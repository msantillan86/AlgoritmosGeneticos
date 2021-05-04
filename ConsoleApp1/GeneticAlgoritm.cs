using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class GeneticAlgoritm
    {
        public List<DNA<char>> Population { get; private set; }
        public int Generation { get; private set; }
        public float BestFitness { get; private set; }
        public char[] BestGenes { get; private set; }

        public float MutationRate;
        private List<DNA<char>> newPopulation;
        private Random random;
        private float fitnessSum;
        private string frase;
        private string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,.|!#$%&/()=? ";

        public GeneticAlgoritm(string frase, Random random)
        {
            this.frase = frase;
            var populationSize = 1200;
            Generation = 1;
            MutationRate = 0.01f;
            Population = new List<DNA<char>>(populationSize);
            newPopulation = new List<DNA<char>>(populationSize);
            this.random = random;
            BestGenes = new char[frase.Length];

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new DNA<char>(frase.Length, random, GetRandomCharacter, FitnessFuntion, shouldInitGenes: true));
            }
        }

        private char GetRandomCharacter()
        {
            int i = random.Next(validCharacters.Length);
            return validCharacters[i];
        }

        private float FitnessFuntion(int index)
        {
            float score = 0;
            var dna = Population[index];

            for (int i = 0; i < dna.Genes.Length; i++)
            {
                if (dna.Genes[i] == frase[i])
                {
                    score += 1;
                }
            }

            score /= frase.Length;

            score = (MathF.Pow(5, score) - 1) / (5 -1);

            return score;
        }

        public void NewGeneration() 
        {
            if (Population.Count <= 0)
            {
                return;
            }

            CalculateFitness();
            
            newPopulation.Clear();

            for (int i = 0; i < Population.Count; i++)
            {
                DNA<char> parent1 = ChooseParent();
                DNA<char> parent2 = ChooseParent();

                DNA<char> child = parent1.Crossover(parent2);

                child.Mutate(MutationRate);

                newPopulation.Add(child);
            }

            var tmpList = Population;
            Population = newPopulation;
            newPopulation = tmpList;

            Generation++;
        }

        public void CalculateFitness()
        {
            fitnessSum = 0;

            DNA<char> best = Population[0];

            for (int i = 0; i < Population.Count; i++)
            {
                fitnessSum += Population[i].CalculateFitness(i);

                if ( Population[i].Fitness > best.Fitness) 
                {
                    best = Population[i];
                }
            }

            BestFitness = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);
        }

        private DNA<char> ChooseParent()
        {
            double randomNumber = random.NextDouble() * fitnessSum;
            
            for (int i = 0; i < Population.Count; i++)
            {
                if (randomNumber < Population[i].Fitness)
                {
                    return Population[i];
                }
                randomNumber -= Population[i].Fitness;
            }

            return null;
        }

    }

}
