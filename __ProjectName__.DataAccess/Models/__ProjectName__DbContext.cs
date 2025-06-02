using __ProjectName__.Domain.Models;
using Justin.EntityFramework.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace __ProjectName__.DataAccess.Models {
    public class __ProjectName__DbContext : BaseDbContext<__ProjectName__DbContext> {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public __ProjectName__DbContext(DbContextOptions<__ProjectName__DbContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor) {

            _httpContextAccessor = httpContextAccessor;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

        #region Db Setup

        public override int SaveChanges(bool acceptAllChangesOnSuccess) {
            SetDefaultValues();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) {
            SetDefaultValues();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            if(modelBuilder != null) {

                modelBuilder.UseIdentityByDefaultColumns();
                modelBuilder.HasPostgresExtension("citext");
                //modelBuilder.Entity<Base>().HasQueryFilter(x => !x.IsDeleted);
                base.OnModelCreating(modelBuilder);

            }
        }

        public override void SetDefaultValues() {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            string currUsername = "Anonymous";
            if(_httpContextAccessor.HttpContext != null) {
                // try get username
                var user = _httpContextAccessor.HttpContext.User;
                var userName = user.FindFirst(x => x.Type == "Name");

                if(userName != null)
                    currUsername = userName.Value;

            }

            SwitchState(entities, currUsername);

        }
        #endregion

        #region DbSet

        public virtual DbSet<User> Users { get; set; }

        #endregion

    }
}
