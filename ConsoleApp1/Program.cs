using System;

namespace ConsoleApp1
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            var frase = "Si los PERROS LADRAN, Sancho, es porque CABALGAMOS!";
            
            Console.WriteLine(frase);
            var ga = new GeneticAlgoritm(frase, random);

            while (ga.BestFitness < 1)
            {
                ga.NewGeneration();
                Console.WriteLine($"{ga.Generation} > {new string(ga.BestGenes)} : {ga.BestFitness}%");
            }
        }
    }
}
