using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dorokhov.Entities
{
    public partial class Employee
    {
        public string FullName { get => $"{Surname} {Name} {Patronymic}"; set => FullName = value; }
    }
}
