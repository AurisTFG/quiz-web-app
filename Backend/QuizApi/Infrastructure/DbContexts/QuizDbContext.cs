using Microsoft.EntityFrameworkCore;
using QuizApi.Models.Entities;

namespace QuizApi.Infrastructure.DbContexts;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<QuizEntry> QuizEntries { get; set; }
}
