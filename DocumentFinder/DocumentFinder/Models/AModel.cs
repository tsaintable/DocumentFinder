using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentFinder.Models
{
    public class AModel
    {
        public DOCUMENT DOC { get; set; }
        public DOCUMENT_CONTENT D_CONTENT { get; set; }
        public DOCUMENT_DISTRIBUTION D_DISTRIB { get; set; }

        public IEnumerable<DOCUMENT> IE_DOC { get; set; }
        public IEnumerable<DOCUMENT_CONTENT> IE_D_CONTENT { get; set; }
        public IEnumerable<DOCUMENT_DISTRIBUTION> IE_D_DISTRIB { get; set; }
    }
}