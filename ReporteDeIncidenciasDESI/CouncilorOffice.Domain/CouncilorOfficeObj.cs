using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace CouncilorOffice.Domain
{
    public class CouncilorOfficeObj : Entity<long>
    {
        private string _name;
        private string _description;
        private int _order;

        [JsonPropertyName("Nombre")]
        public string Name => _name;
        [JsonPropertyName("Descripcion")]
        public string Description => _description;
        [JsonPropertyName("Orden")]
        public int Order => _order;

        private CouncilorOfficeObj(long councilorId)
        {
            Id = councilorId;
            _name = string.Empty;
            _description = string.Empty;
            _order = 0;
        }

        public static CouncilorOfficeObj Create(long councilorId)
        {
            return new CouncilorOfficeObj(councilorId);
        }

        public CouncilorOfficeObj SetInformationAditional(string name, string description, int order)
        {
            if (!string.IsNullOrWhiteSpace(name))
                _name = name;

            if (!string.IsNullOrWhiteSpace(description))
                _description = description;

            if (order > 0)
                _order = order;
            return this;
        }
    }
}
