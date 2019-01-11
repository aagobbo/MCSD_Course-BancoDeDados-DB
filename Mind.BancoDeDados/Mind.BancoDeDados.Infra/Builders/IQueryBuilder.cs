using System;
using System.Collections.Generic;
using System.Text;

namespace Mind.BancoDeDados.Infra.Builders
{
    public interface IQueryBuilder<T> where T : IEntity
    {
        string BuildInsert(T instance, out IDictionary<string,object> parametros);
        string BuildUpdate(T instance);
        string BuildSelect();
        string BuildDelete(T instance);
    }
}
