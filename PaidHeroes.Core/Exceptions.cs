using System;
using System.Collections.Generic;
using System.Text;

namespace PaidHeroes.Core
{
    class StatPointOverflowError : Exception
    {
        public StatPointOverflowError() { }
    }

    class AbilityPointOverflowError : Exception
    {
        public AbilityPointOverflowError() { }
    }

    class StatOverflowError : Exception
    {
        public StatOverflowError() { }
    }
}
