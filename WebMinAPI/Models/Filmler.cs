using System;
using System.Collections.Generic;

namespace WebMinAPI.Models
{
    public partial class Filmler
    {
        public int FilmId { get; set; }
        public string FilmAdi { get; set; } = null!;
        public int Sure { get; set; }
        public int? KatId { get; set; }

        public virtual Kategoriler? Kat { get; set; }
    }
}
