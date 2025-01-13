using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using STG_ERP.Models.BusinessResources;
using STG_ERP.Models.Projects.Projects;

namespace STG_ERP.Models.Finance
{
	public class WOHReport
	{
        #region PDF Export
        public static byte[] GetPDF(IWebHostEnvironment host, List<Project> projects)
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
                                col.Item().AlignRight().Text("Invoicing and WOH (Work on hand)").FontSize(14).Bold();
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
                                cols.ConstantColumn(25);
                                cols.ConstantColumn(50);
                                cols.RelativeColumn();
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(64);
                                cols.ConstantColumn(64);
                                cols.ConstantColumn(40);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignLeft().AlignBottom().Padding(2).Text("#").FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignLeft().AlignBottom().Padding(2).Text("Number").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignLeft().AlignBottom().Padding(2).Text("Project").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Budget").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Invoiced").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Balance").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Subconsultants").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Resources").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Overhead").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("AC").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Variance").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                    .AlignCenter().AlignBottom().Padding(2).Text("Profit %").FontColor(secondaryColor).FontSize(8);
                            });

                            int counter = 1;
                            var cellBgColor = "";
                            
                            for (int i = 0; i < projects.Count(); i++)
                            {
                                var project = projects[i];

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(counter++.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.Number).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.ProjectName).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.Total.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.EarnedValueInvoiced.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.InvoicedBalance.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.SubConsultantsCost.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.TimesheetsBareRateCost.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.OfficeOverheadCost.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.ActualCost.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.CostVarianceInvoiced.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(project.ProfitInvoicedPercent.ToString("P2")).FontSize(8);
                            }

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.Total).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.EarnedValueInvoiced).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.InvoicedBalance).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.SubConsultantsCost).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.TimesheetsBareRateCost).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.OfficeOverheadCost).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.ActualCost).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Sum(p=>p.CostVarianceInvoiced).ToString("C")).FontColor(dangerColor).FontSize(7);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(projects.Average(p=>p.ProfitInvoicedPercent).ToString("P2")).FontColor(dangerColor).FontSize(7);
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
        public static MemoryStream GetExcel(List<Project> projects)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("CPI & SPI Report");

                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";

                worksheet.Cells[1, 1].Value = "CPI and SPI Analysis Report";
                worksheet.Cells[1, 1, 1, 13].Merge = true;
                worksheet.Cells[1, 1, 1, 13].Style.Font.Size = 14;
                worksheet.Cells[1, 1, 1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 1, 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1, 1, 13].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(secondaryColor));
                worksheet.Cells[1, 1, 1, 13].Style.Font.Color.SetColor(System.Drawing.Color.White);

                worksheet.Cells[2, 1].Value = "Generated at: " + DateTime.Now.ToString();
                worksheet.Cells[2, 1, 2, 13].Merge = true;
                worksheet.Cells[2, 1, 2, 13].Style.Font.Size = 10;
                worksheet.Cells[2, 1, 2, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[3, 1].Value = "#";
                worksheet.Cells[3, 2].Value = "Number";
                worksheet.Cells[3, 3].Value = "Project";
                worksheet.Cells[3, 4].Value = "Budget";
                worksheet.Cells[3, 5].Value = "EV";
                worksheet.Cells[3, 6].Value = "AC";
                worksheet.Cells[3, 7].Value = "PV";
                worksheet.Cells[3, 8].Value = "Analysis";
                worksheet.Cells[3, 9].Value = "CPI";
                worksheet.Cells[3, 10].Value = "SPI";
                worksheet.Cells[3, 11].Value = "EAC";
                worksheet.Cells[3, 12].Value = "Surplus";
                worksheet.Cells[3, 13].Value = "%";

                worksheet.Cells[3, 1, 3, 13].Style.Font.Bold = true;
                worksheet.Cells[3, 1, 3, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[3, 1, 3, 13].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml(secondaryColor));
                worksheet.Cells[3, 1, 3, 13].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[3, 1, 3, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                int row = 4;
                int counter = 1;

                foreach (var project in projects)
                {
                    worksheet.Cells[row, 1].Value = counter++;
                    worksheet.Cells[row, 2].Value = project.Number;
                    worksheet.Cells[row, 3].Value = project.ProjectName;
                    worksheet.Cells[row, 4].Value = project.Total.ToString("C");
                    worksheet.Cells[row, 5].Value = project.EarnedValueInvoiced.ToString("C");
                    worksheet.Cells[row, 6].Value = project.ActualCost.ToString("C");
                    worksheet.Cells[row, 7].Value = project.PlannedValue.ToString("C");
                    worksheet.Cells[row, 8].Value = project.ProfitInvoicedAnalysis;
                    worksheet.Cells[row, 9].Value = project.CostPerformanceIndexInvoiced;
                    worksheet.Cells[row, 10].Value = project.SchedulePerformanceIndex;
                    worksheet.Cells[row, 11].Value = project.EstimateAtCompletionInvoiced;
                    worksheet.Cells[row, 12].Value = project.ProfitInvoiced;
                    worksheet.Cells[row, 13].Value = project.ProfitInvoicedPercent;

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
