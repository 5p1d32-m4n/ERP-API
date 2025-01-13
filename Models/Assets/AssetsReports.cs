using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace STG_ERP.Models.Assets

{
    public  class AssetsReports
    {

        //Assets - List
        public static byte[] GetAssetsListPDF(IWebHostEnvironment host, AssetsViewModel model){
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
                            table.Cell().Row(1).Column(2).Text($"STG - Assets List Report").FontSize(10);
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
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(120);
                                cols.ConstantColumn(50);
                                cols.ConstantColumn(50);
                                cols.ConstantColumn(50);
                                cols.ConstantColumn(50);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Name").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Description").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Brand").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Model").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Unit").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Category").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Storage").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Min Level").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Inventory").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                            // foreach (var item in Enumerable.Range(1, 20))
                            foreach (var asset in model.Assets)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Description).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Brand).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Model).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Unit).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Category.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(asset.Storage).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(asset.Cost.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(asset.MinStockLevel.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(asset.Inventory.ToString()).FontSize(8);
                                num += 1;
                            }

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(model.Assets.Sum(a => a.Inventory).ToString()).FontColor(dangerColor).FontSize(7);
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
        public static MemoryStream GetAssetsListExcel(AssetsViewModel model){
            var stream = new MemoryStream();
            
            using (var package = new ExcelPackage(stream)){
                var worksheet = package.Workbook.Worksheets.Add("Assets List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Assets List Report";
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
                foreach(var asset in model.Assets){
                    worksheet.Cells[r, 1].Value = asset.Name;
                    worksheet.Cells[r, 2].Value = asset.Description;
                    worksheet.Cells[r, 3].Value = asset.Brand;
                    worksheet.Cells[r, 4].Value = asset.Model;
                    worksheet.Cells[r, 5].Value = asset.Unit;
                    worksheet.Cells[r, 6].Value = asset.Category.Name;
                    worksheet.Cells[r, 7].Value = asset.Storage;
                    worksheet.Cells[r, 8].Value = asset.Cost.ToString("C");
                    worksheet.Cells[r, 9].Value = asset.MinStockLevel.ToString();
                    worksheet.Cells[r, 10].Value = asset.Inventory;
                    worksheet.Cells[r, 11].Value = asset.Notes;
                    r+=1;
                }

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }

        //Assets - Assets Log
        public static byte[] GetAssetsLogPDF(IWebHostEnvironment host, AssetsLogViewModel model){
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
                            table.Cell().Row(1).Column(2).Text($"STG - Assets Logs Report").FontSize(10);
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

                            //table.Cell().Row(1).Column(1).Text($"Total Work Orders: {wos.Count}").FontSize(8);
                        });


                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(120);
                                cols.RelativeColumn();
                                cols.RelativeColumn();
                                cols.ConstantColumn(60);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Date").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Resource").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Asset").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Qty").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                            // foreach (var item in Enumerable.Range(1, 20))
                            foreach (var log in model.AssetsLogs)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(log.DateCreated.ToString("MMM/dd/yyyy")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(log.ResourceName).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(log.AssetName).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(log.Qty.ToString()).FontSize(8);
                                num += 1;
                            }

                            // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(model.AssetsLogs.Sum(a => a.Qty).ToString()).FontColor(dangerColor).FontSize(7);
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
        public static MemoryStream GetAssetsLogExcel(AssetsLogViewModel model){
            var stream = new MemoryStream();
            
            using (var package = new ExcelPackage(stream)){
                var worksheet = package.Workbook.Worksheets.Add("Assets Logs");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Assets Logs Report";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "Date";
                worksheet.Cells[4, 2].Value = "Resource";
                worksheet.Cells[4, 3].Value = "Asset";
                worksheet.Cells[4, 4].Value = "Qty";

                //worksheet.Cells["A4:G6"].Style.Font.Bold = true;
                worksheet.Cells["A4:D4"].Style.Font.Bold = true;
                worksheet.Cells["A4:D4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:D4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:D4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r=5;
                foreach(var log in model.AssetsLogs){
                    worksheet.Cells[r, 1].Value = log.DateCreated.ToString("MMM/dd/yyyy");
                    worksheet.Cells[r, 2].Value = log.ResourceName;
                    worksheet.Cells[r, 3].Value = log.AssetName;
                    worksheet.Cells[r, 4].Value = log.Qty;
                    r+=1;
                }

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }

        //Assets - Transmittal 
        public static byte[] GetAssetTransmittalDocument(IWebHostEnvironment host, AssetTransmittal assetTransmittal) {
            var document = Document.Create(doc =>
            {
                string secondaryColor = "#2b3a4a";
                string borderColor = "#7E7C7D";

                doc.Page(page => {
                    page.Margin(25);

                    page.Header().ShowOnce().Column(col => {
                        col.Item().Row(row => {
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            row.ConstantItem(130).Image(imgData);

                            row.RelativeItem(1).Column(col => {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col => {
                                col.Item().AlignRight().Text("Project: STG-Main Sharetech Group Main").FontSize(9).Bold();
                                col.Item().AlignRight().Text("Physical: Road #1 Km 34.4, Plaza Bairoa Suite 215").FontSize(9);
                            });
                        });

                        col.Item().Row(row => {
                            row.RelativeItem().Border(0).Column(col => {
                                col.Item().AlignRight().Text("Postal: PO Box 1330").FontSize(9);
                                col.Item().AlignRight().Text("Caguas, Puerto Rico 00726-1330").FontSize(9);
                                col.Item().AlignRight().Text("Phone: 787-720-5869").FontSize(9);
                                col.Item().AlignRight().Text("Fax: 787-720-2318").FontSize(9);
                            });
                        });
                    });

                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().Column(col2 => {
                            col2.Item().PaddingVertical(4).LineHorizontal(0.5f).LineColor(borderColor);
                            col2.Item().AlignCenter().Text($"Transmittal #{assetTransmittal.Id} - Entrega de Equipo").FontSize(14).Bold();
                            col2.Item().PaddingVertical(4).LineHorizontal(0.5f).LineColor(borderColor);
                        });

                        col1.Item().Table(table => {
                            table.ColumnsDefinition(cols => {
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                                cols.ConstantColumn(30);
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                            });

                            table.Cell().Row(1).Column(1).Text("To").Bold().FontSize(9);
                            table.Cell().Row(1).Column(2).Text($"{assetTransmittal.ToName}").FontSize(9);
                            table.Cell().Row(1).Column(3).Text("").FontSize(9);
                            table.Cell().Row(1).Column(4).Text("From").Bold().FontSize(9);
                            table.Cell().Row(1).Column(5).Text($"{assetTransmittal.FromName}").FontSize(9);

                            table.Cell().Row(2).Column(1).Text("Date Created").Bold().FontSize(9);
                            table.Cell().Row(2).Column(2).Text($"{DateTime.Now.ToString("MMM/dd/yyyy")}").FontSize(9);
                            table.Cell().Row(2).Column(3).Text("").FontSize(9);
                            table.Cell().Row(2).Column(4).Text("Sent Via").Bold().FontSize(9);
                            table.Cell().Row(2).Column(5).Text($"{assetTransmittal.SentVia}").FontSize(9);

                            table.Cell().Row(3).Column(1).Text("Copies To").Bold().FontSize(9);
                            table.Cell().Row(3).Column(2).Text($"{assetTransmittal.CopiesTo}").FontSize(9);
                            table.Cell().Row(3).Column(3).Text("").FontSize(9);
                            table.Cell().Row(3).Column(4).Text("Action As Noted").Bold().FontSize(9);
                            table.Cell().Row(3).Column(5).Text("");

                            table.Cell().Row(4).Column(1).Text("Transmit").Bold().FontSize(9);
                            table.Cell().Row(4).Column(2).Text($"{assetTransmittal.Transmit}").FontSize(9);
                            table.Cell().Row(4).Column(3).Text("").FontSize(9);
                            table.Cell().Row(4).Column(4).Text("").Bold().FontSize(9);
                            table.Cell().Row(4).Column(5).Text("").FontSize(9);

                            table.Cell().Row(5).Column(1).Text("Submitted For").Bold().FontSize(9);
                            table.Cell().Row(5).Column(2).Text($"{assetTransmittal.SubmittedFor}").FontSize(9);
                            table.Cell().Row(5).Column(3).Text("").FontSize(9);
                            table.Cell().Row(5).Column(4).Text("").Bold().FontSize(9);
                            table.Cell().Row(5).Column(5).Text("").FontSize(9);

                        });

                        col1.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(borderColor);

                        col1.Item().Text("Transmittal Items").FontSize(12).Bold();

                        col1.Item().Table(table => {
                            table.ColumnsDefinition(cols => {
                                cols.ConstantColumn(110);
                                cols.RelativeColumn();
                                cols.ConstantColumn(50);
                                //cols.ConstantColumn(80);

                            });

                            table.Header(header => {
                                header.Cell().Background(Colors.Grey.Lighten3).Border(.5f).BorderColor(borderColor).Padding(2).Text("Category").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).Border(.5f).BorderColor(borderColor).Padding(2).Text("Description").Bold();
                                header.Cell().Background(Colors.Grey.Lighten3).Border(.55f).BorderColor(borderColor).AlignCenter().Padding(2).Text("Qty").Bold();
                                //header.Cell().Background(Colors.Grey.Lighten3).Border(.5f).BorderColor(borderColor).Padding(2).Text("Date").Bold();
                            });

                            if (assetTransmittal.AssetTransmittalItems != null) { 
                                foreach (var assetItem in assetTransmittal.AssetTransmittalItems)
                                {
                                    //var qty = Placeholders.Random.Next(1, 10);
                                    //var price = Placeholders.Random.Next(5, 15);
                                    //var total = qty * price;

                                    table.Cell().Border(0.5f).BorderColor(borderColor).Padding(2).Text(assetItem.AssetCategory).FontSize(10);
                                    table.Cell().Border(0.5f).BorderColor(borderColor).Padding(2).Text(assetItem.AssetName).FontSize(10);
                                    table.Cell().Border(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(assetItem.Qty.ToString()).FontSize(10);
                                    //table.Cell().Border(0.5f).BorderColor(borderColor).Padding(2).Text($"{assetTransmittal.DateCreated.ToString("MMM/dd/yyyy")}").FontSize(10);
                                }
                            }
                        });

                        col1.Item().Padding(3).Column(col => {
                            col.Item().Text("Comments").FontSize(12).Bold();
                            col.Item().Text("POLITICA DE EQUIPO ASIGNADO").FontSize(10).Bold();
                            col.Item().Text("1. STG suministra este equipo para uso exclusivamente del proyecto y trabajos de oficina.").FontSize(8);
                            col.Item().Text("2. El usuario recibe el equipo listo para su uso, y debera entregarlo en igual condicion.").FontSize(8);
                            col.Item().Text("3. Es responsabilidad del custodio del equipo almacenarlo, utilizarlo y manejarlo de torma segura, y en un ambiente adecuado.").FontSize(8);
                            col.Item().Text("4. No es permitido instalar, modificar y/o eliminar ningún programa en el equipo. Tampoco alterar alguna configuracion en su sistema.").FontSize(8);
                            col.Item().Text("5. En el caso de daños, y/o perdida del equipo prestado será responsabilidad del usuario reemolazarlo v/o pagarlo en su totalidad.").FontSize(8);
                            col.Item().Text("6. En caso de robo y/o accidente involuntario deberá notificarlo inmediatamente a su supervisor. En caso de robo hacer la querella correspondiente ante la Policía de Puerto Rico y completar los requerimientos establecidos. Esto no releva al solicitante bajo ningún concepto de la responsabilidad de reponer o pagar el equipo robado.").FontSize(8);
                            col.Item().PaddingTop(10).Text(text => {
                                text.Span("Yo ").FontSize(8);
                                text.Span($"{assetTransmittal.ToName}").FontSize(8).Underline();
                                text.Span(", al firmar este documento certifico que acepto la Política de Equipo Asignado (detallada arriba). Soy consciente de que durante el plazo que el equipo se me es asignado estará bajo mi responsabilidad. En el caso de que los mismos sufran alaun cano o nerdida sera mi responsabilidad reponerlo o pagarlo en su totalidad. He recibido el equipo:").FontSize(8);
                            });
                            col.Item().PaddingTop(10).Text(text =>
                            {
                                text.Span("Firma de usuario ").FontSize(8);
                                text.Span("                                                                                                    ").FontSize(8).Underline();

                            });
                            col.Item().PaddingTop(10).Text(text =>
                            {
                                text.Span("Fecha ").FontSize(8);
                                text.Span("                                                                                                    ").FontSize(8).Underline();

                            });
                        });

                        col1.Spacing(10);
                    });

                    page.Footer().AlignRight().Text(txt => {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            }).GeneratePdf();
            return document;
        }

    }
}
