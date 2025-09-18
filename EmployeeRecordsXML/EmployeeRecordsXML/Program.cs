using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

class Program
{
    static bool isValid = true;                  //track

    static void Main()
    {
        string xmlPath = "employees.xml";
        string xsdPath = "employees.xsd";

        //******* Validate XML ******
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add(null, xsdPath);
        settings.ValidationType = ValidationType.Schema; //use
        settings.ValidationEventHandler += (_, e) =>    //trigger,attach        
        {
            isValid = false;
            Console.WriteLine("Validation Error: " + e.Message);
        };

        using (XmlReader reader = XmlReader.Create(xmlPath, settings))
        {
            while (reader.Read()) { }    //read entire document node by node
        }

        if (!isValid)
        {
            Console.WriteLine("\nXML validation failed. Stopping program.");
            return;
        }

        Console.WriteLine("XML validated successfully!\n");

      
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlPath);
        XPathNavigator nav = doc.CreateNavigator();

        Console.WriteLine("Employees in IT Department:");
        foreach (XPathNavigator employee in nav.Select("//Employee[Department='IT']/Name"))
            Console.WriteLine(employee);

        Console.WriteLine("\nEmployees with Salary > 50000:");
        foreach (XPathNavigator employee in nav.Select("//Employee[Salary>50000]/Name"))
            Console.WriteLine(employee);

        Console.WriteLine("\nEmployees who joined after 01-01-2020:");
        DateTime cutoff = new DateTime(2020, 1, 1);
        foreach (XPathNavigator emp in nav.Select("//Employee"))
        {
            string dateStr = emp.SelectSingleNode("JoiningDate")?.Value;
            if (DateTime.TryParse(dateStr, out DateTime joinDate) && joinDate > cutoff)
            {
                Console.WriteLine(emp.SelectSingleNode("Name").Value);
            }
        }
    }
}