using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using NUnit.Framework;

namespace AntlrWorkout.Tests
{
    public class DeeperTest
    {
        [Test]
        public void Test()
        {
            var filename = "/home/anvar/RiderProjects/ConsoleApp3/ConsoleApp3/Tests/Test.txt";
            var stream = new AntlrFileStream(filename);

            ExampleLexer MLexer = new ExampleLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(MLexer);
            tokens.Fill();

            ExampleParser MParser = new ExampleParser(tokens);
            MParser.ErrorHandler = new MyGrammarErrorStrategy();


            IParseTree impl = MParser.programm();

            Console.Out.WriteLine(impl.ToStringTree(MParser));
            Assert.AreEqual("(programm { _REL_r1 = \\ (var_list x1 , (var_list x2 ," +
                            " (var_list x3))) . (target (target _REL_f1 ( (t_seq (term (var_list x4))) )) /\\ " +
                            "(target (term _CONS_cons1 ( (t_seq (term (var_list x0 , (var_list x1 , (var_list x2))))) ))" +
                            " == (term _CONS_cons2 ( (t_seq (term (var_list x0))) )))) ; } (target (target _REL_f1 ( (t_seq (term (var_list x4))) )) " +
                            "\\/ (target fresh{ (var_list x3 , (var_list x6)) })))", impl.ToStringTree(MParser));
        }
    }
}