using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
     /// <summary>.</summary>
    public static class PizzaService
    {
        /// <summary></summary>
        static List<PizzaModel> Pizzas { get; }
        
        /// <summary></summary>
        static int nextId = 3;
        
        /// <summary>.</summary>
        static PizzaService()
        {
            Pizzas = new List<PizzaModel>
            {
                new PizzaModel { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new PizzaModel { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }

        /// <summary>Recupera todas as pizzas.</summary>
        public static List<PizzaModel> GetAll() => Pizzas;

        /// <summary>Recupera a pizza com base no código de identificação.</summary>
        public static PizzaModel Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        /// <summary>Adiciona uma pizza.</summary>
        public static void Add(PizzaModel pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        /// <summary>Exclui uma pizza com base no código de identificação.</summary>
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if(pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        /// <summary>Atualiza uma pizza.</summary>
        public static void Update(PizzaModel pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}