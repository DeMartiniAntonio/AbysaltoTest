using AbySalto.Junior.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Infrastructure.Database
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderArticle> OrderArticles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
