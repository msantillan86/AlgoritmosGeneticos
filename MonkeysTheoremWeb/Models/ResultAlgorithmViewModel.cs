using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using static MonkeysAG.MonkeyParameters;
using System.ComponentModel;

namespace MonkeysTheoremWeb.Models
{
    public class ResultAlgorithmViewModel
    {
        public string PhraseResult { get; set; }
        public int Generation { get; set; }
        public double Fitness { get; set; }
    }
}
