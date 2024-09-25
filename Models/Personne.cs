using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAtrioEmployeManagement.Models
{

    [Table("Personne")]
    public class Personne
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public ICollection<Emploi> Emplois { get; set; }
    }
}
