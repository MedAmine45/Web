namespace WebAtrioEmployeManagement.DTOS
{
    public class EmploiDTO
    {
        public int Id { get; set; }
        public string NomEntreprise { get; set; }
        public string PosteOccupe { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}
