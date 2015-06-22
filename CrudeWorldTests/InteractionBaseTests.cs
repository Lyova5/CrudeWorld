using CrudeWorld;
using NUnit.Framework;

namespace CrudeWorldTests
{
    [TestFixture]
    public class InteractionBaseTests
    {
        private class MockInteraction : InteractionBase
        {
            public bool Result { get; set; }

            protected override bool ExecuteCore()
            {
                return Result;
            }
        }

        [Test]
        public void ExecuteSuccessPipelineTest()
        {
            var x = new MockInteraction();

            bool flag = false;
            x.NextStepOnSuccess = () =>
            {
                flag = true;
                return null;
            };

            x.Result = true;
            x.Execute();
            Assert.IsTrue(flag);
        }

        [Test]
        public void ExecuteFailurePipelineTest()
        {
            var x = new MockInteraction();

            bool flag = false;
            x.NextStepOnFail = () =>
            {
                flag = true;
                return null;
            };

            x.Result = false;
            x.Execute();
            Assert.IsTrue(flag);
        }

        [Test]
        public void ExecutePipelineTest()
        {
            var x = new MockInteraction();

            bool flag = false;
            x.NextStepOnFail = () =>
            {
                return new MockInteraction
                {
                    NextStepOnSuccess = () =>
                    {
                        flag = true;
                        return null;
                    },
                    Result = true
                };
            };

            x.Result = false;
            x.Execute();
            Assert.IsTrue(flag);            
        }
    }
}