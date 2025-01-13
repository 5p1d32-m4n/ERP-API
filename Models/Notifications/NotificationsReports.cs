using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ERP_API.Models.Notifications;

namespace ERP_API.Models.Auth
{
	public class NotificationsReports
	{
		//Notifications - List
		public static MemoryStream GetNotificationsListExcel(NotificationsViewModel model)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var workbook = package.Workbook;

				// Add the new "List" worksheet
				var worksheet = workbook.Worksheets.Add("List");

				// Header
				worksheet.Cells[1, 1].Value = "Title:";
				worksheet.Cells[1, 2].Value = "STG - Notifications List Report";
				worksheet.Cells[2, 1].Value = "Generated at:";
				worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

				//worksheet.Cells[4, 1].Value = "#";
				//worksheet.Cells[4, 2].Value = "Email";
				worksheet.Cells[4, 1].Value = "Module";
				worksheet.Cells[4, 2].Value = "Title";
				worksheet.Cells[4, 3].Value = "Message";
				worksheet.Cells[4, 4].Value = "Priority";

				//Style of the	Cells
				worksheet.Cells["A4:E4"].Style.Font.Bold = true;
				worksheet.Cells["A4:E4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A4:E4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A4:E4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));
				worksheet.Cells["A4:E4"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

				worksheet.Cells["A1:A2"].Style.Font.Bold = true;
				worksheet.Cells["A1:A2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A1:A2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A1:A2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));
				worksheet.Cells["A1:A2"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

				worksheet.Cells["B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#F2F2F2"));
				worksheet.Cells["B2"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
				worksheet.Cells["B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["B1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
				worksheet.Cells["B1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

				//Data to show on the Table Cells
				var r = 5;
				var isGray = false;
				foreach (var notification in model.Notifications)
				{
					if (isGray)
					{
						worksheet.Cells[r, 1, r, 5].Style.Fill.PatternType = ExcelFillStyle.Solid; // Set the pattern type to Solid
						worksheet.Cells[r, 1, r, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#F2F2F2"));
						worksheet.Cells[r, 1, r, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin);
						isGray = false;
					}
					else
					{
						worksheet.Cells[r, 1, r, 5].Style.Fill.PatternType = ExcelFillStyle.Solid; // Set the pattern type to Solid
						worksheet.Cells[r, 1, r, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
						worksheet.Cells[r, 1, r, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin);
						isGray = true;
					}

					worksheet.Cells[r, 1].Value = notification.Module;
					worksheet.Cells[r, 2].Value = notification.Title;
					worksheet.Cells[r, 3].Value = notification.Message;
					worksheet.Cells[r, 4].Value = notification.LevelType;

					r += 1;
				}


				worksheet.Cells.AutoFitColumns();
				package.Save();
			}

			stream.Position = 0;
			return stream;
		}

		public static byte[] GetNotificationsListPDF(NotificationsViewModel model)
		{
			var document = Document.Create(doc =>
			{
				string secondaryColor = "#303549";
				string borderColor = "#B6B6B6";

				doc.Page(page =>
				{
					page.Margin(25);
					page.Size(PageSizes.Letter.Landscape());
					page.Header().ShowOnce().Column(col =>
					{
						col.Item().Row(row =>
						{
							var imgPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\logo.png");
							byte[] imgData = File.ReadAllBytes(imgPath);

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
							table.Cell().Row(1).Column(2).Text($"STG - Notifications List Report").FontSize(10);
							table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);

						});
						col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
						col1.Item().Table(table =>
						{
							table.ColumnsDefinition(cols =>
							{
								cols.RelativeColumn(100);
								cols.RelativeColumn(100);
							});

							//table.Cell().Row(1).Column(1).Text($"Total Work Orders: {wos.Count}").FontSize(8);
						});

						//Data To Show on the PDF
						col1.Item().AlignCenter().Table(table =>
						{
							table.ColumnsDefinition(cols =>
							{
								//cols.ConstantColumn(100);
								cols.ConstantColumn(100);
								cols.ConstantColumn(100);
								cols.ConstantColumn(150);
								cols.ConstantColumn(100);
								cols.ConstantColumn(60);

								//cols.RelativeColumn(00);
							});

							table.Header(header =>
							{
								//header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Email").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(5).Text("Module").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(5).Text("Title").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(5).Text("Message").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(5).Text("Date").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(5).Text("Priority").FontColor(secondaryColor).FontSize(7);
								//header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("").FontColor(secondaryColor).FontSize(7);
							});

							//Table Data
							var num = 1;
							foreach (var notification in model.Notifications)
							{
								//table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(10).Text(notification.UserEmail).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(15).Text(notification.Module).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(15).Text(notification.Title).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(15).Text(notification.Message).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(15).Text(notification.NotificationDate).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(15).Text(notification.LevelType).FontSize(8);
								//table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(12);
								//Concatenate roles into a single string separated by commas
								//string "" = string.Join(", ", applicationusers.Roles);
								//table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontSize(8);

								num += 1;
							}
						});

						col1.Spacing(15);
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
	}
}