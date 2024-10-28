using System;
using System.Collections.Generic;

namespace Prueba_Tecnica_CNBS.Models;

public partial class Ddt
{
    public string Iddt { get; set; } = null!;

    public int Cddtver { get; set; }

    public string Iddtext { get; set; } = null!;

    public string? Iext { get; set; }

    public string Cddteta { get; set; } = null!;

    public DateTime Dddtoficia { get; set; }

    public DateTime? Dddtrectifa { get; set; }

    public string? Cddtcirvis { get; set; }

    public decimal Qddttaxchg { get; set; }

    public string Ista { get; set; } = null!;

    public string Cddtbur { get; set; } = null!;

    public string? Cddtburdst { get; set; }

    public string? Cddtdep { get; set; }

    public string? Cddtentrep { get; set; }

    public string Cddtage { get; set; } = null!;

    public string? Cddtagr { get; set; }

    public string? Lddtagr { get; set; }

    public string Nddtimmioe { get; set; } = null!;

    public string Lddtnomioe { get; set; } = null!;

    public string? Cddtpayori { get; set; }

    public string? Cddtpaidst { get; set; }

    public string? Lddtnomfod { get; set; }

    public string? Cddtincote { get; set; }

    public string Cddtdevfob { get; set; } = null!;

    public string? Cddtdevfle { get; set; }

    public string? Cddtdevass { get; set; }

    public string? Cddttransp { get; set; }

    public string? Cddtmdetrn { get; set; }

    public string? Cddtpaytrn { get; set; }

    public int Nddtart { get; set; }

    public int? Nddtdelai { get; set; }

    public DateTime? Dddtbae { get; set; }

    public DateTime? Dddtsalida { get; set; }

    public DateTime? Dddtcancel { get; set; }

    public DateOnly? Dddtechean { get; set; }

    public string? Cddtobs { get; set; }

    public virtual ICollection<Art> Arts { get; set; } = new List<Art>();
}
