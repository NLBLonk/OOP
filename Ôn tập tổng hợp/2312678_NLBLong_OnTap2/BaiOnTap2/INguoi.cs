using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiOnTap2
{
    public interface INguoi
    {
        string Ho {  get; set; }
        string Ten {  get; set; }
        string LayTenDayDu();
    }
}
