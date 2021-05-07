using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MonkeyChromosome : ChromosomeBase
    {
        private int _length;
        private int _charLowerBound = 32;
        private int _charUpperBound = 127;

        public MonkeyChromosome(int length) : base(length)
        {
            _length = length;

            CreateGenes();
        }

        public override IChromosome CreateNew() => new MonkeyChromosome(_length);
        

        public override Gene GenerateGene(int geneIndex)
        {
            int index = RandomizationProvider.Current.GetInt(_charLowerBound, _charUpperBound);
            return new Gene((char)index);
        }
    }
}
