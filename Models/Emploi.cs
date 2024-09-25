using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAtrioEmployeManagement.Models
{
    [Table("Emploi")]
    public class Emploi
    {
        [Key]
        public int Id { get; set; }
        public string NomEntreprise { get; set; }
        public string PosteOccupe { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public int PersonneId { get; set; }

        
        public Personne Personne { get; set; }

    }
}
