using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace ERP_API.Models.ClientsVendors
{
	public class ClientReports
	{

		public static byte[] GetClientsListPDF(IWebHostEnvironment host, ClientVendorViewModel viewModel, string searchTerm)
		{
			var document = Document.Create(doc =>
			{
				string borderColor = "#B6B6B6";
				string primaryColor = "#303549";

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
							row.RelativeItem().AlignRight().Text("Client List Report").FontSize(14).Bold();
						});
					});

					page.Content().PaddingVertical(10).Column(col =>
					{
						col.Item().Table(table =>
						{
							table.ColumnsDefinition(cols =>
							{
								cols.ConstantColumn(50);
								cols.ConstantColumn(60);
								cols.ConstantColumn(200);
								cols.ConstantColumn(150);
								cols.RelativeColumn();
							});

							table.Header(header =>
							{
								header.Cell().Background(primaryColor).Padding(5).Text("ID").FontColor("#FFFFFF").FontSize(8);
								header.Cell().Background(primaryColor).Padding(5).Text("Image").FontColor("#FFFFFF").FontSize(8);
								header.Cell().Background(primaryColor).Padding(5).Text("Name & Specialty").FontColor("#FFFFFF").FontSize(8);
								header.Cell().Background(primaryColor).Padding(5).Text("Contact Info").FontColor("#FFFFFF").FontSize(8);
								header.Cell().Background(primaryColor).Padding(5).AlignCenter().Text("Status").FontColor("#FFFFFF").FontSize(8);
							});

							foreach (var client in viewModel.client)
							{
								if (string.IsNullOrEmpty(searchTerm) ||
									(client.Name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
									(client.ContactOne?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
									(client.ContactTwo?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
									(client.ClientVendorId?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false))
								{
									table.Cell().Padding(5).Text(client.Id.ToString()).FontSize(8);

									if (!string.IsNullOrEmpty(client.ImageName))
									{
										var imageUrl = Path.Combine(host.ContentRootPath, "uploads", "clientsVendors", "images", client.ImageName);
										if (File.Exists(imageUrl))
										{
											byte[] clientImage = File.ReadAllBytes(imageUrl);
											table.Cell().Padding(5).Image(clientImage);
										}
										else
										{
											table.Cell().Padding(5).Text("Image Not Found").FontSize(8);
										}
									}
									else
									{
										table.Cell().Padding(5).Text("No Image").FontSize(8);
									}

									table.Cell().Padding(5).Column(col =>
									{
										col.Item().Text(client.Name).Bold().FontSize(8);
										col.Item().Text("Specialty: " + client.Specialty).FontSize(8);
										col.Item().Text("Website: " + client.Website).FontSize(8);
									});

									table.Cell().Padding(5).Column(col =>
									{
										if(client.ContactOne != null)
											col.Item().Text("Contact One: " + client.ContactOne).FontSize(8);
										if (client.ContactOnePhone != null)
											col.Item().Text("Contact One Phone: " + client.ContactOnePhone).FontSize(8);
										if (client.ContactTwo != null)
											col.Item().Text("Contact Two: " + client.ContactTwo).FontSize(8);
										if (client.ContactTwoPhone != null)
											col.Item().Text("Contact Two Phone: " + client.ContactTwoPhone).FontSize(8);
                                        col.Item().Text("Email: " + client.Email).FontSize(8);
									});

									table.Cell().Padding(5).AlignCenter().Text(client.Active ? "Active" : "Inactive")
										.FontColor(client.Active ? "#28a745" : "#6c757d").FontSize(8);
								}
							}
						});
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


		public static MemoryStream GetClientsListExcel(ClientVendorViewModel viewModel, string clientType, string searchTerm)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add($"{clientType} List Report");

				worksheet.Cells[1, 1, 1, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells[1, 1, 1, 7].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells[1, 1, 1, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheet.Cells["A1"].Value = $"{clientType} List Report";
				worksheet.Cells["A1"].Style.Font.Size = 14;
				worksheet.Cells["A1"].Style.Font.Bold = true;
				worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));
				worksheet.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
				worksheet.Cells["A1:I1"].Merge = true;

				worksheet.Cells[2, 1].Value = "#";
				worksheet.Cells[2, 2].Value = "Client Name";
				worksheet.Cells[2, 3].Value = "Client Type";
				worksheet.Cells[2, 4].Value = "Status";
				worksheet.Cells[2, 5].Value = "Contact One";
				worksheet.Cells[2, 6].Value = "Contact One Phone";
				worksheet.Cells[2, 7].Value = "Contact Two";
				worksheet.Cells[2, 8].Value = "Contact Two Phone";
				worksheet.Cells[2, 9].Value = "Email";

				worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				worksheet.Cells[2, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				worksheet.Cells[2, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				worksheet.Cells[2, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

				var filteredClients = viewModel.client.AsEnumerable();

				if (!string.IsNullOrEmpty(searchTerm))
				{
					filteredClients = filteredClients.Where(c =>
						 (c.Name?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
						 (c.ContactOne?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
						 (c.ContactTwo?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
						 (c.ClientVendorId?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false));
				}

				int row = 3;
				int counter = 1;

				foreach (var client in filteredClients)
				{
					worksheet.Cells[row, 1].Value = counter++;
					worksheet.Cells[row, 2].Value = client.Name;
					worksheet.Cells[row, 3].Value = client.ClientType;
					worksheet.Cells[row, 4].Value = client.Active ? "Active" : "Inactive";
					worksheet.Cells[row, 5].Value = client.ContactOne;
                    worksheet.Cells[row, 6].Value = client.ContactOnePhone;
                    worksheet.Cells[row, 7].Value = client.ContactTwo;
                    worksheet.Cells[row, 8].Value = client.ContactTwoPhone;
                    worksheet.Cells[row, 9].Value = client.Email;
					
					worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					worksheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					row++;
				}

				worksheet.Cells.AutoFitColumns();
				worksheet.Column(1).Width = 4;
				package.Save();
			}

			stream.Position = 0;

			return stream;
		}


	}
}