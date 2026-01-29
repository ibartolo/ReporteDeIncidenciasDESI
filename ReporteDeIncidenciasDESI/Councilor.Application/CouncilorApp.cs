using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Councilor.Domain;
using Common.Domain;
using Councilor.Proxy;

namespace Councilor.Application
{
    public class CouncilorApp : ICouncilorApp
    {
        private readonly ICouncilorProxy _proxy;

        public CouncilorApp(ICouncilorProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public List<CouncilorObj> GetAllCouncilors(out OperationResult result)
        {
            result = new OperationResult() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<CouncilorObj> list = new List<CouncilorObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllCouncilors();
                list = CouncilorMapp.MappCouncilor(responseDT) ?? new List<CouncilorObj>();
            }
            catch (Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener las regidurias" });
            }
            return list;
        }

        public CouncilorObj GetCouncilorById(long id, out OperationResult result)
        {
            result = new OperationResult() { Successful = true };
            CouncilorObj obj = null;
            try
            {
                DataTable responseDT = _proxy.GetCouncilorById(id);
                obj = CouncilorMapp.MappCouncilor(responseDT).First();
            }
            catch (Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la regiduria." });
            }
            return obj;
        }
    }
}
