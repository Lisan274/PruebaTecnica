using System;
using System.Collections.Generic;

namespace Prueba_Tecnica_CNBS.Models;

public partial class Liq
{
    public string Iliq { get; set; } = null!;

    public string Cliqdop { get; set; } = null!;

    public string Cliqeta { get; set; } = null!;

    public decimal Mliq { get; set; }

    public decimal Mliqgar { get; set; }

    public DateTime? Dlippay { get; set; }

    public string? Clipnomope { get; set; }

    public virtual ICollection<Lqa> Lqas { get; set; } = new List<Lqa>();
}
