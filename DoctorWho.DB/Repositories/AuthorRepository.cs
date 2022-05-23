using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Repositories
    {


    public class AuthorRepository
        {

        static DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();

        public static void DeleteAuthor(int id)
            {


            //var x = context.Authors.Find(id);
            var x = context.Authors.Where(d => d.AuthorId == 1).First();
            var episodes = x.Episodes.ToList();
            foreach( var episode in episodes )
                {
                context.Episodes.Remove(episode);

                }
            if( x == null ) return;
            context.Authors.Remove(x);
            context.SaveChanges();
            }

        }
    }
