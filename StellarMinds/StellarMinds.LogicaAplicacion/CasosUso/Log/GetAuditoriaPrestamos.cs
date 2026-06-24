using StellarMinds.LogicaAplicacion.Dtos.Logs;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StellarMinds.LogicaAplicacion.CasosUso.Logs
{
    public class GetAuditoriaPrestamos : ICUGetAuditoriaPrestamos<IEnumerable<LogPrestamoDto>>
    {
        private readonly IRepositorioLog _repo;

        public GetAuditoriaPrestamos(IRepositorioLog repo)
        {
            _repo = repo;
        }

        public IEnumerable<LogPrestamoDto> Execute(int? usuarioId)
        {
            var logs = _repo.GetAll()
                .Where(l =>
                    l.TableName == "Prestamo" &&
                    l.PrestamoId != null);

            if (usuarioId.HasValue)
            {
                logs = logs.Where(l => l.UsuarioId == usuarioId.Value);
            }

            return logs
                .OrderByDescending(l => l.DateTime)
                .Select(l =>
                    new LogPrestamoDto(
                        l.Id,
                        l.PrestamoId!.Value,
                        l.UsuarioId,
                        l.Operation,
                        l.DateTime))
                .ToList();
        }
    }
}