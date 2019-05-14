using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CareerDays.API.Swagger
{
    public class SwaggerReadonlyFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
                return;

            foreach (var prop in schema.Properties)
            {
                var property = context.SystemType.GetProperty(prop.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property == null)
                    continue;

                if (prop.Value.Ref != null)
                {
                    prop.Value.AllOf = new List<Schema>
                        {
                            new Schema
                            {
                                Ref = prop.Value.Ref
                            }
                        };
                    prop.Value.Ref = null;
                }

                prop.Value.ReadOnly = true;
            }
        }
    }
}
