﻿namespace LaunchCodeCapstone.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Users User { get; set; }

        //public Ratings Rating {  get; set; }
        
    }
}
