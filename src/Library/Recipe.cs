//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

        }

        public double GetProductionCost() {

            double cost = 0;

            if(this.steps.Count != 0) {
                foreach (Step step in this.steps) {

                    cost += (step.Time * step.Equipment.HourlyCost) + step.Input.UnitCost;

                }
            } 
            Console.WriteLine($"El costo total es {cost}");

            return cost;
        }

        ///Se usa SRP ya que solo tiene una razon de cambio siendo esta la receta
        ///Se usa EXPERT ya que es la unica clase que conoce los datos de la receta
    }
}

