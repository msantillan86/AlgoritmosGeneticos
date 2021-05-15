using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using static MonkeysAG.MonkeyParameters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MonkeysTheoremWeb.Models
{
    public class GeneticAlgorithmViewModel
    {
        [DisplayName("Frase")]
        [Required(ErrorMessage = "Debe ingresar una frase")]
        public string Phrase { get; set; }
        
        public string PhraseConfiguration { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Población")]
        [DefaultValue(value:200)]
        [Range(1, Int32.MaxValue, ErrorMessage = "La población debe ser mayor a 0")]
        [DisplayName("Población")]
        public int? Population { get; set; }

        [Required(ErrorMessage = "Debe ingresar las Generaciones a generar")]
        [DefaultValue(value: 200)]
        [Range(1, Int32.MaxValue, ErrorMessage = "Las generaciones deben ser mayor a 0")]
        [DisplayName("Generaciones")]
        public int? Generations { get; set; }

        [DisplayName("Probabilidad de Cruzamiento")]
        [DefaultValue(value: 0.8f)]
        [Range(0.1, 1, ErrorMessage = "La probabilidad de cruza debe ser un valor entre 0 y 1")]
        [Required(ErrorMessage = "Debe ingresar la Probabilidad de Cruzamiento")]
        public float? CrossoverProbability { get; set; }

        [DisplayName("Probabilidad de Mutación")]
        [DefaultValue(value: 0.8f)]
        [Range(0.1, 1, ErrorMessage = "La probabilidad de mutación debe ser un valor entre 0 y 1")]
        [Required(ErrorMessage = "Debe ingresar la Probabilidad de Mutación")]
        public float? MutationProbability { get; set; }
        
        [DisplayName("Método de selección")]
        [DefaultValue(value: 1)]
        [Range(0, Int32.MaxValue, ErrorMessage = "Debe seleccionar un método de selección")]
        [Required(ErrorMessage ="Debe seleccionar un método de selección")]
        public int SolverSelection { get; set; }
        
        public string SolverSelectionName { get; set; }

        public IList<ResultAlgorithmViewModel> Result { get; set; }

        public GeneticAlgorithmViewModel()
        {
            Result = new List<ResultAlgorithmViewModel>();
        }
    }
}
