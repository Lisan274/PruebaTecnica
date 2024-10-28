using System;
using System.Collections.Generic;

namespace Prueba_Tecnica_CNBS.Models;

public partial class Lqa
{
    public string Iliq { get; set; } = null!;

    public string Iddt { get; set; } = null!;

    public int Nart { get; set; }

    public string? Clqatax { get; set; }

    public string? Clqatyp { get; set; }

    public decimal? Mlqabas { get; set; }

    public decimal? Qlqacoefic { get; set; }

    public decimal? Mlqa { get; set; }

    public virtual Art Art { get; set; } = null!;

    public virtual Liq IliqNavigation { get; set; } = null!;
}
