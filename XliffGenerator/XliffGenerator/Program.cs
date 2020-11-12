using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace TranslatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TranslUnit values1 = new TranslUnit("Constructing", "En construction");
            var type = values1.GetType();
            var properties = type.GetProperties();

            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode xliffNode = doc.CreateElement("xliff");
            XmlAttribute xliffAttribute = doc.CreateAttribute("version");
            xliffAttribute.Value = "1.2";
            xliffNode.Attributes.Append(xliffAttribute);
            XmlAttribute xmlnsAttribute = doc.CreateAttribute("xmlns");
            xmlnsAttribute.Value = "urn:oasis:names:tc:xliff:document:1.2";
            xliffNode.Attributes.Append(xmlnsAttribute);
            doc.AppendChild(xliffNode);

            XmlNode fileNode = doc.CreateElement("file");
            XmlAttribute fileNodeAttribute = doc.CreateAttribute("source-language");
            fileNodeAttribute.Value = "en-US";
            XmlAttribute dataTypeAttribute = doc.CreateAttribute("datatype");
            dataTypeAttribute.Value = "plaintext";
            XmlAttribute original = doc.CreateAttribute("original");
            original.Value = "ng2.template";
            fileNode.Attributes.Append(fileNodeAttribute);
            fileNode.Attributes.Append(dataTypeAttribute);
            fileNode.Attributes.Append(original);
            xliffNode.AppendChild(fileNode);

            XmlNode bodyNode = doc.CreateElement("body");
            xliffNode.AppendChild(bodyNode);

            XmlNode TransUnitNode = doc.CreateElement("trans-unit");
            XmlAttribute idTransAttribute = doc.CreateAttribute("id");
            idTransAttribute.Value = "constructionHeader";
            TransUnitNode.Attributes.Append(idTransAttribute);
            XmlAttribute TransDataAttribute = doc.CreateAttribute("datatype");
            TransDataAttribute.Value = "html";
            TransUnitNode.Attributes.Append(TransDataAttribute);
            xliffNode.AppendChild(TransUnitNode);
            bodyNode.AppendChild(TransUnitNode);

            XmlNode sourceNode = doc.CreateElement("source");
            sourceNode.AppendChild(doc.CreateTextNode("Under Construction!"));
            TransUnitNode.AppendChild(sourceNode);

            XmlNode targetNode = doc.CreateElement("target");
            targetNode.AppendChild(doc.CreateTextNode("En Construction!"));
            TransUnitNode.AppendChild(targetNode);


            XmlNode contextNode = doc.CreateElement("context-group");
            XmlAttribute contextGroupAttribute = doc.CreateAttribute("purpose");
            contextGroupAttribute.Value = "location";
            contextNode.Attributes.Append(contextGroupAttribute);
            TransUnitNode.AppendChild(contextNode);

            XmlNode contextsNode = doc.CreateElement("context");
            contextsNode.AppendChild(doc.CreateTextNode("src/app/app.component.html"));
            XmlAttribute contextsAttribute = doc.CreateAttribute("context-type");
            contextsAttribute.Value = "sourcefile";
            contextsNode.Attributes.Append(contextsAttribute);
            contextNode.AppendChild(contextsNode);

            XmlNode noteNode = doc.CreateElement("note");
            XmlAttribute notePriorityAttribute = doc.CreateAttribute("priority");
            notePriorityAttribute.Value = "1";
            noteNode.Attributes.Append(notePriorityAttribute);
            XmlAttribute noteFromAttribute = doc.CreateAttribute("from");
            noteFromAttribute.Value = "description";
            noteNode.Attributes.Append(noteFromAttribute);
            noteNode.AppendChild(doc.CreateTextNode("Card header │ Title for the under construction"));
            TransUnitNode.AppendChild(noteNode);


            doc.Save(@"C:\Users\giova\Desktop\filetest.fr.xlf");

            foreach (var property in properties)
            {
                //Tratamento do dado
                sourceNode.InnerText = property.GetValue(values1, null).ToString();
                Console.WriteLine(sourceNode.InnerText);
            }
        }
    }
}

