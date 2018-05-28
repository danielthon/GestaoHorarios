﻿using System;

namespace GestaoHorarios.classes.estrutura
{
    public interface IDado : IEquatable<IDado>
    {
        bool Equals(IDado other);
        int CompareTo(IDado other);
    }
}
