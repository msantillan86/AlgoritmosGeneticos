using GeneticSharp.Domain;
using Microsoft.AspNetCore.Components;
using MonkeysAG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeysBlazor.Pages
{

    public partial class Monkeys : ComponentBase
    {
        private string frase = "Cabalgan sancho, sapeee";
        private List<string> generaciones = new List<string>();
        private MonkeyParameters parameters = new MonkeyParameters() { 
            CrossoverProbability = 0.8f,
            Generations = 200,
            MutationProbability = 0.8f,
            Population = 200,
            Selection = MonkeyParameters.SolverSelection.Elite
        };

        private GeneticAlgorithm ga;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            ga = new MonkeySolver().GetGeneticAlgorithm(frase, parameters);
            ga.GenerationRan += (sender, e) =>
            {
                var bestChromosome = ga.BestChromosome as MonkeyChromosome;
                var bestFitness = bestChromosome.Fitness.Value;

                var currentPhrase = new string(bestChromosome.GetGenes().Select(x => (char)x.Value).ToArray());

                //Console.WriteLine($"Generación {ga.GenerationsNumber}: {currentPhrase} > Fitness: {bestFitness}");
                generaciones.Add($"Generación {ga.GenerationsNumber}: {currentPhrase} > Fitness: {bestFitness}");
                StateHasChanged();
            };

            return base.OnAfterRenderAsync(firstRender);
        }

        void CorrerAG()
        {
            ga.Start();
        }
    }
}
