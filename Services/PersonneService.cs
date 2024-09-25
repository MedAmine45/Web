using Microsoft.EntityFrameworkCore;
using WebAtrioEmployeManagement.Data;
using WebAtrioEmployeManagement.DTOS;
using WebAtrioEmployeManagement.Models;

namespace WebAtrioEmployeManagement.Services
{
    public class PersonneService : IPersonneService
    {
        private readonly ApplicationDbContext _context;

        public PersonneService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonneDTO>> GetAllPersonnesAsync()
        {
            List<Personne> personnes = await _context.Personnes
                .Include(p => p.Emplois)
                .OrderBy(p => p.Nom)
                .ToListAsync();

            return personnes.Select(p => new PersonneDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                Prenom = p.Prenom,
                DateDeNaissance = p.DateDeNaissance,
                Emplois = p.Emplois.Select(e => new EmploiDTO
                {
                    Id = e.Id,
                    NomEntreprise = e.NomEntreprise,
                    PosteOccupe = e.PosteOccupe,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin
                }).ToList()
            });
        }

        public async Task<PersonneDTO> CreatePersonneAsync(PersonneDTO personneDto)
        {
            var age = DateTime.Now.Year - personneDto.DateDeNaissance.Year;
            if (age > 150)
            {
                throw new Exception("La personne ne peut pas avoir plus de 150 ans.");
            }

            Personne personne = new Personne
            {
                Nom = personneDto.Nom,
                Prenom = personneDto.Prenom,
                DateDeNaissance = personneDto.DateDeNaissance
            };

            _context.Personnes.Add(personne);
            await _context.SaveChangesAsync();
            if (personneDto.Emplois != null && personneDto.Emplois.Any())
            {
                foreach (var emploiDto in personneDto.Emplois)
                {
                    Emploi emploi = new Emploi
                    {
                        NomEntreprise = emploiDto.NomEntreprise,
                        PosteOccupe = emploiDto.PosteOccupe,
                        DateDebut = emploiDto.DateDebut,
                        DateFin = emploiDto.DateFin,
                        PersonneId = personne.Id
                    };
                    _context.Emplois.Add(emploi);
                }
                await _context.SaveChangesAsync();
            }
            personneDto.Id = personne.Id;
            return personneDto;
        }

        public async Task<EmploiDTO> AddEmploiAsync(int personneId, EmploiDTO emploiDto)
        {
            var personne = await _context.Personnes
                .Include(p => p.Emplois)
                .FirstOrDefaultAsync(p => p.Id == personneId);

            if (personne == null)
            {
                throw new Exception("Personne introuvable.");
            }

            var emploi = new Emploi
            {
                NomEntreprise = emploiDto.NomEntreprise,
                PosteOccupe = emploiDto.PosteOccupe,
                DateDebut = emploiDto.DateDebut,
                DateFin = emploiDto.DateFin,
                PersonneId = personne.Id
            };

            _context.Emplois.Add(emploi);
            await _context.SaveChangesAsync();

            emploiDto.Id = emploi.Id;
            return emploiDto;
        }

        public async Task<IEnumerable<PersonneDTO>> GetPersonnesParEntrepriseAsync(string nomEntreprise)
        {
            var personnes = await _context.Emplois
                .Where(e => e.NomEntreprise == nomEntreprise)
                .Select(e => e.Personne)
                .Distinct()
                .ToListAsync();

            return personnes.Select(p => new PersonneDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                Prenom = p.Prenom,
                DateDeNaissance = p.DateDeNaissance
            });
        }

        public async Task<IEnumerable<EmploiDTO>> GetEmploisParDatesAsync(int personneId, DateTime dateDebut, DateTime dateFin)
        {
            var personne = await _context.Personnes
                .Include(p => p.Emplois)
                .FirstOrDefaultAsync(p => p.Id == personneId);

            if (personne == null)
            {
                throw new Exception("Personne introuvable.");
            }

            var emplois = personne.Emplois
                .Where(e => e.DateDebut >= dateDebut && (e.DateFin == null || e.DateFin <= dateFin))
                .Select(e => new EmploiDTO
                {
                    Id = e.Id,
                    NomEntreprise = e.NomEntreprise,
                    PosteOccupe = e.PosteOccupe,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin
                })
                .ToList();

            return emplois;
        }
    }
}
