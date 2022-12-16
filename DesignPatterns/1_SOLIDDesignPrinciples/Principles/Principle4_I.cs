namespace Section1_SOLIDDesignPrinciples.Principle4_I
{
    public class Document
    {

    }

    // This 'IMachine' class would violate the Interface Segregation Principle
    // Every single machine wouldn't implement all of its methods
    public interface IMachine
    {
        public void Print(Document d);
        public void Scan(Document d);
        public void Fax(Document d);
    }

    // This machine would have a need to implement every single method of 'IMachine'
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }
    }

    // This machine, however, wouldn't need to implement Scan and Fax
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }
    }


    // ---------------- A better example

    public interface IPrinter
    {
        public void Print(Document d);
    }

    public interface IScanner
    {
        public void Scan(Document d);
    }

    // A class that inherits from multiple interfaces, or...
    public class Photocopier : IPrinter, IScanner
    { 
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    // ... a class that inherits from an interface, and the interface inherits from multiple interfaces
    public interface IMultiFunctionDevice : IPrinter, IScanner
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer { get; set; }
        private IScanner scanner { get; set; }

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if ((printer != null) || (scanner != null))
            {
                this.printer = printer!;
                this.scanner = scanner!;
            }
            else
            {
                Exception exception = new Exception("One or more of the properties is null!");
                throw exception;
            }
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
}
