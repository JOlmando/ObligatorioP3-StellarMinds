namespace StellarMinds.AppWeb.Models.Dtos.Equipos
{
    public record EquipoDtoAlta(
        int? id,
        string marca,
        string modelo,
        int cantidadDisponible,
        int? stockSinUso,
        TipoEquipo tipoEquipo,

        //Camara
        int? tipoSensor,
        int? resolucion,
        int? tamanioPixel,

        //Montura
        decimal? cargaUtil,
        bool esComputarizado,
        int? tipoMontura,

        //Ocular
        int? diametro,
        int? anguloVision,

        //Telescopio
        int? apertura,
        string? relacionFocal,
        decimal? peso,
        int? distanciaFocal
    );

    public enum TipoEquipo
    {
        Telescopio,
        Montura,
        Camara,
        Ocular
    }
}