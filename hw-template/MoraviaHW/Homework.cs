﻿using System.Xml.Linq;
using Newtonsoft.Json;

namespace MoraviaHW;

class Doc
{
    public string Title { get; set; }
    public string Text { get; set; }
}

class Homework
{
    static void Task()
    {
        var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
        var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

        string input;

        try
        {
            FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
            var reader = new StreamReader(sourceStream);
            input = reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        var xdoc = XDocument.Parse(input);
        var doc = new Doc
        {
            Title = xdoc.Root.Element("title").Value,
            Text = xdoc.Root.Element("text").Value
        };

        var serializedDoc = JsonConvert.SerializeObject(doc);

        var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
        var sw = new StreamWriter(targetStream);
        sw.Write(serializedDoc);


    }
}