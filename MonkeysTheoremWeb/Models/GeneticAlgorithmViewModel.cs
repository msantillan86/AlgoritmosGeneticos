using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using static MonkeysAG.MonkeyParameters;
using System.ComponentModel;

namespace MonkeysTheoremWeb.Models
{
    public class GeneticAlgorithmViewModel
    {
        [DisplayName("Frase")]
        public string Phrase { get; set; }
        [DisplayName("Población")]
        public int Population { get; set; }
        [DisplayName("Generaciones")]
        public int Generations { get; set; }
        [DisplayName("Probabilidad de Cruza")]
        public float CrossoverProbability { get; set; }
        [DisplayName("Probabilidad de Mutación")]
        public float MutationProbability { get; set; }
        [DisplayName("Método de selección")]
        public int SolverSelection { get; set; }
        public List<ResultAlgorithmViewModel> Result { get; set; }
    }
}
