using MoraviaHW.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoraviaHW.Parser.StorageTypeEvaluators
{
    public class CloudStorageEvaluator : IStorageTypeEvaluator
    {
        public bool Evaluate(string filePath)
        {
            ArgumentCheck.IsNotNull(filePath, nameof(filePath));

            if (!Uri.IsWellFormedUriString(filePath, UriKind.Absolute))
            {
                return false;
            }

            Uri.TryCreate(filePath, UriKind.Absolute, out var uri);

            if (uri != null && uri.Scheme == "s3")
            {
                return true;
            }
            return false;
        }
    }
}
