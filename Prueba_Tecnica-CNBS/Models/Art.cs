using System;
using System.Collections.Generic;

namespace Prueba_Tecnica_CNBS.Models;

public partial class Art
{
    public string Iddt { get; set; } = null!;

    public int Nart { get; set; }

    public string Carttyp { get; set; } = null!;

    public string Codbenef { get; set; } = null!;

    public string? Cartetamrc { get; set; }

    public string Iespnce { get; set; } = null!;

    public string Cartdesc { get; set; } = null!;

    public string? Cartpayori { get; set; }

    public string? Cartpayacq { get; set; }

    public string? Cartpayprc { get; set; }

    public string? Iddtapu { get; set; }

    public int? Nartapu { get; set; }

    public decimal? Qartbul { get; set; }

    public decimal? Martunitar { get; set; }

    public string? Cartuntdcl { get; set; }

    public decimal? Qartuntdcl { get; set; }

    public string? Cartuntest { get; set; }

    public decimal? Qartuntest { get; set; }

    public decimal? Qartkgrbrt { get; set; }

    public decimal? Qartkgrnet { get; set; }

    public decimal Martfob { get; set; }

    public decimal? Martfobdol { get; set; }

    public decimal? Martfle { get; set; }

    public decimal? Martass { get; set; }

    public decimal? Martemma { get; set; }

    public decimal? Martfrai { get; set; }

    public decimal? Martajuinc { get; set; }

    public decimal? Martajuded { get; set; }

    public decimal Martbasimp { get; set; }

    public virtual Ddt IddtNavigation { get; set; } = null!;

    public virtual ICollection<Lqa> Lqas { get; set; } = new List<Lqa>();
}
