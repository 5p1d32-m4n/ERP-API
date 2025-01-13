using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace STG_ERP.Models.Projects.Projects

{
    public  class ProjectsReports
    {
        //Project - Detail
        public static byte[] GetProjectDetailPDF(IWebHostEnvironment host, Project project){
            return null;
            // var document = Document.Create(doc => {

            //     string dangerColor = "#E61E24";
			// 	string secondaryColor = "#303549";
			// 	string borderColor = "#B6B6B6";
            //     string grayColor = "#B6B6B6";

			// 	doc.Page(page =>
            //     {
            //         page.Margin(25);
            //         //page.Size(612f, 792f);
            //         //page.Size(792f, 612f);
            //         page.Size(PageSizes.Letter.Landscape());
            //         page.Header().ShowOnce().Column(col =>
            //         {
            //             col.Item().Row(row =>
            //             {
			// 				var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");
			// 				byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

			// 				row.ConstantItem(130).Image(imgData);
            //                 row.RelativeItem(1).Column(col =>
            //                 {
            //                     col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
            //                     col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
            //                     col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
            //                     col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
            //                 });

            //                 row.RelativeItem().Border(0).Column(col =>
            //                 {
            //                     col.Item().AlignRight().Text("SYSTEM REPORT").FontSize(14).Bold();
            //                 });
            //             });

            //         });

            //         page.Content().PaddingVertical(10).Column(col1 =>
            //         {
            //             col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

            //             col1.Item().Table(table =>
            //             {
            //                 table.ColumnsDefinition(cols =>
            //                 {
            //                     cols.ConstantColumn(30);
            //                     cols.ConstantColumn(300);
            //                     cols.ConstantColumn(20);
            //                     cols.RelativeColumn();
            //                 });

            //                 table.Cell().Row(1).Column(1).Text("Title :").Bold().FontSize(10);
            //                 table.Cell().Row(1).Column(2).Text($"Project Details Report").FontSize(10);
            //                 table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);

            //             });

            //             //Project
            //             col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
            //             col1.Item().Table(table =>
            //             {
            //                 table.ColumnsDefinition(cols =>
            //                 {
            //                     cols.ConstantColumn(56);
            //                     cols.RelativeColumn();
            //                 });

            //                 table.Cell().Row(1).Column(1).Text("Project #: ").FontSize(8);
            //                 table.Cell().Row(1).Column(2).Text(project.Number).FontSize(8).FontColor(dangerColor);
            //                 table.Cell().Row(2).Column(1).Text("Description: ").FontSize(8);
            //                 table.Cell().Row(2).Column(2).Text(project.Description).FontSize(8).FontColor(dangerColor);
            //                 table.Cell().Row(3).Column(1).Text("Client: ").FontSize(8);
            //                 table.Cell().Row(3).Column(2).Text(project.Client.Name).FontSize(8).FontColor(dangerColor);
            //                 table.Cell().Row(4).Column(1).Text("Service Type: ").FontSize(8);
            //                 table.Cell().Row(4).Column(2).Text(project.ServiceType.Name).FontSize(8).FontColor(dangerColor);
            //             });
            //             col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

            //             //Subconsultants
            //             col1.Item().Text("Section I. Project Deliverables").Bold().FontSize(8);
            //             col1.Item().Table(table =>
            //             {
            //                 table.ColumnsDefinition(cols =>
            //                 {
            //                     cols.RelativeColumn();
            //                     cols.RelativeColumn();
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                 });

            //                 table.Header(header =>
            //                 {
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Category").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Name").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Plan Start").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Plan End").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Due Date").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Progress").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("EV").FontColor(secondaryColor).FontSize(7);
            //                 });

            //                 var num = 1;
            //                 // foreach (var item in Enumerable.Range(1, 20))
            //                 foreach (var deliverable in project.Deliverables)
            //                 {
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.Category).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.Name).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.Cost.ToString("C2")).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.StartDate.ToString("MMM-dd-yyyy")).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.EndDate.ToString("MMM-dd-yyyy")).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.DueDate.ToString("MMM-dd-yyyy")).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.ProgressPercent.ToString("P2")).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.EarnedValue.ToString("C2")).FontSize(8);
            //                     num += 1;
            //                 }
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.Deliverables.Sum(d=>d.Cost).ToString("C2")).FontSize(7).FontColor(dangerColor);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.Deliverables.Sum(d=>d.EarnedValue).ToString("C2")).FontSize(7).FontColor(dangerColor);
            //             });

            //             //Deliverables
            //             col1.Item().Text("Section II. Project Subconsultants").Bold().FontSize(8);
            //             col1.Item().Table(table =>
            //             {
            //                 table.ColumnsDefinition(cols =>
            //                 {
            //                     cols.RelativeColumn();
            //                     cols.RelativeColumn();
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                 });

            //                 table.Header(header =>
            //                 {
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Deliverable").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Sub Consultant").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Date").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);
            //                 });

            //                 var num = 1;
            //                 //foreach (var item in Enumerable.Range(1, 20))
            //                 foreach (var subConsultant in project.SubConsultants)
            //                 {
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.DeliverableName).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.Name).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.Date?.ToString("MMM-dd-yyyy")).FontSize(8);
            //                     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.Cost.ToString("C2")).FontSize(8);
            //                     num += 1;
            //                 }
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.SubConsultants.Sum(s=>s.Cost).ToString("C2")).FontSize(7).FontColor(dangerColor);
            //             });

            //             //Resources
            //             col1.Item().Text("Section III. Resources Overview").Bold().FontSize(8);
            //             col1.Item().Table(table =>
            //             {
            //                 table.ColumnsDefinition(cols =>
            //                 {
            //                     cols.RelativeColumn();
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                     cols.ConstantColumn(60);
            //                 });

            //                 table.Header(header =>
            //                 {
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Name").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Pay Rate").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Hours").FontColor(secondaryColor).FontSize(7);
            //                     header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);
            //                 });

            //                 var num = 1;
            //                 //foreach (var item in Enumerable.Range(1, 20))
            //                 // foreach (var subConsultant in project.SubConsultants)
            //                 // {
            //                 //     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.DeliverableName).FontSize(8);
            //                 //     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.Cost.ToString("C2")).FontSize(8);
            //                 //     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.Name).FontSize(8);
            //                 //     table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(subConsultant.Cost.ToString("C2")).FontSize(8);
            //                 //     num += 1;
            //                 // }
            //                 // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
            //                 // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.SubConsultants.Sum(s=>s.Cost).ToString("C2")).FontSize(7).FontColor(dangerColor);
            //                 // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
            //                 // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(project.SubConsultants.Sum(s=>s.Cost).ToString("C2")).FontSize(7).FontColor(dangerColor);
            //             });

            //             //Spacing
            //             col1.Spacing(10);
            //         });

            //         page.Footer().AlignRight().Text(txt =>
            //         {
            //             txt.Span("Page ").FontSize(10);
            //             txt.CurrentPageNumber().FontSize(10);
            //             txt.Span(" of ").FontSize(10);
            //             txt.TotalPages().FontSize(10);
            //         });
            //     });
			// }).GeneratePdf();

			// return document;
        }
        public static MemoryStream GetProjectDetailExcel(Project project){
            var stream = new MemoryStream();
            
            using (var package = new ExcelPackage(stream)){
                var worksheet = package.Workbook.Worksheets.Add("Project Detail");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Project Detail";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "Name";
                worksheet.Cells[4, 2].Value = "Description";
                worksheet.Cells[4, 3].Value = "Brand";
                worksheet.Cells[4, 4].Value = "Model";
                worksheet.Cells[4, 5].Value = "Unit";
                worksheet.Cells[4, 6].Value = "Category";
                worksheet.Cells[4, 7].Value = "Storage";
                worksheet.Cells[4, 8].Value = "Cost";
                worksheet.Cells[4, 9].Value = "Min. Stock Level";
                worksheet.Cells[4, 10].Value = "Inventory";
                worksheet.Cells[4, 11].Value = "Notes";

                //worksheet.Cells["A4:G6"].Style.Font.Bold = true;
                worksheet.Cells["A4:K4"].Style.Font.Bold = true;
                worksheet.Cells["A4:K4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:K4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:K4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r=5;
                // foreach(var asset in model.Assets){
                //     worksheet.Cells[r, 1].Value = asset.Name;
                //     worksheet.Cells[r, 2].Value = asset.Description;
                //     worksheet.Cells[r, 3].Value = asset.Brand;
                //     worksheet.Cells[r, 4].Value = asset.Model;
                //     worksheet.Cells[r, 5].Value = asset.Unit;
                //     worksheet.Cells[r, 6].Value = asset.Category.Name;
                //     worksheet.Cells[r, 7].Value = asset.Storage;
                //     worksheet.Cells[r, 8].Value = asset.Cost.ToString("C");
                //     worksheet.Cells[r, 9].Value = asset.MinStockLevel.ToString();
                //     worksheet.Cells[r, 10].Value = asset.Inventory;
                //     worksheet.Cells[r, 11].Value = asset.Notes;
                //     r+=1;
                // }

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }
    }
}
