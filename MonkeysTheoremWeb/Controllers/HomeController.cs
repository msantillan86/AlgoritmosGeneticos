using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MonkeysAG;
using MonkeysTheoremWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GeneticAlgorithm(GeneticAlgorithmViewModel model)
        {
            ViewBag.SelectionMethods = LoadSelectionMethods();
            if (model == null)
                model = new GeneticAlgorithmViewModel();

            return View(model);
        }

        public IActionResult Calculate(GeneticAlgorithmViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parameters = new MonkeyParameters()
                {
                    Population = model.Population,
                    Generations = model.Generations,
                    CrossoverProbability = model.CrossoverProbability,
                    MutationProbability = model.MutationProbability,
                    Selection = (SolverSelection) model.SolverSelection
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
                return View("Index", model);
            }
            else
            {
                return View("Index", model);
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

        private dynamic LoadSelectionMethods()
        {
            Array values = Enum.GetValues(typeof(SolverSelection));
            IList<SelectListItem> methods = new List<SelectListItem>();
            int i = 0;
            foreach (SolverSelection val in values)
            {
                methods.Add(new SelectListItem() { Text = Enum.GetName(typeof(SolverSelection), val), Value = i.ToString() });
                i++;
            }

            return methods;
        }
    }
}
