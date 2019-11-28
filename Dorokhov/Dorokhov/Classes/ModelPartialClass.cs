using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorokhov.Entities
{
    public partial class Model
    {
        public string ModelAndBrand { get => $"{Brand.NameBrand} {NameModel}"; set => ModelAndBrand = value; }
    }
}
