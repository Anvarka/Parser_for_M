using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace AntlrWorkout
{
    public class Program
    {
        public static void main()
        {
            var filename = Console.ReadLine();
            var stream = new AntlrFileStream(filename);

            ExampleLexer exampleLexer = new ExampleLexer(stream);
            CommonTokenStream tokens = new CommonTokenStream(exampleLexer);
            tokens.Fill();

            ExampleParser exampleParser = new ExampleParser(tokens);
            exampleParser.ErrorHandler = new MyGrammarErrorStrategy();


            IParseTree impl = exampleParser.programm();

            Console.Out.WriteLine(impl.ToStringTree(exampleParser));

            // abc = 1 + (2 + v)
            // Lexer: VAR EQ NUMBER PLUS OPEN NUMBER PLUS VAR CLOSE
            // Parser: stmt -> VAR EQ expr
        }
    }

    internal class MyGrammarErrorStrategy : DefaultErrorStrategy
    {
        // public override void Recover(Parser recognizer, RecognitionException e)
        // {
        //     base.Recover(recognizer, e);
        //
        //     ITokenStream tokenStream = (ITokenStream) recognizer.InputStream;
        //
        //     // Verify we are where we expect to be
        //     if (tokenStream.LA(1) == ExampleParser.Eof)
        //     {
        //         // Get the next possible tokens
        //         IntervalSet intervalSet = GetErrorRecoverySet(recognizer);
        //
        //         // Move to the next token
        //         tokenStream.Consume();
        //         
        //         ConsumeUntil(recognizer, intervalSet);
        //     }
        // }

        public override void Sync(Parser recognizer)
        {
        }

        protected override void ReportNoViableAlternative(Parser parser, NoViableAltException e)
        {
            String msg = "can't choose between alternatives";
            parser.NotifyErrorListeners(e.OffendingToken, msg, e);
        }
    }
}