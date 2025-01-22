using Microsoft.EntityFrameworkCore;
using QuizApi.Models.Entities;

namespace QuizApi.Infrastructure.DbContexts;

public class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
{
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<QuizResult> QuizResults { get; set; }
}
