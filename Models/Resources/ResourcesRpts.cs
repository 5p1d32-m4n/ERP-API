using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace ERP_API.Models.Resources
{
	public class ResourcesRpts
	{
		[Obsolete]
		public static byte[] GetResourceLstPDF(IWebHostEnvironment host, ResourcesViewModel model)
		{
			var document = Document.Create(doc =>
			{
				string dangerColor = "#E61E24";
				string secondaryColor = "#303549";
				string borderColor = "#B6B6B6";

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
							table.Cell().Row(1).Column(2).Text($"STG - Users List Report").FontSize(10);
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
								cols.ConstantColumn(60);
								cols.ConstantColumn(60);
								cols.ConstantColumn(150);
								cols.ConstantColumn(60);
								cols.ConstantColumn(60);
								cols.ConstantColumn(175);
								cols.ConstantColumn(75);
								cols.ConstantColumn(75);
							});

							table.Header(header =>
							{
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Status").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Employee Number").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("FLSA").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Email").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Phone Number").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Hired Date").FontColor(secondaryColor).FontSize(7);
							});

							var num = 1;
							foreach (var rcs in model.Resources)
							{
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rcs.Id).FontSize(8);
								if(rcs.Active == true)
									table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Active").FontSize(8);
								else
									table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("InActive").FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rcs.GetFullName()).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rcs.EmployeeNum).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rcs.FLSA).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rcs.Email).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rcs.PrimaryPhone).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", rcs.HireDate)).FontSize(8);
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

		public static MemoryStream GetResourceLstExcel(ResourcesViewModel model)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add("Users List");

				// Header
				worksheet.Cells[1, 1].Value = "Title:";
				worksheet.Cells[1, 2].Value = "STG - Resource List Report";
				worksheet.Cells[2, 1].Value = "Generated at:";
				worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheet.Cells["A1:B2"].Style.Font.Bold = true;
				worksheet.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheet.Cells[4, 1].Value = "Id #";
				worksheet.Cells[4, 2].Value = "Status";
				worksheet.Cells[4, 3].Value = "Full Name";
				worksheet.Cells[4, 4].Value = "Employee Number";
				worksheet.Cells[4, 5].Value = "FLSA";
				worksheet.Cells[4, 6].Value = "Email";
				worksheet.Cells[4, 7].Value = "Primary Phone";
				worksheet.Cells[4, 8].Value = "Hired Date";

				worksheet.Cells["A4:H4"].Style.Font.Bold = true;
				worksheet.Cells["A4:H4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A4:H4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A4:H4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				var r = 5;
				foreach (var rsc in model.Resources)
				{
					worksheet.Cells[r, 1].Value = rsc.Id;
					if(rsc.Active == true)
						worksheet.Cells[r, 2].Value = "Active";
					else
						worksheet.Cells[r, 2].Value = "InActive";
					worksheet.Cells[r, 3].Value = rsc.GetFullName();
					worksheet.Cells[r, 4].Value = rsc.Email;
					worksheet.Cells[r, 5].Value = rsc.EmployeeNum;
					worksheet.Cells[r, 6].Value = rsc.FLSA;
					worksheet.Cells[r, 7].Value = rsc.PrimaryPhone;
					worksheet.Cells[r, 8].Value = rsc.HireDate;

					r += 1;
				}

				worksheet.Cells.AutoFitColumns();
				package.Save();
			}

			return stream;
		}
	}
}
