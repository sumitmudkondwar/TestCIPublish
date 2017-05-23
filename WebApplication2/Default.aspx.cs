using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting.Processing;
using Telerik.Reporting;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportProcessor reportProcessor = new ReportProcessor();

            // set any deviceInfo settings if necessary
            System.Collections.Hashtable deviceInfo = new System.Collections.Hashtable();

            Telerik.Reporting.TypeReportSource typeReportSource = new Telerik.Reporting.TypeReportSource();

            // reportName is the Assembly Qualified Name of the report
            typeReportSource.TypeName = "PDF";

            RenderingResult result = reportProcessor.RenderReport("PDF", typeReportSource, deviceInfo);

            string fileName = result.DocumentName + "." + result.Extension;
            string path = System.IO.Path.GetTempPath();
            string filePath = System.IO.Path.Combine(path, fileName);

            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
            
        }
    }
}