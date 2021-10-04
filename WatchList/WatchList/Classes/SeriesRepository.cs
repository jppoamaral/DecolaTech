using System;
using System.Collections.Generic;
using WatchList.Interfaces;

namespace WatchList
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> seriesLst = new List<Series>();

        public List<Series> List()
        {
            return seriesLst;
        }

        public Series returnById(int id)
        {
            return seriesLst[id];
        }

        public void Insert(Series obj)
        {
            seriesLst.Add(obj);
        }

        public void Watch(int id)
        {
            seriesLst[id].Watch();
        }

        public void Remove(int id)
        {
            seriesLst[id].Remove();
        }

        public void Update(int id, Series obj)
        {
            seriesLst[id] = obj;
        }

        public int nextId()
        {
            return seriesLst.Count;
        }
    }
}