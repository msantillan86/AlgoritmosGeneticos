using MonkeysAG;
using System;
using System.Linq;

namespace MonkeysConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var phrase = GetPhrase("Si los PERROS LADRAN, Sancho, es porque CABALGAMOS!");

            var parameters = new MonkeyParameters()
            {
                Population = GetPopulation(100),
                Generations = GetGenerations(200),
                CrossoverProbability = GetCrossoverProbability(0.8f),
                MutationProbability = GetMutationProbability(0.8f),
                Selection = (MonkeyParameters.SolverSelection)GetSelection((int)MonkeyParameters.SolverSelection.Elite)
            };

            var ga = new MonkeySolver().GetGeneticAlgorithm(phrase, parameters);

            Console.WriteLine("Ga Running");

            ga.GenerationRan += (sender, e) =>
            {
                var bestChromosome = ga.BestChromosome as MonkeyChromosome;
                var bestFitness = bestChromosome.Fitness.Value;

                var currentPhrase = new string(bestChromosome.GetGenes().Select(x => (char)x.Value).ToArray());

                Console.WriteLine($"Generación {ga.GenerationsNumber}: {currentPhrase} > Fitness: {bestFitness}");
            };

            ga.Start();
        }

        private static int GetSelection(int defaultSelection)
        {
            Console.WriteLine("Ingrese el tipo de selección.\n0: Ranking\n1: Torneo\n2: Ruleta\n3:Control sobre número esperado\nPresione ENTER para continuar\n(Seleccion por defecto: Ranking)");
            var inputSelection = Console.ReadLine();
            if (!int.TryParse(inputSelection, out int selection))
                selection = defaultSelection;
            return selection;
        }

        private static float GetMutationProbability(float defaultMutationProbability)
        {
            Console.WriteLine($"Ingrese probabilidad de mutación.\nPresione ENTER para continuar\n(Probabilidad por defecto {defaultMutationProbability})");
            var inputMutationProbability = Console.ReadLine();
            if (!float.TryParse(inputMutationProbability, out float mutationProbability))
                mutationProbability = defaultMutationProbability;
            return mutationProbability;
        }

        private static float GetCrossoverProbability(float defaultCrossoverProbability)
        {
            Console.WriteLine($"Ingrese probabilidad de cruzamiento.\nPresione ENTER para continuar\n(Probabilidad por defecto {defaultCrossoverProbability})");
            var inputCrossoverProbability = Console.ReadLine();
            if (!float.TryParse(inputCrossoverProbability, out float crossoverProbability))
                crossoverProbability = defaultCrossoverProbability;
            return crossoverProbability;
        }

        private static int GetGenerations(int defaultGenerations)
        {
            Console.WriteLine($"Indique cuantas generaciones desea como máximo generar.\nPresione ENTER para continuar\n(Generaciones por defecto: {defaultGenerations})");
            var inputGenerations = Console.ReadLine();
            if (!int.TryParse(inputGenerations, out int generations))
                generations = defaultGenerations;
            return generations;
        }

        private static int GetPopulation(int defaultPopulation)
        {
            Console.WriteLine($"Elija la población a generar.\nPresione ENTER para continuar\n(Población por defecto: {defaultPopulation})");
            var inputPopulation = Console.ReadLine();
            if (!int.TryParse(inputPopulation, out int population))
                population = defaultPopulation;
            return population;
        }

        private static string GetPhrase(string defaultPhrase)
        {
            Console.WriteLine($"Ingrese frase para resolver.\nPresione ENTER para continuar\n(Frase por defecto: \"{defaultPhrase}\")");
            var phrase = Console.ReadLine();
            if (string.IsNullOrEmpty(phrase))
                phrase = defaultPhrase;
            return phrase;
        }
    }
}
