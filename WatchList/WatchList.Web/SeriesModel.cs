using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchList.Web
{
    public class SeriesModel
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public bool Watched { get; set; }
        public bool Removed { get; set; }

        public SeriesModel(Series series)
        {
            Id = series.returnId();
            Genre = series.returnGenre();
            Title = series.returnTitle();
            Description = series.returnDescription();
            Year = series.returnYear();
            Removed = series.returnRemoved();
            Watched = series.returnWatched();
        }
        public Series ToSeries()
        {
            return new Series(Id, Title, Genre, Year, Description);
        }
    }
}
