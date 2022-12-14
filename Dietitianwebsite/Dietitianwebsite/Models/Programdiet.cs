
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dietitianwebsite.Models
{
    public class Programdiet

    {
        [Key]
        public int ProgramId { get; set; }
        public string? Name { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        public string image { get; set; }

        public string breakfast { get; set; }
        public string lunch { get; set; }
        public string dinner { get; set; }

        public string userid { get; set; }
        [ForeignKey("userid")]
        public ApplicationUser User { get; set; }
         



        public Programdiet()//int id, string? name, int kcal, int protein, int carbs, int fat)
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