using System;
using System.IO;
using Microsoft.Reporting.NETCore;

namespace ReportViewerCore.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var report = new LocalReport();
			// Report.Load(report);
			Report.Test2(report);
			var pdf = report.Render("HTML5");
			File.WriteAllBytes("report.html", pdf);

			pdf = report.Render("EXCELOPENXML");
			File.WriteAllBytes("report.xlsx", pdf);
		}
	}
}
