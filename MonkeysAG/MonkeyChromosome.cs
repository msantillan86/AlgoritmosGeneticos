using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using System.Collections.Generic;

namespace MonkeysAG
{
    public class MonkeyChromosome : ChromosomeBase
    {
        private int _length;
        private string validCharacters = "aábcdeéfghiíjklmnñoópqrstuúvwxyzAÁBCDEÉFGHIÍJKLMNÑOÓPQRSTUÚVWXYZ,.|¡!#$%&/()=¿? ";

        public MonkeyChromosome(int length) : base(length)
        {
            _length = length;

            CreateGenes();
        }

        public override IChromosome CreateNew() => new MonkeyChromosome(_length);


        public override Gene GenerateGene(int geneIndex)
        {
            int index = RandomizationProvider.Current.GetInt(0, validCharacters.Length);
            return new Gene(validCharacters[index]);
        }
    }
}
