using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Module05.PracticonLesson2
{
    public interface IDocument
    {
        void Open();
    }

    public class Report : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Report open!");
        }
    }
    public class Resume : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Resume open!");
        }
    }
    public class Letter : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Letter open!");
        }
    }


    public abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument();
    }

    public class ReportCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Report();
        }
    }
    public class ResumeCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Resume();
        }
    }
    public class LetterCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Letter();
        }
    }

    public enum DocType
    {
        Report, Resume, Letter
    }

    internal class Program
    {
        public static IDocument GetDocument(DocType type)
        {
            DocumentCreator creator = null;
            IDocument document = null;

            switch (type)
            {
                case DocType.Report:
                    creator = new ReportCreator();                    
                    break;
                case DocType.Resume:
                    creator = new ResumeCreator();
                    break;
                case DocType.Letter:
                    creator = new LetterCreator();
                    break;
            }
            document = creator.CreateDocument();
            return document;
        }
        static void Main(string[] args)
        {
            GetDocument(DocType.Report).Open();
        }
    }
}
