using DemoLibrary.Models;
using Xunit;

namespace DemoLibrary.Tests
{
    public class CombinatorialCircuitTest
    {
        [Fact]
        public void AddVariable_ShouldAddName()
        {
            CombinatorialCircuit c = new CombinatorialCircuit();
            LogicVariable a = new LogicVariable { Name = "x1" };

            bool result = c.AddVariable(a);
            Assert.True(result, "Should add variable name.");
        }

        [Fact]
        public void AddVariable_ShouldFailAddDuplicateName()
        {
            CombinatorialCircuit c = new CombinatorialCircuit();
            LogicVariable a = new LogicVariable { Name = "x2" };
            LogicVariable b = new LogicVariable { Name = "x2" };

            c.AddVariable(a);
            bool result = c.AddVariable(b);
            Assert.False(result, "Should fail add duplicate variable name.");
        }

        [Fact]
        public void GetLogicVariableByName_ShouldGetSameLogicVariable()
        {
            // We can use 'var' as an implicit type letting the compiler
            // determines and assign the most appropriate type
            var c = new CombinatorialCircuit();
            var a = new LogicVariable { Name = "x1" };

            c.AddVariable(a);
            Assert.Same(a, c.GetLogicVariableByName("x1"));
        }

        [Fact]
        public void GetLogicVariableByName_ShouldGetNullLogicVariable()
        {
            var c = new CombinatorialCircuit();
            Assert.Null(c.GetLogicVariableByName("x1"));
        }

        [Fact]
        public void Set_LogicVariableShouldReturnTrue()
        {
            var lv = new LogicVariable { Value = true };
            Assert.True(lv.Value);
        }
    }
}
