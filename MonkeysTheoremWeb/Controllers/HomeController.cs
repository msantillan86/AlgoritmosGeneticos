using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonkeysAG;
using MonkeysTheoremWeb.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using static MonkeysAG.MonkeyParameters;

namespace MonkeysTheoremWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            GeneticAlgorithmViewModel model = new GeneticAlgorithmViewModel();
            LoadDefaultParams(model);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GeneticAlgorithm(GeneticAlgorithmViewModel model)
        {
            if (model == null)
                model = new GeneticAlgorithmViewModel();

            return View(model);
        }

        public IActionResult Calculate(GeneticAlgorithmViewModel model)
        {
            if (ModelState.IsValid)
            {
                CalculateGeneticAlgorithm(model);
                return Json(new { codigo = 0, resultados = model.Result });
            }
            else
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { codigo = -1, resultados = allErrors });
            }
        }

        public IActionResult Results()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static void CalculateGeneticAlgorithm(GeneticAlgorithmViewModel model)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-AR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var parameters = new MonkeyParameters()
            {
                Population = model.Population.Value,
                Generations = model.Generations.Value,
                CrossoverProbability = model.CrossoverProbability.Value,
                MutationProbability = model.MutationProbability.Value,
                Selection = (SolverSelection)model.SolverSelection
            };

            var ga = new MonkeySolver().GetGeneticAlgorithm(model.Phrase, parameters);
            List<ResultAlgorithmViewModel> Result = new List<ResultAlgorithmViewModel>();

            ga.GenerationRan += (sender, e) =>
            {
                var bestChromosome = ga.BestChromosome as MonkeyChromosome;
                var bestFitness = bestChromosome.Fitness.Value;

                var currentPhrase = new string(bestChromosome.GetGenes().Select(x => (char)x.Value).ToArray());

                ResultAlgorithmViewModel elemResult = new ResultAlgorithmViewModel
                {
                    PhraseResult = currentPhrase,
                    Generation = ga.GenerationsNumber,
                    Fitness = bestFitness
                };

                Result.Add(elemResult);
            };

            ga.Start();

            model.Result = Result;
        }


        private void LoadDefaultParams(GeneticAlgorithmViewModel model)
        {
            model.Population = 200;
            model.Generations = 200;
            model.SolverSelection = (int)SolverSelection.Tournament;
            model.SolverSelectionName = ObtenerNombreEnum(model.SolverSelection);
            model.MutationProbability = 0.8f;
            model.CrossoverProbability = 0.8f;
        }

        private string ObtenerNombreEnum(int solverSelection)
        {
            string name = string.Empty;
            switch ((SolverSelection)solverSelection)
            {
                case SolverSelection.Tournament:
                    name = "Torneo";
                    break;
                case SolverSelection.Elite:
                    name = "Élite";
                    break;
                case SolverSelection.Roulette:
                    name = "Ruleta";
                    break;
                case SolverSelection.StochasticUniversalSampling:
                    name = "Control sobre número esperado";
                    break;

            }
            return name;
        }
    }
}
