using System;

namespace BLL.Estruturas
{
    public interface IDado : IEquatable<IDado>
    {
        bool Equals(IDado other);
        int CompareTo(IDado other);
    }
}
