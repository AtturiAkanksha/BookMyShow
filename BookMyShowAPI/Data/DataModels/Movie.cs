﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataModels
{
    [Table("Movie")]
    public class Movie
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("MovieName")]
        public string? MovieName { get; set; }
        [Column("Language")]
        public string Language { get; set; }
        [Column("Hours")]
        public string Hours { get; set; }
        [Column("Genre")]
        public string Genre { get; set; }
        [Column("DateOfRelease")]
        public DateTime DateOfRelease { get; set; }
    }
}
