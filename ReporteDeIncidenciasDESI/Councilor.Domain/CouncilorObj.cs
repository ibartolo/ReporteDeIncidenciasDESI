using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Councilor.Domain
{
    public class CouncilorObj : Entity<long>
    {
        private string _name;
        private string _description;
        private int _order;
        private bool _estatus;
        private string _createdBy;
        private DateTime _createdDt;
        private string _updatedBy;
        private DateTime _updatedDt;

        public string Name => _name;
        public string Description => _description;
        public int Order => _order;
        public bool Estatus => _estatus;
        public string CreatedBy => _createdBy;
        public DateTime CreatedDt => _createdDt;
        public string UpdatedBy => _updatedBy;
        public DateTime UpdatedDt => _updatedDt;

        private CouncilorObj(long councilorId)
        {
            Id = councilorId;
            _name = string.Empty;
            _description = string.Empty;
            _order = 0;
            _estatus = false;
            _createdBy = string.Empty;
            _createdDt = DateTime.MinValue;
            _updatedBy = string.Empty;
            _updatedDt = DateTime.MinValue;
        }

        public static CouncilorObj Create(long councilorId)
        {
            return new CouncilorObj(councilorId);
        }

        public CouncilorObj SetInformationAditional(string name, string description, int order)
        {
            if (!string.IsNullOrWhiteSpace(name))
                _name = name;

            if (!string.IsNullOrWhiteSpace(description))
                _description = description;

            if (order > 0)
                _order = order;
            return this;
        }

        public CouncilorObj SetInformationCreated(string createdBy, DateTime CreatedDt)
        {
            _createdBy = createdBy;
            _createdDt = CreatedDt;
            return this;
        }

        public CouncilorObj SetInformationUpdated(string updatedBy, DateTime updatedDt)
        {
            _updatedBy = updatedBy;
            _updatedDt = updatedDt;
            return this;
        }
    }
}

