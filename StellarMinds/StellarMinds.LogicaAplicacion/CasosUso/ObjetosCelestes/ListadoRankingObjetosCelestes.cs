using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;

namespace StellarMinds.LogicaAplicacion.CasosUso.ObjetosCelestes
{
    public class ListadoRankingObjetosCelestes(IRepositorioObservacion _repo) : ICUListadoRankingObjetosCelestes<IEnumerable<RankingObjetoCelesteDto>>
    {
        public IEnumerable<RankingObjetoCelesteDto> Execute()
        {
            return _repo.GetAll()

                .GroupBy(o => new
                {
                    o.ObjetoCeleste.Nombre,
                    o.ObjetoCeleste.TipoCeleste
                })

                .Select(g => new RankingObjetoCelesteDto(
                    g.Key.Nombre.Value,
                    g.Key.TipoCeleste,
                    g.Count()))

                .OrderByDescending(x => x.CantidadObservaciones).ToList();
        }
    }
}