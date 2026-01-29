using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Councilor.Domain;
namespace Councilor.Application
{
    public interface ICouncilorApp
    {
        List<CouncilorObj> GetAllCouncilors(out OperationResult result); 
        CouncilorObj GetCouncilorById(long id, out OperationResult result);
    }
}
