using System.ComponentModel.Composition;

namespace SimpleCalculator3.Extensions {

    [Export(typeof(SimpleCalculator3.IOperation))]
    [ExportMetadata("Symbol", '%')]
    public class Mod : SimpleCalculator3.IOperation
    {
        public int Operate(int left, int right)
        {
            return left % right;
        }
    }

}
