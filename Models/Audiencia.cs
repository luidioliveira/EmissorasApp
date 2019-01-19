using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmissorasApp.Models
{
    public class Audiencia
    {
        public int ID { get; set; }
        public float pontosAudiencia { get; set; }
        public DateTime dataHoraAudiencia { get; set; }
        public int emissoraAudiencia { get; set; }
    }
}