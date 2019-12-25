using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Domain.Models.Domain;
using Domain.Models.Identity;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        //add-migration name -Project Infrastructure
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProfileLike>()
                .HasKey(key => new { key.UserId, key.PsychologistId });

            builder.Entity<ProfileLike>()
                .HasOne(l => l.Psychologist)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TopicLike>()
                .HasKey(key => new { key.UserId, key.TopicId });

            builder.Entity<TopicLike>()
                .HasOne(tl => tl.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TestResult>()
                .HasOne(tl => tl.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TopicAnswer>()
                .HasOne(tl => tl.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        //seed database
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                //Resolve ASP .NET Core Identity with DI help
                var userManager = (UserManager<User>)scope.ServiceProvider.GetService(typeof(UserManager<User>));
                var roleManager = (RoleManager<IdentityRole<long>>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole<long>>));

                //adding customs roles
                string[] roleNames = { "admin", "user", "psychologist", "visitor", "ban" };

                foreach (var roleName in roleNames)
                {
                    bool roleExist = await roleManager.RoleExistsAsync(roleName);
                    
                    if (!roleExist)
                    {
                        //create the role and seed it to database
                        await roleManager.CreateAsync(new IdentityRole<long>(roleName));
                    }
                }

                var superUser = userManager
                    .Users
                    .Where(u => u.Email == "admin@gmail.com");

                //register super user
                //email: admin@gmail.com
                //password: qwerty123
                if (superUser != null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    var options = optionsBuilder
                            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                            .Options;

                    using (var context = new ApplicationDbContext(options))
                    {
                        var admin = new User
                        {
                            Email = "admin@gmail.com",
                            UserName = "admin@gmail.com",
                            
                            //custom fields
                            Nickname = "Admin",
                            Age = 100,
                        };

                        var result = await userManager.CreateAsync(admin, "qwerty123");

                        if (result.Succeeded)
                        {
                            await context.SaveChangesAsync();
                            await userManager.AddToRoleAsync(admin, "admin");
                        }
                    }
                }
            }
        }


        public DbSet<ProfileLike> ProfileLikes { get; set; }
        public DbSet<PsychoApproveRequest> PsychoApproveRequests { get; set; }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestQuestionOption> TestQuestionOptions { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        public DbSet<TopicQuestion> TopicQuestions { get; set; }
        public DbSet<TopicAnswer> TopicAnswers { get; set; }
        public DbSet<TopicLike> TopicLikes { get; set; }

        public DbSet<TwitterUserStatistic> TwitterUserStatistics { get; set; }
        public DbSet<TwitterUserTweet> TwitterUserTweets { get; set; }

        public DbSet<ForumVideo> ForumVideos { get; set; }
    }
}
