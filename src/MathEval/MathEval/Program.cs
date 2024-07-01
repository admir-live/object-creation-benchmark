using Dumpify;

using org.matheval;

Expression expression = new("(a + b) / 2 ");

expression.Bind("a", 1);
expression.Bind("b", 2);

expression.SetRoundingMode(MidpointRounding.ToZero);

expression.Eval<double>().Dump();