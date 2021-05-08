using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using MonkeysAG;
using System;
using System.Linq;

namespace ConsoleApp1
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var frase = "Si los PERROS LADRAN, Sancho, es porque CABALGAMOS!";
            
            Console.WriteLine(frase);

            var parameters = new MonkeyParameters()
            {
                CrossoverProbability = 0.8f,
                Generations = 500,
                MutationProbability = 0.8f,
                Population = 100,
                Selection = MonkeyParameters.SolverSelection.Elite
            };

            var ga = new MonkeySolver().GetGeneticAlgorithm(frase,parameters);
            
            Console.WriteLine("Ga Running");

            ga.GenerationRan += (sender, e) =>
            {
                var bestChromosome = ga.BestChromosome as MonkeyChromosome;
                var bestFitness = bestChromosome.Fitness.Value;

                var fraseActual = new string(bestChromosome.GetGenes().Select(x => (char)x.Value).ToArray());

                Console.WriteLine($"{ga.GenerationsNumber}: {fraseActual} > {bestFitness}");
            };
            
            ga.Start();
        }
    }
}
