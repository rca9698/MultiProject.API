using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Home.Command
{
    public class InsertDashboardImagesCommand
    {
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
        public string DisplayDate { get; set; }
    }
}
