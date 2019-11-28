using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorokhov.Entities
{
    public partial class Equipment
    {
        public string Info { get => $"{CodeEquipment} {Model.ModelAndBrand}"; set => Info = value; }
    }
}
