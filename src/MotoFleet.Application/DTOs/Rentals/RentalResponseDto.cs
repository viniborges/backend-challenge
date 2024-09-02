namespace MotoFleet.Application.DTOs.Rentals;

public class RentalResponseDto
{
    public Guid Id { get; set; }
    public Guid EntregadorId { get; set; }
    public Guid MotoId { get; set; }
    public Guid PlanoId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public DateTime DataPrevisaoTermino { get; set; }
    public decimal ValorDiaria { get; set; }
    public bool FoiFeitaDevolucao { get; set; }
    public decimal? ValorTotal { get; set; }
    public int? QuantidadeDiasLocacao { get; set; }
    
    public RentalResponseDto(Guid id, Guid entregadorId, Guid motoId, Guid planoId, DateTime dataInicio, DateTime? dataDevolucao, DateTime dataPrevisaoTermino, decimal valorDiaria, bool foiFeitaDevolucao, decimal? valorTotal, int? quantidadeDiasLocacao)
    {
        Id = id;
        EntregadorId = entregadorId;
        MotoId = motoId;
        PlanoId = planoId;
        DataInicio = dataInicio;
        DataDevolucao = dataDevolucao;
        DataPrevisaoTermino = dataPrevisaoTermino;
        ValorDiaria = valorDiaria;
        FoiFeitaDevolucao = foiFeitaDevolucao;
        ValorTotal = valorTotal;
        QuantidadeDiasLocacao = quantidadeDiasLocacao;
    }

    public RentalResponseDto(Guid id, Guid entregadorId, Guid motoId, Guid planoId, DateTime dataInicio, DateTime dataPrevisaoTermino, decimal valorDiaria, bool foiFeitaDevolucao)
    {
        Id = id;
        EntregadorId = entregadorId;
        MotoId = motoId;
        PlanoId = planoId;
        DataInicio = dataInicio;
        DataPrevisaoTermino = dataPrevisaoTermino;
        ValorDiaria = valorDiaria;
        FoiFeitaDevolucao = foiFeitaDevolucao;
    }
}

