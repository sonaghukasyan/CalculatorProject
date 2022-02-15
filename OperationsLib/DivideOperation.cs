namespace OperationsLib
{
    class DivideOperation : IOperation
    {

        public OpSign OpSign { get { return (OpSign)1; } set { } }

        public int Operate(int firstParam, int secondParam)
        {
            if (firstParam % secondParam != 0)
            {
                Operate((double)(firstParam), (double)(firstParam));
            }
            return firstParam / secondParam;
        }

        public double Operate(double firstParam, double secondParam)
        {
            return firstParam / secondParam;
        }

        public long Operate(long firstParam, long secondParam)
        {
            if (firstParam % secondParam != 0)
            {
                Operate((double)(firstParam), (double)(firstParam));
            }
            return firstParam / secondParam;
        }
    }
}
