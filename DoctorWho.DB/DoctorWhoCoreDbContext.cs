using System;
using System.Collections.Generic;
using DoctorWho.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DoctorWho.DB
    {
    public class DoctorWhoCoreDbContext:DbContext
        {

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<KeylessEntity> KeylessEntity { get; set; }
        public DbSet<viewEpisodes> ViewEpisodes { get; set; }

        public string fnCompanion(int id)
            {
            throw new NotImplementedException();
            }
        [DbFunction]
        public static string fnEnemies(int id)
            {
            throw new NotImplementedException();
            }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DoctorWhoCore");





            }
        public static readonly ILoggerFactory ConsoleLoggerFactory
           = LoggerFactory.Create(builder =>
          {
              builder
          .AddFilter((category ,level) =>
               category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information)
          .AddConsole();
          });
        protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);

            builder.Entity<Episode>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Episodes);

            builder.Entity<EpisodeCompanion>()
                .HasOne(e => e.Episode)
                .WithMany(e => e.EpisodeCompanion);

            builder.Entity<EpisodeCompanion>()
                .HasOne(e => e.Companion)
                .WithMany(e => e.EpisodeCompanion);
            builder.Entity<EpisodeEnemy>()
                .HasOne(e => e.Episode)
                .WithMany(e => e.EpisodeEnemies)
                .HasForeignKey(e => e.EpisodeId);
            builder.Entity<EpisodeEnemy>()
                .HasOne(e => e.Enemy)
                .WithMany(e => e.EpisodeEnemies)
                .HasForeignKey(e => e.EnemyID);
            builder.Entity<KeylessEntity>().HasNoKey();
            //view Mapping 

            builder.Entity<viewEpisodes>().HasNoKey().ToView("viewEpisodes");

            //func MAPPING

            builder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                .GetMethod(nameof(fnCompanion) ,
             new[] { typeof(int) }));

            builder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
               .GetMethod(nameof(fnEnemies) ,
            new[] { typeof(int) })).HasName("fnEnemies").HasSchema("dbo");
            //constrains
            builder.Entity<Episode>().HasAlternateKey(e => e.SeriesNumber);//unique --this was added as constrain in mig file
            builder.Entity<Episode>().HasIndex(e => e.EpisodeNumber).IsUnique();//unique
            builder.Entity<Doctor>().HasAlternateKey(e => e.DoctorNumber);//unique
                                                                          //sCALER VALUE FUNCTION MAPPING 

            //Dataseeding 
            builder.Entity<Doctor>().HasData(
                new Doctor
                    {
                    DoctorId = 1 ,
                    DoctorNumber = 1 ,
                    DoctorName = "Hani" ,
                    FirstEpisodeDate = new DateTime(2022 ,07 ,05) ,
                    LastEpisodeDate = new DateTime(2022 ,08 ,8)
                    } ,
                new Doctor
                    {
                    DoctorId = 2 ,
                    DoctorNumber = 2 ,
                    DoctorName = "Huda" ,
                    FirstEpisodeDate = new DateTime(2022 ,07 ,08) ,
                    LastEpisodeDate = new DateTime(2022 ,08 ,8) ,
                    BirthDate = new DateTime(1970 ,7 ,7)
                    } ,
                 new Doctor
                     {
                     DoctorId = 3 ,
                     DoctorNumber = 3 ,
                     DoctorName = "Nada" ,
                     FirstEpisodeDate = new DateTime(2022 ,09 ,01) ,
                     LastEpisodeDate = new DateTime(2022 ,09 ,20) ,
                     BirthDate = new DateTime(1978 ,7 ,7)
                     } ,
                  new Doctor
                      {
                      DoctorId = 4 ,
                      DoctorNumber = 4 ,
                      DoctorName = "Ali" ,
                      FirstEpisodeDate = new DateTime(2022 ,09 ,01) ,
                      LastEpisodeDate = new DateTime(2022 ,09 ,20) ,
                      BirthDate = new DateTime(1978 ,7 ,7)
                      } ,
                  new Doctor
                      {
                      DoctorId = 5 ,
                      DoctorNumber = 5 ,
                      DoctorName = "salam" ,
                      FirstEpisodeDate = new DateTime(2022 ,09 ,01) ,
                      LastEpisodeDate = new DateTime(2022 ,09 ,20) ,
                      BirthDate = new DateTime(1978 ,7 ,7)
                      }

                );
            Author[] Authors = new Author[5];
            Authors[0] = new Author { AuthorId = 1 ,AuthorName = "Mohamed" };
            Authors[1] = new Author { AuthorId = 2 ,AuthorName = "Ahmed" };
            Authors[2] = new Author { AuthorId = 3 ,AuthorName = "Aseel" };
            Authors[3] = new Author { AuthorId = 4 ,AuthorName = "Omar" };
            Authors[4] = new Author { AuthorId = 5 ,AuthorName = "Marwa" };
            builder.Entity<Author>().HasData(
                Authors[0] ,
                Authors[1] ,
                Authors[2] ,
                Authors[3] ,
                Authors[4]

                );
            builder.Entity<Episode>().HasData
               (
                new
                    {
                    EpisodeId = 1 ,
                    EpisodeNumber = 1 ,
                    SeriesNumber = 1 ,
                    EpisodeType = "type1" ,
                    Tittle = "tittle1" ,
                    EpisodeDate = new DateTime(2018 ,7 ,24) ,
                    DoctorId = 1 ,
                    //  Author = Authors[0] // , doesnt work  :
                    //  The seed entity for entity type 'Episode'
                    // with the key value 'EpisodeId:1' cannot be added because it has the navigation 'Author' set.
                    // To seed relationships you need to add the related entity seed to 'Author' and specify the foreign key values {'AuthorId'}.



                    } ,
                new Episode
                    {
                    EpisodeId = 2 ,

                    EpisodeNumber = 2 ,
                    SeriesNumber = 165 ,
                    EpisodeType = "type1" ,
                    Tittle = "tittle2" ,
                    EpisodeDate = new DateTime(2022 ,7 ,24) ,
                    DoctorId = 1 ,
                    // Author = Authors[1]



                    } ,
                 new Episode
                     {
                     EpisodeId = 3 ,

                     EpisodeNumber = 3 ,
                     SeriesNumber = 188 ,
                     EpisodeType = "type1" ,
                     Tittle = "tittle1" ,
                     EpisodeDate = new DateTime(2023 ,7 ,24) ,
                     Notes = "notes3" ,
                     DoctorId = 1 ,
                     //Author = Authors[0]

                     } ,
                 new Episode
                     {
                     EpisodeId = 4 ,

                     EpisodeNumber = 4 ,
                     SeriesNumber = 189 ,
                     EpisodeType = "type3" ,
                     Tittle = "tittle4" ,
                     EpisodeDate = new DateTime(2023 ,7 ,24) ,
                     Notes = "notes4" ,
                     DoctorId = 2 ,
                     //Author = Authors[0]


                     } ,
                 new Episode
                     {
                     EpisodeId = 5 ,

                     EpisodeNumber = 5 ,
                     SeriesNumber = 181 ,
                     EpisodeType = "type2" ,
                     Tittle = "tittle5" ,
                     EpisodeDate = new DateTime(2023 ,7 ,24) ,
                     Notes = "notes5" ,
                     DoctorId = 3 ,
                     //Author = Authors[4]


                     }
                     );

            builder.Entity<Companion>().HasData(
                new Companion { CompanionID = 1 ,CompanionName = "NAME1" ,WhoPlayed = "W1" } ,
                new Companion { CompanionID = 2 ,CompanionName = "NAME2" ,WhoPlayed = "W2" } ,
                new Companion { CompanionID = 3 ,CompanionName = "NAME3" ,WhoPlayed = "W3" } ,
                new Companion { CompanionID = 4 ,CompanionName = "NAME4" ,WhoPlayed = "W4" } ,
                new Companion { CompanionID = 5 ,CompanionName = "NAME5" ,WhoPlayed = "W5" }
                );


            builder.Entity<Enemy>().HasData(
               new Enemy { EnemyId = 1 ,EnemyName = "enemy1" ,Description = "this is description" } ,
               new Enemy { EnemyId = 8 ,EnemyName = "enemy2" ,Description = "this is description22" } ,
               new Enemy { EnemyId = 3 ,EnemyName = "enemy1" ,Description = "this is description" } ,
               new Enemy { EnemyId = 4 ,EnemyName = "enemy1" ,Description = "this is description" } ,
               new Enemy { EnemyId = 5 ,EnemyName = "enemy1" ,Description = "this is description" }


                );
            builder.Entity<EpisodeEnemy>().HasData(new EpisodeEnemy { EpisodeEnemyId = 9 ,EnemyID = 8 ,EpisodeId = 2 });


            }
        }
    }
