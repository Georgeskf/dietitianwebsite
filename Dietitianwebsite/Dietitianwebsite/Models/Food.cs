using System.ComponentModel.DataAnnotations.Schema;

namespace Dietitianwebsite.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Kcal { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public string userid { get; set; }
        [ForeignKey("userid")]
        public ApplicationUser User { get; set; }

        public Food()//int id, string? name, int kcal, int protein, int carbs, int fat)
        {
            //Id = id;
            //Name = name;
            //Kcal = kcal;
            //Protein = protein;
            //Carbs = carbs;
            //Fat = fat;
        }
    }
}