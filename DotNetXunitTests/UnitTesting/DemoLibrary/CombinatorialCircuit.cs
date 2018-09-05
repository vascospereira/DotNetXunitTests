using DemoLibrary.Models;
using System.Collections.Generic;

namespace DemoLibrary
{
    public class CombinatorialCircuit
    {
        private readonly Dictionary<string, LogicVariable> _lv = new Dictionary<string, LogicVariable>();

        public bool AddVariable(LogicVariable newLv)
        {
            LogicVariable lv;
            if (_lv.TryGetValue(newLv.Name, out lv)) return false;
            _lv.Add(newLv.Name, newLv);
            return true;
        }

        public LogicVariable GetLogicVariableByName(string lvName)
        {
            LogicVariable lv;
            _lv.TryGetValue(lvName, out lv);
            return lv;
        }
    }
}
