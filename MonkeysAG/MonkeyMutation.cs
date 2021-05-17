using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using System;
using System.Collections.Generic;

namespace MonkeysAG
{
    public class MonkeyMutation : MutationBase
    {
        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            try
            {
                if (RandomizationProvider.Current.GetDouble() <= probability)
                {
                    //const int MaxMutationAmount = 10;

                    //var index = RandomizationProvider.Current.GetInt(0, chromosome.Length);

                    //int currVal = (char)chromosome.GetGene(index).Value;

                    //var newGene = currVal + RandomizationProvider.Current.GetInt(-MaxMutationAmount, MaxMutationAmount + 1);

                    //newGene = Math.Min(newGene, validCharacters.Length-1);
                    //newGene = Math.Max(newGene, 0);

                    //chromosome.ReplaceGene(index, new Gene(validCharacters[newGene]));

                    var index = RandomizationProvider.Current.GetInt(0, chromosome.Length);
                    chromosome.ReplaceGene(index, chromosome.GenerateGene(index));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
