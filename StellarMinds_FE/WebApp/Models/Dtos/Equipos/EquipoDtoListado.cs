namespace StellarMinds.AppWeb.Models.Dtos.Equipos
{
    public record EquipoDtoListado(
        int Id,
        string Marca,
        string Modelo,
        int StockSinUso,
        int TipoEquipo
    );
}