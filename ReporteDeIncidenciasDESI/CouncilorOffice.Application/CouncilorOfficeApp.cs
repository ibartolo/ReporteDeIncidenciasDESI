using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouncilorOffice.Domain;
using CouncilorOffice.Proxy;

namespace CouncilorOffice.Application
{
    public class CouncilorOfficeApp
    {
        private ICouncilorOfficeProxy _proxy;
        public CouncilorOfficeApp(ICouncilorOfficeProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }
    }
}
