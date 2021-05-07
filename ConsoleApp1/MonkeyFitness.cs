using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MonkeyFitness : IFitness
    {
        private string _frase;
        public MonkeyFitness(string frase)
        {
            _frase = frase;
        }

        public double Evaluate(IChromosome chromosome)
        {
            var diff = chromosome.GetGenes().Zip(_frase, (x, y) => Math.Abs((char)x.Value - y)).Sum(x => x == 0 ? 0 : x + 10);

            return Math.Max(0, 1.0 - (diff / (_frase.Length * 50.0)));
        }
    }
}
