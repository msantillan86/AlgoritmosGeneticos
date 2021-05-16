using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using System;

namespace MonkeysAG
{
    public class MonkeyMutation : MutationBase
    {
        private int _charLowerBound = 32;
        private int _charUpperBound = 255;
        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            if (RandomizationProvider.Current.GetDouble() <= probability)
            {
                const int MaxMutationAmount = 10;

                var index = RandomizationProvider.Current.GetInt(0, chromosome.Length);

                int currVal = (char)chromosome.GetGene(index).Value;

                var newGene = currVal +
                    RandomizationProvider.Current.GetInt(-MaxMutationAmount, MaxMutationAmount + 1);

                newGene = Math.Min(newGene, _charUpperBound);
                newGene = Math.Max(newGene, _charLowerBound);

                chromosome.ReplaceGene(index, new Gene((char)newGene));
            }
        }
    }
}
