using System;

namespace WatchList
{
    public class Series : BaseEntity
    {
        private string Title { get; set; }
        private Genre Genre { get; set; }
        private int Year { get; set; }
        private string Description { get; set; }
        private bool Watched { get; set; }
        private bool Removed { get; set; }

        public Series(int id, string title, Genre genre, int year, string descrpt)
        {
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
            this.Year = year;
            this.Description = descrpt;
            this.Watched = false;
            this.Removed = false;
            this.Type = (Type)2;
        }

        public override string ToString()
		{
            Console.WriteLine();
			string retorno = "";
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Initial Release Year: " + this.Year + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Watched: " + this.Watched + Environment.NewLine;
            retorno += "Removed: " + this.Removed;
			return retorno;
		}

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnWatched()
        {
            return this.Watched;
        }

        public bool returnRemoved()
        {
            return this.Removed;
        }
        
        public void Watch()
        {
            this.Watched = true;
        }
        public void Remove()
        {
            this.Removed = true;
        }

        public Genre returnGenre()
        {
            return Genre;
        }

        public string returnDescription()
        {
            return Description;
        }

        public int returnYear()
        {
            return Year;
        }
    }
}
