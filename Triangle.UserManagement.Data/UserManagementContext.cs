using Microsoft.EntityFrameworkCore;
using System;
using Triangle.UserManagement.Core.Model.UserAggregate;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Triangle.UserManagement.Data
{
    public class UserManagementContext : DbContext,IUserManagementContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public void Add<T>(params T[] entities) where T : class
        {
            Set<T>().AddRange(entities);
        }

        public void ModelStateAdd<T>(params T[] entities) where T : class
        {
            Entry(entities).State = EntityState.Added;
        }

        public void Edit<T>(T entity) where T : class
        {
            Set<T>().Update(entity);
        }

        public void Delete<T>(params T[] entities) where T : class
        {
            Set<T>().RemoveRange(entities);
        }

        public System.Linq.IQueryable<T> GetAll<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }

        public System.Linq.IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate) where T : class
        {
            return Set<T>().Where(predicate).AsQueryable();
        }

        public bool ExecusteSqlCommand(string sql)
        {
            return Database.ExecuteSqlCommand(sql) > 0;
        }

        public async Task<bool> ExecuteSqlCommandAsync(string sql)
        {
            return await Database.ExecuteSqlCommandAsync(sql) > 0;
        }

        public void Commit(string query)
        {
            Database.ExecuteSqlCommand(query);
        }

        public async Task<int> CommitAsync(string query)
        {
            return await Database.ExecuteSqlCommandAsync(query);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public async Task<int> CommitSync()
        {
            return await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
