using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using System.Collections.Generic;

namespace MonkeysAG
{
    public class MonkeyChromosome : ChromosomeBase
    {
        private int _length;
        private string _validCharacters = "-_[]=+-&#/*@'\"aábcdeéfghiíjklmnñoópqrstuúvwxyzAÁBCDEÉFGHIÍJKLMNÑOÓPQRSTUÚVWXYZ,.|¡!#$%&/()=¿? ";

        public MonkeyChromosome(int length, string validCharacters) : base(length)
        {
            _length = length;

            if (!string.IsNullOrEmpty(validCharacters))
                _validCharacters = validCharacters;

            CreateGenes();
        }

        public override IChromosome CreateNew() => new MonkeyChromosome(_length, _validCharacters);


        public override Gene GenerateGene(int geneIndex)
        {
            int index = RandomizationProvider.Current.GetInt(0, _validCharacters.Length);
            return new Gene(_validCharacters[index]);
        }
    }
}
