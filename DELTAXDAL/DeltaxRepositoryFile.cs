using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DELTAXDAL
{
    public class DeltaxRepositoryFile
    {
        public deltaxEntities db;

        public DeltaxRepositoryFile()
        {
            db=new deltaxEntities();
        }

        //CRUD ADD : Add Movie
        public bool AddMovie(Movie mv)
        {
            db.Movies.Add(mv);
            db.SaveChanges();
            return true;
        }

        //CRUD Update : Edit Movie
        public void EditMovie(Movie mv)
        {
            var result = db.Movies.Find(mv.Name);
            result.Name = mv.Name;
            result.plot = mv.plot;
            result.yearofRelease = mv.yearofRelease;
            result.Actors = mv.Actors;
            result.Poster = mv.Poster;
            db.SaveChanges();
        }

        //CRUD Read All : Get List
        public List<Movie> GetMovieList()
        {
            var result = db.Movies.ToList();
            return result;
        }

        //CRUD READ : Get single value
        public Movie GetMovieDetails(string name)
        {
            var result = db.Movies.Find(name);
            return result;
        }

        //CRUD DELETE:Delete Movie
        public void DeleteMovie(Movie mv)
        {
            db.Movies.Remove(mv);
        }


        //-----------ACTORS--------------//

        //CRUD Read All : Get List
        public List<Actor> GetActorsList()
        {
            var result = db.Actors.ToList();
            return result;
        }

        //CRUD ADD : Add Actor
        public bool AddActor(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
            return true;
        }

        //CRUD Update : Edit Actor
        public void EditActor(Actor actor)
        {
            var result = db.Actors.Find(actor.Name);
            result.Name = actor.Name;
            result.bio = actor.bio;
            result.dob = actor.dob;
            result.sex = actor.sex;
            db.SaveChanges();
        }


        //CRUD READ : Get single value
        public Actor GetActorDetails(string name)
        {
            var result = db.Actors.Find(name);
            return result;
        }

        //CRUD DELETE:Delete Movie
        public void DeleteActor(Actor mv)
        {
            db.Actors.Remove(mv);
        }

    }
}
