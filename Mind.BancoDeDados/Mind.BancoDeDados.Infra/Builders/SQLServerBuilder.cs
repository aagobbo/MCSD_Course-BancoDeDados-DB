using Mind.BancoDeDados.Infra.CustomAttributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mind.BancoDeDados.Infra.Builders
{
    public class SQLServerBuilder<T> : IQueryBuilder<T> where T : IEntity
    {
        public SQLServerBuilder()
        {
        }

        public string BuildDelete(T instance)
        {
            throw new System.NotImplementedException();
        }

        public string BuildInsert(T instance,  out IDictionary<string, object> parametros)
        {
            var type = typeof(T);
            var select = new StringBuilder();
            var tableAttribute = type.GetCustomAttributes(false).OfType<TableAttribute>();
            var tableName = default(string);

            if (tableAttribute == null)
                tableName = type.Name;
            else
                tableName = tableAttribute.First().Nome;

            select.Append("insert into ");
            select.Append(tableName);
            select.Append(" (");

            var columns = new List<string>();
            var values = new List<string>();
            var parametrosInternos = new Dictionary<string, object>();
            foreach (var property in type.GetProperties())
            {
                var column = property.GetCustomAttributes(false).OfType<ColumnAttribute>();

                var key = "";
                var value = property.GetValue(instance);

                if (column == null)
                    key = property.Name;
                else
                    key = column.First().Name;

                columns.Add(key);
                parametrosInternos.Add(key, value);
            }
            parametros = parametrosInternos;
            select.Append(string.Join(", ", columns));
            select.Append(") values (");
            select.Append(string.Join(", @", columns));
            select.Append(")");

            return select.ToString();
        }

        public string BuildSelect()
        {
            var type = typeof(T);
            var select = new StringBuilder();
            var tableAttribute = type.GetCustomAttributes(false).OfType<TableAttribute>();
            var tableName = default(string);

            if (tableAttribute == null)
                tableName = type.Name;
            else
                tableName = tableAttribute.First().Nome;

            select.Append("select ");
            var columns = new List<string>();
            foreach (var property in type.GetProperties())
            {
                var column = property.GetCustomAttributes(false).OfType<ColumnAttribute>();

                if (column == null)
                    columns.Add(property.Name);
                else
                    columns.Add(column.First().Name);

            }
            select.Append(string.Join(", ", columns));
            select.Append(" from ");
            select.Append(tableName);


            return select.ToString();
        }

        public string BuildUpdate(T instance)
        {
            throw new System.NotImplementedException();
        }
    }
}
