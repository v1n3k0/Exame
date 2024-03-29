﻿using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Cosif;
using Exame.Dominio.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Interfaces.Services
{
    public interface IServiceCosif: IServiceBase
    {
        CosifResponse Adicionar(AdicionarCosifRequest request);

        CosifResponse Editar(EditarCosifRequest request);

        CosifResponse Obter(Guid codigo);

        ResponseBase Remover(Guid codigo);

        IEnumerable<CosifResponse> Listar();
    }
}
