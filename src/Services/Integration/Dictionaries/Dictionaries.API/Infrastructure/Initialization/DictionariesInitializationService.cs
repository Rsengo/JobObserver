using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.API.Infrastructure.Initialization
{
    public class DictionariesInitializationService
    {
        private readonly string _zip;
        private readonly string _folder;

        public DictionariesInitializationService(string folder, string zip)
        {
            _zip = zip;
            _folder = folder;
        }

        public void Initialize()
        {
            ZipFile.ExtractToDirectory(_zip, _folder);


        }
    }
}
