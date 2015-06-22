using System;
using System.Collections.Generic;

namespace CrudeWorld
{
    public interface IInteraction
    {
        IEnumerable<ICreature> FirstGroup { get; }

        IEnumerable<ICreature> SecondGroup { get; }

        bool Execute();

        Func<IInteraction> NextStepOnSuccess { get; set; }

        Func<IInteraction> NextStepOnFail { get; set; }
    }
}