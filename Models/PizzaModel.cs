namespace ContosoPizza.Models
{
    public class PizzaModel
    {   
        /// <summary>Código de identificação da Pizza.</summary>
        public int Id { get; set; }
        
        /// <summary>Nome da Pizza.</summary>
        public string Name { get; set; }
        
        /// <summary>É livre de glutén.</summary>
        public bool IsGlutenFree { get; set; }
    }
}