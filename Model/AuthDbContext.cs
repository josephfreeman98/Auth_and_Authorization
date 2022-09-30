using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication_and_Authorization.Model {
    public class AuthDbContext : IdentityDbContext {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) {

        }
    }
}
