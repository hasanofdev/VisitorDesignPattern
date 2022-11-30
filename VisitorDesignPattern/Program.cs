interface IVisitor
{
    public void visitElementA(ElementA element);
    public void visitElementB(ElementB element);
}

interface IElement
{
    public void Accept(IVisitor visitor);
}

class ElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.visitElementA(this);
    }

    public string FeatureA() =>"Element A";
}

class ElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.visitElementB(this);
    }

    public string FeatureB() =>"Element B";
}

class XMLConverter : IVisitor
{
    public void visitElementA(ElementA element)
    {
        Console.WriteLine(element.FeatureA() + " is converted to XML format!");
    }

    public void visitElementB(ElementB element)
    {
        Console.WriteLine(element.FeatureB() + " is converted to XML format!");
    }
}


class Program
{
    static void Main(string[] args)
    {
        IVisitor visitor = new XMLConverter();

        List<IElement> elements = new List<IElement>()
        {
            new ElementA(),
            new ElementB(),
        };

        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}

