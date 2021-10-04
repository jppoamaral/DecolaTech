using System;
using System.Collections.Generic;
using WatchList.Interfaces;

namespace WatchList
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> movieLst = new List<Movie>();

        public List<Movie> List()
        {
            return movieLst;
        }

        public Movie returnById(int id)
        {
            return movieLst[id];
        }

        public void Insert(Movie obj)
        {
            movieLst.Add(obj);
        }

        public void Watch(int id)
        {
            movieLst[id].Watch();
        }

        public void Remove(int id)
        {
            movieLst[id].Remove();
        }

        public void Update(int id, Movie obj)
        {
            movieLst[id] = obj;
        }

        public int nextId()
        {
            return movieLst.Count;
        }
    }
}