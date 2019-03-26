using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_MySQL.Models
{
    public static class GerarDados
    {
        public static void Initialize(SeguroContext context)
        {
            context.Database.EnsureCreated();
            // Procura por livros
            if (context.Seguros.Any())
            {
                return;   //O BD foi alimentado
            }
            var seguros = new Seguro[]
            {
              new Seguro{NumApolice="123456-7", CpfCnpj="886.810.230-71", Placa="JXZ-6365", ValPremio= (decimal)320.5},
              new Seguro{NumApolice="234567-4", CpfCnpj="256.982.850-55", Placa="MEH-2597", ValPremio= (decimal)345.6},
              new Seguro{NumApolice="345677-4", CpfCnpj="445.759.730-92", Placa="MLX-5111", ValPremio= (decimal)456.87},
              new Seguro{NumApolice="345678-3", CpfCnpj="420.144.050-85", Placa="MWL-7790", ValPremio= (decimal)345.67},
              new Seguro{NumApolice="565567-3", CpfCnpj="989.092.040-95", Placa="HPO-5570", ValPremio= (decimal)323.44},
            };
            foreach (Seguro p in seguros)
            {
                context.Seguros.Add(p);
            }
            context.SaveChanges();
        }
    }
}
