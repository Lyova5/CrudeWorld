using System;
using System.Collections.Generic;

namespace CrudeWorld
{
    public abstract class InteractionBase : IInteraction
    {
        public IEnumerable<ICreature> FirstGroup { get; protected set; }
        public IEnumerable<ICreature> SecondGroup { get; protected set; }

        protected InteractionBase()
        {
        }

        public bool Execute()
        {
            IInteraction nextStep = null;
            bool result;
            if (ExecuteCore())
            {
                if (NextStepOnSuccess != null)
                    nextStep = NextStepOnSuccess();
                result = true;
            }
            else
            {
                if (NextStepOnFail != null)
                    nextStep = NextStepOnFail();
                result = false;
            }
            if (nextStep != null)
                result &= nextStep.Execute();
            return result;
        }

        protected abstract bool ExecuteCore();

        public Func<IInteraction> NextStepOnSuccess { get; set; }
        public Func<IInteraction> NextStepOnFail { get; set; }
    }
}