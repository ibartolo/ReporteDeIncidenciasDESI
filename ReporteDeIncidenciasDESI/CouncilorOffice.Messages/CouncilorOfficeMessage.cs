using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using CouncilorOffice.Domain;

namespace CouncilorOffice.Messages
{
    public class CouncilorOfficeMessage
    {
    }

    public class CouncilorOfficeObjListResponse()
    {
        public List<CouncilorOfficeObj> councilors { get; set; }
        public OperationResult result { get; set; }
    }

    public class CouncilorOfficeObjResponse()
    {
        public CouncilorOfficeObj councilor { get; set; }
        public OperationResult result { get; set; }
    }
}
