using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace APIFutScore.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // authenticationType deve corresponder a um definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Adicione declarações de usuários aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<APIFutScore.Models.Cartao> Cartaos { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Equipe> Equipes { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Escalacao> Escalacaos { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Escanteio> Escanteios { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Falta> Faltas { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Gols> Gols { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Jogador> Jogadors { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Jogo> Jogoes { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Penalti> Penaltis { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Resultado> Resultadoes { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Subtituicao> Subtituicaos { get; set; }

        public System.Data.Entity.DbSet<APIFutScore.Models.Usuario> Usuarios { get; set; }
    }
}