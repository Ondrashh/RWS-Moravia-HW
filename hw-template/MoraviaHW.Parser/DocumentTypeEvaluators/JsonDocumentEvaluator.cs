﻿using MoraviaHW.Parser.Interfaces;

namespace MoraviaHW.Parser.DocumentTypeEvaluators;

public class JsonDocumentEvaluator : IDocumentTypeEvaluator
{
    /// <inheritdoc />
    public bool Evaluate(string filePath)
    {
        ArgumentCheck.IsNotNullOrEmpty(filePath, nameof(filePath));
        if (Path.GetExtension(filePath) == ".json")
        {
            return true;
        }
        return false;        
    }
}