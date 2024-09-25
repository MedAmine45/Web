namespace WebAtrioEmployeManagement.DTOS
{
    public class PersonneDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public List<EmploiDTO>? Emplois { get; set; }
    }
}
