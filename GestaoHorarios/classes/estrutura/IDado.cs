using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHorarios.classes.estrutura
{
    interface IDado : IEquatable<IDado>
    {
        bool Equals(IDado other);
        int CompareTo(IDado other);
    }
}
