﻿using BancoAtlantidaChallenge.Domain.Common;

namespace BancoAtlantidaChallenge.Domain.Entities;
public class TarjetaDeCredito : BaseEntity
{
    public string? NumeroDeTarjeta { get; set; }
    public int Limite { get; set; }
    public decimal SaldoTotal { get; set; }
    public decimal PorcentajeInteresConfigurable { get; set; }
    public decimal PorcentajeConfigurableSaldoMinimo { get; set; }

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}
