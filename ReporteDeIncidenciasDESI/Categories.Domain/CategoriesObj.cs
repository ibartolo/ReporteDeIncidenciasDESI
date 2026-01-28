using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Domain;

namespace Categories.Domain
{
    public class CategoriesObj : Entity<long>
    {
        private long _councilorId { get; set; }
        private string _name { get; set; }
        private string _description { get; set; }
        private long _categoryFatherId { get; set; }
        private int _order { get; set; }
        private int _attentiontime { get; set; }

        [JsonPropertyName("RegiduriaId")]
        public long CouncilorId => _councilorId;
        [JsonPropertyName("Nombre")]
        public string Name => _name;
        [JsonPropertyName("Descripcion")]
        public string Description => _description;
        [JsonPropertyName("CategoriaPadreId")]
        public long CategoryFatherId => _categoryFatherId;
        [JsonPropertyName("Orden")]
        public int Order => _order;
        [JsonPropertyName("TiempoAtencionEstimado")]
        public int Attentiontime => _attentiontime;

        private CategoriesObj(long categoriesId)
        {
            Id = categoriesId;
            _councilorId = 0;
            _name = string.Empty;
            _description = string.Empty;
            _categoryFatherId = 0;
            _order = 0;
            _attentiontime = 0;
        }

        public static CategoriesObj Create(long categoryId)
        {
            return new CategoriesObj(categoryId);
        }

        public CategoriesObj SetInformationAditional(string name, string description)
        {
            if (!string.IsNullOrWhiteSpace(name))
                _name = name;

            if (!string.IsNullOrWhiteSpace(description))
                _description = description;
            return this;
        }

        public CategoriesObj SetInformationCouncilor(long councilorId, long categoryfatherId, int order, int attention)
        {
            if (councilorId > 0)
                _councilorId = councilorId;
            if (categoryfatherId > 0)
                _categoryFatherId = categoryfatherId;
            if (order > 0)
                _order = order;
            if (attention > 0)
                _attentiontime = attention;
            return this;
        }
    }
}