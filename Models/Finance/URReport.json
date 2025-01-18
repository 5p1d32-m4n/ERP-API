using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ERP_API.Models.BusinessResources;

namespace ERP_API.Models.Finance
{
	public class URReport
	{
        #region PDF Export
        public static byte[] GetPDF(IWebHostEnvironment host, List<BusinessResource> resources)
        {
            var document = Document.Create(doc =>
            {
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";

                string warningColor = "#FEB018";
                string goodColor = "#01E396";

                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());

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
                                col.Item().AlignRight().Text("UR Report").FontSize(14).Bold();
                            });
                        });
                    });

                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(30);  
                                cols.ConstantColumn(40); 
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                            });
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(30);
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignLeft().AlignBottom().Padding(2).Text("#").FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignLeft().AlignBottom().Padding(2).Text("Resource").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignLeft().AlignBottom().Padding(2).Text("Position").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Projects Qty").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Others Hrs").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Project Hrs").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Total Hrs").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("UR %").FontColor(secondaryColor).FontSize(8);
                            });

                            int counter = 1;
                            var cellBgColor = "";

                            var urAverage  = (resources.Sum(r=>r.ProjectHours) / resources.Sum(r=>r.TotalHrs) * 100).ToString("#.##");

                            for (int i = 0; i < resources.Count(); i++)
                            {
                                var resource = resources[i];
                                if(resource.URPercent >= .8){cellBgColor = goodColor;}
                                if(resource.URPercent >= .7 && resource.URPercent < .8){cellBgColor = warningColor;}
                                if(resource.URPercent < .7){cellBgColor = dangerColor;}
                                
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(counter++.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.Fullname).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.JobTitle).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.ProjectPayCodeCount.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", resource.OtherHours)).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", resource.ProjectHours)).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", resource.TotalHrs)).FontSize(8);
                                table.Cell().Background(cellBgColor).BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resource.URPercent.ToString("P2")).FontSize(8);
                            }

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text("").FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", resources.Sum(r=>r.OtherHours))).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", resources.Sum(r=>r.ProjectHours))).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", resources.Sum(r=>r.TotalHrs))).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(urAverage).FontColor(dangerColor).FontSize(7);
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
        
        #endregion


        #region Excel Export
        public static MemoryStream GetExcel(List<BusinessResource> resources)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("UR Report");

                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                
                string warningColor = "#FEB018";
                string goodColor = "#01E396";

                worksheet.Cells[1, 1].Value = "Resources UR Report";
                worksheet.Cells[1, 1, 1, 8].Merge = true;
                worksheet.Cells[1, 1, 1, 8].Style.Font.Size = 14;
                worksheet.Cells[1, 1, 1, 8].Style.Font.Bold = true;
                worksheet.Cells[1, 1, 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1, 1, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(secondaryColor));
                worksheet.Cells[1, 1, 1, 8].Style.Font.Color.SetColor(System.Drawing.Color.White);

                worksheet.Cells[2, 1].Value = "Generated at: " + DateTime.Now.ToString();
                worksheet.Cells[2, 1, 2, 8].Merge = true;
                worksheet.Cells[2, 1, 2, 8].Style.Font.Size = 10;
                worksheet.Cells[2, 1, 2, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[3, 1].Value = "#";
                worksheet.Cells[3, 2].Value = "Resource";
                worksheet.Cells[3, 3].Value = "Position";
                worksheet.Cells[3, 4].Value = "Projects Qty";
                worksheet.Cells[3, 5].Value = "Other Hours";
                worksheet.Cells[3, 6].Value = "Project Hours";
                worksheet.Cells[3, 7].Value = "Total Hours";
                worksheet.Cells[3, 8].Value = "UR%";

                worksheet.Cells[3, 1, 3, 8].Style.Font.Bold = true;
                worksheet.Cells[3, 1, 3, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[3, 1, 3, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(secondaryColor));
                worksheet.Cells[3, 1, 3, 8].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[3, 1, 3, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                int row = 4;
                int counter = 1;

                foreach (var resource in resources)
                {
                    worksheet.Cells[row, 1].Value = counter++;
                    worksheet.Cells[row, 2].Value = resource.Fullname;
                    worksheet.Cells[row, 3].Value = resource.JobTitle;
                    worksheet.Cells[row, 4].Value = resource.ProjectPayCodeCount;
                    worksheet.Cells[row, 5].Value = string.Format("{0:F2}", resource.OtherHours);
                    worksheet.Cells[row, 6].Value = string.Format("{0:F2}", resource.ProjectHours);
                    worksheet.Cells[row, 7].Value = string.Format("{0:F2}", resource.TotalHrs);
                    worksheet.Cells[row, 8].Value = resource.URPercent.ToString("P2"); 

                    row++;
                }

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }
            return stream;
        }

        #endregion

    }
}
