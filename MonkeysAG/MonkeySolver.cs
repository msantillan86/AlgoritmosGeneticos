using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonkeysAG
{
    public class MonkeySolver
    {
        public GeneticAlgorithm GetGeneticAlgorithm(string frase, MonkeyParameters parameters)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-AR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            SelectionBase selection = parameters.Selection switch
            {
                MonkeyParameters.SolverSelection.Elite => new EliteSelection(),
                MonkeyParameters.SolverSelection.Tournament => new TournamentSelection(),
                MonkeyParameters.SolverSelection.Roulette => new RouletteWheelSelection(),
                MonkeyParameters.SolverSelection.StochasticUniversalSampling => new StochasticUniversalSamplingSelection(),
                _ => throw new NotImplementedException()
            };

            var crossover = new UniformCrossover();
            var mutation = new MonkeyMutation();
            var chromosome = new MonkeyChromosome(frase.Length, parameters.ValidCharacters);
            var population = new Population(parameters.Population, parameters.Population, chromosome);
            var fitness = new MonkeyFitness(frase);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);

            ga.MutationProbability = parameters.MutationProbability;
            ga.CrossoverProbability = parameters.CrossoverProbability;

            ITermination[] terminations = { new FitnessThresholdTermination(1), new GenerationNumberTermination(parameters.Generations) };
            ga.Termination = new OrTermination(terminations);

            return ga;
        }
    }
}
