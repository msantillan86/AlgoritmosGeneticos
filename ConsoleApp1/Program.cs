using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;
using System.Linq;

namespace ConsoleApp1
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            var frase = "Si los PERROS LADRAN, Sancho, es porque CABALGAMOS!";
            
            Console.WriteLine(frase);
            //var ga = new CustomGeneticAlgoritm(frase, random);
            //while (ga.BestFitness < 1)
            //{
            //    ga.NewGeneration();
            //    Console.WriteLine($"{ga.Generation} > {new string(ga.BestGenes)} : {ga.BestFitness}%");
            //}

            var selection = new EliteSelection();
            var crossover = new UniformCrossover();
            var mutation = new MonkeyMutation();
            var chromosome = new MonkeyChromosome(frase.Length);
            var population = new Population(100, 100, chromosome);
            var fitness = new MonkeyFitness(frase);

            var ga = new GeneticAlgorithm(population,fitness,selection,crossover,mutation);
            
            ITermination[] terminations = { new FitnessThresholdTermination(1), new GenerationNumberTermination(1000) };

            ga.Termination = new OrTermination(terminations);

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
