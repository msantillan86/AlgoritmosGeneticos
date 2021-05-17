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
