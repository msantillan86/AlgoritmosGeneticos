using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeysAG
{
    public class MonkeyParameters
    {
        public enum SolverSelection { Elite, Tournament, Roulette, StochasticUniversalSampling };
        public int Generations { get; set; }
        public int Population { get; set; }
        public SolverSelection Selection { get; set; }
        public float CrossoverProbability { get; set; }
        public float MutationProbability { get; set; }
        public string ValidCharacters { get; set; }
    }
}
