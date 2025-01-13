using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace STG_ERP.Models.BusinessResources

{
    public  class BusinessResourcesReports
    {
        //List
        public static byte[] GetResourcesListPDF(IWebHostEnvironment host, BusinessResourceViewModel model){
            var document = Document.Create(doc => {

                string dangerColor = "#E61E24";
				string secondaryColor = "#303549";
				string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

				doc.Page(page =>
                {
                    page.Margin(25);
                    //page.Size(612f, 792f);
                    //page.Size(792f, 612f);
                    page.Size(PageSizes.Letter.Landscape());
                    page.Header().ShowOnce().Column(col =>
                    {
                        col.Item().Row(row =>
                        {
							var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");
							byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

							row.ConstantItem(130).Image(imgData);
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignRight().Text("SYSTEM REPORT").FontSize(14).Bold();
                            });
                        });

                    });

                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(30);
                                cols.ConstantColumn(300);
                                cols.ConstantColumn(20);
                                cols.RelativeColumn();
                            });

                            table.Cell().Row(1).Column(1).Text("Title:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"STG - Resources List Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);

                        });
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(90);
                                cols.RelativeColumn();
                            });
                        });


                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(30);
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.ConstantColumn(240);
                                cols.ConstantColumn(50);
                                cols.ConstantColumn(30);
                                cols.ConstantColumn(30);
                                cols.ConstantColumn(30);
                                cols.ConstantColumn(30);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Name").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Department").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Supervisor").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Position").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Lic #").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("PE").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("CIAPR").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("CAAP").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Resume").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                            // foreach (var item in Enumerable.Range(1, 20))
                            foreach (var resource in model.resources)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.Fullname).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.Department.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.SupervisorName).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.JobTitle).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.PELicenseNumber).FontSize(8);
                                table.Cell().Border(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.IsPE?"X":"").FontSize(8);
                                table.Cell().Border(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.CIAPRMemberCardFileName != null && resource.CIAPRMemberCardFileName.Length > 0 ?"X":"").FontSize(8);
                                table.Cell().Border(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.CAAPMemberCardFileName != null && resource.CAAPMemberCardFileName.Length > 0 ?"X":"").FontSize(8);
                                table.Cell().Border(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.ResumeFileName != null && resource.ResumeFileName.Length > 0 ?"X":"").FontSize(8);
                                num += 1;
                            }
                        });

                        col1.Spacing(10);
                    });

                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
			}).GeneratePdf();

			return document;
        }
        public static MemoryStream GetResourcesListExcel(BusinessResourceViewModel model){
            var stream = new MemoryStream();
            
            using (var package = new ExcelPackage(stream)){
                var worksheet = package.Workbook.Worksheets.Add("Resources List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Resources List Report";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "#";
                worksheet.Cells[4, 2].Value = "Name";
                worksheet.Cells[4, 3].Value = "Department";
                worksheet.Cells[4, 4].Value = "Supervisor";
                worksheet.Cells[4, 5].Value = "Position";
                worksheet.Cells[4, 6].Value = "Lic #";
                worksheet.Cells[4, 7].Value = "PE";
                worksheet.Cells[4, 8].Value = "CIAPR";
                worksheet.Cells[4, 9].Value = "CAAP";
                worksheet.Cells[4, 10].Value = "Resume";

                //worksheet.Cells["A4:G6"].Style.Font.Bold = true;
                worksheet.Cells["A4:K4"].Style.Font.Bold = true;
                worksheet.Cells["A4:K4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:K4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:K4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r=5;
                foreach(var resource in model.resources){
                    worksheet.Cells[r, 1].Value = r-4;
                    worksheet.Cells[r, 2].Value = resource.Fullname;
                    worksheet.Cells[r, 3].Value = resource.Department.Name;
                    worksheet.Cells[r, 4].Value = resource.SupervisorName;
                    worksheet.Cells[r, 5].Value = resource.JobTitle;
                    worksheet.Cells[r, 6].Value = resource.PELicenseNumber;
                    worksheet.Cells[r, 7].Value = resource.IsPE?"X":"";
                    worksheet.Cells[r, 8].Value = resource.CIAPRMemberCardFileName != null && resource.CIAPRMemberCardFileName.Length > 0 ?"X":"";
                    worksheet.Cells[r, 9].Value = resource.CAAPMemberCardFileName != null && resource.CAAPMemberCardFileName.Length > 0 ?"X":"";
                    worksheet.Cells[r, 10].Value = resource.ResumeFileName != null && resource.ResumeFileName.Length > 0 ?"X":"";
                    r+=1;
                }

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }
    }
}
