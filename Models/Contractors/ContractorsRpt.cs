using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using System.Data.Common;
using System.Drawing;

namespace ERP_API.Models.Contractors
{
	public class ContractorsRpts
	{
		[Obsolete]
		public static byte[] GetContractorsLstPDF(IWebHostEnvironment host, IConfiguration configuration, ContractorsViewModel model)
		{
			var document = QuestPDF.Fluent.Document.Create(doc =>
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
							table.Cell().Row(1).Column(2).Text($"STG - Contractors List Report").FontSize(10);
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
								cols.ConstantColumn(60);
								cols.ConstantColumn(185);
								cols.ConstantColumn(75);
							});

							table.Header(header =>
							{
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Status").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("SSN_EIN").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Contract Since").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("InActive Date").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Email").FontColor(secondaryColor).FontSize(7);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Phone Number").FontColor(secondaryColor).FontSize(7);
							});

							var num = 1;
							foreach (var con in model.Contractors)
							{
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.Id).FontSize(8);
								if (con.Active == true)
									table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Active").FontSize(8);
								else
									table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("InActive").FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.GetFullName()).FontSize(8);

								var encryption = configuration.GetSection("Encryption");
								string _key = encryption["key"];
								var EncryptionService = new EncryptionService(_key);
								con.SSN_EIN = EncryptionService.Decrypt(con.SSN_EIN);

								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.SSN_EIN).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ContractorSince)).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.InactiveDate)).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.Email).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.PrimaryPhone).FontSize(8);
								
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

		public static MemoryStream GetContractorsLstExcel(IConfiguration configuration, ContractorsViewModel model)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add("Contractors List");

				worksheet.Cells[1, 1].Value = "Title:";
				worksheet.Cells[1, 2].Value = "STG - Contractors Report";
				worksheet.Cells[2, 1].Value = "Generated at:";
				worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheet.Cells["A1:B2"].Style.Font.Bold = true;
				worksheet.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheet.Cells[4, 1].Value = "Id #";
				worksheet.Cells[4, 2].Value = "Status";
				worksheet.Cells[4, 3].Value = "ImageName";
				worksheet.Cells[4, 4].Value = "Full Name";
				worksheet.Cells[4, 5].Value = "SSN EIN";
				worksheet.Cells[4, 6].Value = "Company Name";
				worksheet.Cells[4, 7].Value = "Contractor Since";
				worksheet.Cells[4, 8].Value = "InactiveDate";
				worksheet.Cells[4, 9].Value = "Email";
				worksheet.Cells[4, 10].Value = "Primary Phone";
				worksheet.Cells[4, 11].Value = "Secondary Phone";
				worksheet.Cells[4, 12].Value = "Emergency Contact Name";
				worksheet.Cells[4, 13].Value = "Emergency Contact Relationship";
				worksheet.Cells[4, 14].Value = "Emergency Contact Phone";
				worksheet.Cells[4, 15].Value = "PostalAddressLine1";
				worksheet.Cells[4, 16].Value = "PostalAddressLine2";
				worksheet.Cells[4, 17].Value = "PostalState";
				worksheet.Cells[4, 18].Value = "PostalTown";
				worksheet.Cells[4, 19].Value = "PostalZipcode";
				worksheet.Cells[4, 20].Value = "PhysicalAddressLine1";
				worksheet.Cells[4, 21].Value = "PhysicalAddressLine2";
				worksheet.Cells[4, 22].Value = "PhysicalState";
				worksheet.Cells[4, 23].Value = "PhysicalTown";
				worksheet.Cells[4, 24].Value = "PhysicalZipcode";
				worksheet.Cells[4, 25].Value = "CreatedDate";
				worksheet.Cells[4, 26].Value = "CreatedBy";
				worksheet.Cells[4, 27].Value = "ModifiedDate";
				worksheet.Cells[4, 28].Value = "ModifiedBy";

				worksheet.Cells["A4:AB4"].Style.Font.Bold = true;
				worksheet.Cells["A4:AB4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A4:AB4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A4:AB4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				var r = 5;
				foreach (var con in model.Contractors)
				{
					worksheet.Cells[r, 1].Value = con.Id;
					if (con.Active == true)
						worksheet.Cells[r, 2].Value = "Active";
					else
						worksheet.Cells[r, 2].Value = "InActive";
					worksheet.Cells[r, 3].Value = con.ImageName;
					worksheet.Cells[r, 4].Value = con.GetFullName();

					var encryption = configuration.GetSection("Encryption");
					string _key = encryption["key"];
					var EncryptionService = new EncryptionService(_key);
					con.SSN_EIN = EncryptionService.Decrypt(con.SSN_EIN);

					worksheet.Cells[r, 5].Value = con.SSN_EIN;
					worksheet.Cells[r, 6].Value = con.CompanyName;
					worksheet.Cells[r, 7].Value = string.Format("{0:MM/dd/yyyy}", con.ContractorSince);
					worksheet.Cells[r, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 8].Value = string.Format("{0:MM/dd/yyyy}", con.InactiveDate);
					worksheet.Cells[r, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 9].Value = con.Email;
                    worksheet.Cells[r, 10].Value = con.PrimaryPhone;
					worksheet.Cells[r, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 11].Value = con.SecondaryPhone;
					worksheet.Cells[r, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 12].Value = con.EmergencyContactName;
					worksheet.Cells[r, 13].Value = con.EmergencyContactRelationship;
					worksheet.Cells[r, 14].Value = con.EmergencyContactPhone;
					worksheet.Cells[r, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 15].Value = con.PostalAddressLine1;
					worksheet.Cells[r, 16].Value = con.PostalAddressLine2;
					worksheet.Cells[r, 17].Value = con.PostalState;
					worksheet.Cells[r, 18].Value = con.PostalTown;
					worksheet.Cells[r, 19].Value = con.PostalZipcode;
					worksheet.Cells[r, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 20].Value = con.PhysicalAddressLine1;
					worksheet.Cells[r, 21].Value = con.PhysicalAddressLine2;
					worksheet.Cells[r, 22].Value = con.PhysicalState;
					worksheet.Cells[r, 23].Value = con.PhysicalTown;
					worksheet.Cells[r, 24].Value = con.PhysicalZipcode;
					worksheet.Cells[r, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 25].Value = string.Format("{0:MM/dd/yyyy}", con.CreatedDate);
					worksheet.Cells[r, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 26].Value = con.CreatedBy;
					worksheet.Cells[r, 27].Value = string.Format("{0:MM/dd/yyyy}", con.ModifiedDate);
					worksheet.Cells[r, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheet.Cells[r, 28].Value = con.ModifiedBy;
					r += 1;
				}
				worksheet.Cells.AutoFitColumns();

				var worksheetCh = package.Workbook.Worksheets.Add("History");
				worksheetCh.Cells[1, 1].Value = "Title:";
				worksheetCh.Cells[1, 2].Value = "STG - Contractors History Data";
				worksheetCh.Cells[2, 1].Value = "Generated at:";
				worksheetCh.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetCh.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetCh.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetCh.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetCh.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetCh.Cells[4, 1].Value = "Contractors Id";
				worksheetCh.Cells[4, 2].Value = "Full Name";
				worksheetCh.Cells[4, 3].Value = "Position";
				worksheetCh.Cells[4, 4].Value = "Start Date";
				worksheetCh.Cells[4, 5].Value = "End Date";
				worksheetCh.Cells[4, 6].Value = "Rate";
				worksheetCh.Cells[4, 7].Value = "Client Site Project";
				worksheetCh.Cells[4, 8].Value = "Reporting To";

				var hr = 5;
				foreach (var hty in model.Historys)
				{
					worksheetCh.Cells[hr, 1].Value = hty.ContractorId;
					worksheetCh.Cells[hr, 2].Value = hty.FullName;
					worksheetCh.Cells[hr, 3].Value = hty.Position;
					worksheetCh.Cells[hr, 4].Value = string.Format("{0:MM/dd/yyyy}", hty.StartDate);
					worksheetCh.Cells[hr, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheetCh.Cells[hr, 5].Value = string.Format("{0:MM/dd/yyyy}", hty.EndDate);
					worksheetCh.Cells[hr, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheetCh.Cells[hr, 6].Value = string.Format("{0:MM/dd/yyyy}", hty.Rate);
					worksheetCh.Cells[hr, 6].Style.Numberformat.Format = "0.00";
					worksheetCh.Cells[hr, 7].Value = hty.ClientSiteProject;
					worksheetCh.Cells[hr, 8].Value = hty.ReportingTo;
					hr += 1; 
				}
				worksheetCh.Cells.AutoFitColumns();

				var worksheetMs = package.Workbook.Worksheets.Add("Medical Surveillances");
				worksheetMs.Cells[1, 1].Value = "Title:";
				worksheetMs.Cells[1, 2].Value = "STG - Contractors Medical Surveillances Data";
				worksheetMs.Cells[2, 1].Value = "Generated at:";
				worksheetMs.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetMs.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetMs.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetMs.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetMs.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetMs.Cells[4, 1].Value = "Contractors Id";
				worksheetMs.Cells[4, 2].Value = "Full Name";
				worksheetMs.Cells[4, 3].Value = "Title";
				worksheetMs.Cells[4, 4].Value = "Issued Date";
				worksheetMs.Cells[4, 5].Value = "Expiration Date";
				worksheetMs.Cells[4, 6].Value = "Attachment";

				var msr = 5;
				foreach (var ms in model.MedicalSurveillances)
				{
					worksheetMs.Cells[msr, 1].Value = ms.ContractorId;
					worksheetMs.Cells[msr, 2].Value = ms.FullName;
					worksheetMs.Cells[msr, 3].Value = ms.Title;
					worksheetMs.Cells[msr, 4].Value = string.Format("{0:MM/dd/yyyy}", ms.IssuedDate);
					worksheetMs.Cells[msr, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheetMs.Cells[msr, 5].Value = string.Format("{0:MM/dd/yyyy}", ms.ExpirationDate);
					worksheetMs.Cells[msr, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					if(ms.AttachmentName != null)
					{
						worksheetMs.Cells[msr, 6].Value = "X";
						worksheetMs.Cells[msr, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					}
					else
						worksheetMs.Cells[msr, 6].Value = "";
					msr += 1;
				}
				worksheetMs.Cells.AutoFitColumns();

				var worksheetCM = package.Workbook.Worksheets.Add("Compliance");
				worksheetCM.Cells[1, 1].Value = "Title:";
				worksheetCM.Cells[1, 2].Value = "STG - Contractors Compliance Data";
				worksheetCM.Cells[2, 1].Value = "Generated at:";
				worksheetCM.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetCM.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetCM.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetCM.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetCM.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetCM.Cells[4, 1].Value = "Contractors Id";
				worksheetCM.Cells[4, 2].Value = "Full Name";
				worksheetCM.Cells[4, 3].Value = "Title";
				worksheetCM.Cells[4, 4].Value = "Number";
				worksheetCM.Cells[4, 5].Value = "Issued Date";
				worksheetCM.Cells[4, 6].Value = "Expiration Date";

				var cmr = 5;
				foreach (var cm in model.Compliances)
				{
					worksheetCM.Cells[cmr, 1].Value = cm.ContractorId;
					worksheetCM.Cells[cmr, 2].Value = cm.FullName;
					worksheetCM.Cells[cmr, 3].Value = cm.Title;
					worksheetCM.Cells[cmr, 4].Value = string.Format("{0:MM/dd/yyyy}", cm.IssuedDate);
					worksheetCM.Cells[cmr, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheetCM.Cells[cmr, 5].Value = string.Format("{0:MM/dd/yyyy}", cm.ExpirationDate);
					worksheetCM.Cells[cmr, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					cmr += 1;
				}
				worksheetCM.Cells.AutoFitColumns();

				var worksheetPs = package.Workbook.Worksheets.Add("Profession");
				worksheetPs.Cells[1, 1].Value = "Title:";
				worksheetPs.Cells[1, 2].Value = "STG - Contractors Profession Data";
				worksheetPs.Cells[2, 1].Value = "Generated at:";
				worksheetPs.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetPs.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetPs.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetPs.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetPs.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetPs.Cells[4, 1].Value = "Contractors Id";
				worksheetPs.Cells[4, 2].Value = "Full Name";
				worksheetPs.Cells[4, 3].Value = "Title";
				worksheetPs.Cells[4, 4].Value = "Number";
				worksheetPs.Cells[4, 5].Value = "Issued Date";
				worksheetPs.Cells[4, 6].Value = "Expiration Date";

				var pr = 5;
				foreach (var ps in model.Professions)
				{
					worksheetPs.Cells[pr, 1].Value = ps.ContractorId;
					worksheetPs.Cells[pr, 2].Value = ps.FullName;
					worksheetPs.Cells[pr, 3].Value = ps.Title;
					worksheetPs.Cells[pr, 4].Value = string.Format("{0:MM/dd/yyyy}", ps.IssuedDate);
					worksheetPs.Cells[pr, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					worksheetPs.Cells[pr, 5].Value = string.Format("{0:MM/dd/yyyy}", ps.ExpirationDate);
					worksheetPs.Cells[pr, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					pr += 1;
				}
				worksheetPs.Cells.AutoFitColumns();

				var worksheetEd = package.Workbook.Worksheets.Add("Education");
				worksheetEd.Cells[1, 1].Value = "Title:";
				worksheetEd.Cells[1, 2].Value = "STG - Contractors Education Data";
				worksheetEd.Cells[2, 1].Value = "Generated at:";
				worksheetEd.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetEd.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetEd.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetEd.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetEd.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetEd.Cells[4, 1].Value = "Contractors Id";
				worksheetEd.Cells[4, 2].Value = "Full Name";
				worksheetEd.Cells[4, 3].Value = "Type";
				worksheetEd.Cells[4, 4].Value = "Description";
				worksheetEd.Cells[4, 5].Value = "Attachment";

				var er = 5;
				foreach (var ed in model.Educations)
				{
					worksheetEd.Cells[er, 1].Value = ed.ContractorId;
					worksheetEd.Cells[er, 2].Value = ed.FullName;
					worksheetEd.Cells[er, 3].Value = ed.Type;
					worksheetEd.Cells[er, 4].Value = ed.Description;
					if (ed.AttachmentName != null)
					{
						worksheetMs.Cells[er, 5].Value = "X";
						worksheetMs.Cells[er, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					}
					else
						worksheetMs.Cells[er, 5].Value = "";
					er += 1;
				}
				worksheetEd.Cells.AutoFitColumns();

				var worksheetTn = package.Workbook.Worksheets.Add("Training");
				worksheetTn.Cells[1, 1].Value = "Title:";
				worksheetTn.Cells[1, 2].Value = "STG - Contractors Training Data";
				worksheetTn.Cells[2, 1].Value = "Generated at:";
				worksheetTn.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetTn.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetTn.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetTn.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetTn.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetTn.Cells[4, 1].Value = "Contractors Id";
				worksheetTn.Cells[4, 2].Value = "Full Name";
				worksheetTn.Cells[4, 3].Value = "Title";
				worksheetTn.Cells[4, 4].Value = "Date";

				var tr = 5;
				foreach (var tn in model.Trainings)
				{
					worksheetTn.Cells[tr, 1].Value = tn.ContractorId;
					worksheetTn.Cells[tr, 2].Value = tn.FullName;
					worksheetTn.Cells[tr, 3].Value = tn.Title;
					worksheetPs.Cells[tr, 4].Value = string.Format("{0:MM/dd/yyyy}", tn.Date);
					worksheetPs.Cells[tr, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					tr += 1;
				}
				worksheetTn.Cells.AutoFitColumns();

				var worksheetDc = package.Workbook.Worksheets.Add("Document");
				worksheetDc.Cells[1, 1].Value = "Title:";
				worksheetDc.Cells[1, 2].Value = "STG - Contractors Document Data";
				worksheetDc.Cells[2, 1].Value = "Generated at:";
				worksheetDc.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheetDc.Cells["A1:B2"].Style.Font.Bold = true;
				worksheetDc.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheetDc.Cells["A1:B2"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheetDc.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheetDc.Cells[4, 1].Value = "Contractors Id";
				worksheetDc.Cells[4, 2].Value = "Full Name";
				worksheetDc.Cells[4, 3].Value = "Type";
				worksheetDc.Cells[4, 4].Value = "Description";
				worksheetDc.Cells[4, 5].Value = "Attachment";

				var dr = 5;
				foreach (var dc in model.Documents)
				{
					worksheetDc.Cells[dr, 1].Value = dc.ContractorId;
					worksheetDc.Cells[dr, 2].Value = dc.FullName;
					worksheetDc.Cells[dr, 3].Value = dc.Type;
					worksheetDc.Cells[dr, 4].Value = dc.Description;
					if (dc.AttachmentName != null)
					{
						worksheetDc.Cells[dr, 5].Value = "X";
						worksheetDc.Cells[dr, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					}
					else
						worksheetDc.Cells[dr, 5].Value = "";
					dr += 1;
				}
				worksheetDc.Cells.AutoFitColumns();

				package.Save();
			}

			return stream;
		}

		[Obsolete]
		public static byte[] GetExpirationAlertsPDF(IWebHostEnvironment host, ContractorsHomeViewModel model)
		{
			var document = QuestPDF.Fluent.Document.Create(doc =>
			{
				string dangerColor = "#E61E24";
				//string secondaryColor = "#303549";
				string borderColor = "#B6B6B6";

				doc.Page(page =>
				{
					page.Margin(15);
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
                                col.Item().AlignLeft().Text("").FontSize(9);
                            });

							row.RelativeItem().Border(0).Column(col =>
							{
								col.Item().AlignRight().Text("SYSTEM REPORT").FontSize(14).Bold();
							});
						});
                    });

                    page.Content().Column(column =>
					{
                        column.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        column.Item().Table(table =>
						{
							table.ColumnsDefinition(column =>
							{
                                column.ConstantColumn(30);
                                column.ConstantColumn(300);
                                column.ConstantColumn(20);
                                column.RelativeColumn();
							});

							table.Cell().Row(1).Column(1).Text("Title:").Bold().FontSize(10);
							table.Cell().Row(1).Column(2).Text($"STG - Contrators Expiration Date Alerts Report").FontSize(10);
							table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        column.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
						column.Item().Table(table =>
						{
							table.ColumnsDefinition(column =>
							{
								column.ConstantColumn(40);
								column.ConstantColumn(20);
                            });

							table.Cell().Row(2).Column(1).BorderColor(borderColor).AlignLeft().Padding(2).AlignRight().BorderBottom(.2f).BorderColor(Colors.Black).Text("Legend").FontSize(10).FontColor(Colors.Black);
							table.Cell().Row(3).Column(1).BorderColor(borderColor).AlignLeft().Padding(2).AlignRight().Text("Danger").FontSize(8).FontColor(Colors.Black);
                            table.Cell().Row(3).Column(2).Border(0.2f).Background(dangerColor).BorderColor(Colors.Black).AlignLeft().Padding(2);
                            table.Cell().Row(4).Column(1).BorderColor(borderColor).AlignLeft().Padding(2).AlignRight().Text("Warning").FontSize(8).FontColor(Colors.Black);
                            table.Cell().Row(4).Column(2).Border(0.2f).Background("#CFCC1D").BorderColor(Colors.Black).AlignLeft().Padding(2);
                        });

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(90);
                                cols.RelativeColumn();
                            });
                        });

                        column.Item().Column(column =>
						{
							column.Item().Row(row =>
							{
                                row.RelativeItem().Column(col1 =>
                                {
                                    col1.Item().AlignCenter().Text("Contract Alerts");
                                    col1.Item().Width(250).PaddingTop(0).AlignCenter().Text("Contracts Alert Count  -  #" + model.ContractAlerts.Count()).FontColor(dangerColor).Bold().FontSize(10);
                                    col1.Spacing(10);
                                    col1.Item().Table(table =>
									{
                                        table.ColumnsDefinition(column =>
										{
											column.ConstantColumn(155);
											column.ConstantColumn(75);
                                            column.ConstantColumn(20);
                                        });

										table.Header(header =>
										{
											header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(Colors.White).Bold().FontSize(10);
											header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Expiration Date").FontColor(Colors.White).Bold().FontSize(10);
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("").FontSize(10);
                                        });

										foreach (var con in model.ContractAlerts)
										{
											table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.Name).FontSize(8);
											if(con.AlertType == "Danger")
											{
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ExpDate)).FontSize(8).FontColor(dangerColor);
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.RemainingDays).FontSize(8).FontColor(dangerColor);
                                            }
											else
											{
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ExpDate)).FontSize(8).FontColor("#CFCC1D");
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.RemainingDays).FontSize(8).FontColor("#CFCC1D");
                                            }
                                        }
									});
                                });

                                row.RelativeItem().Column(col2 =>
                                {
                                    col2.Item().AlignCenter().Text("Medical Surveillance Alerts");
                                    col2.Item().Width(250).PaddingTop(0).AlignCenter().Text("Contracts Alert Count  -  #" + model.MedicalSurveillanceAlerts.Count()).FontColor(dangerColor).Bold().FontSize(10);
                                    col2.Spacing(10);
                                    col2.Item().Table(table =>
                                    {
                                        table.ColumnsDefinition(column =>
                                        {
                                            column.ConstantColumn(155);
                                            column.ConstantColumn(75);
                                            column.ConstantColumn(20);
                                        });

                                        table.Header(header =>
                                        {
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(Colors.White).Bold().FontSize(10);
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Expiration Date").FontColor(Colors.White).Bold().FontSize(10);
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("").FontSize(10);
                                        });

                                        foreach (var con in model.MedicalSurveillanceAlerts)
                                        {
                                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.Name).FontSize(8);
                                            if (con.AlertType == "Danger")
											{
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ExpDate)).FontSize(8).FontColor(dangerColor);
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.RemainingDays).FontSize(8).FontColor(dangerColor);
                                            }
											else
											{
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ExpDate)).FontSize(8).FontColor("#CFCC1D");
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.RemainingDays).FontSize(8).FontColor("#CFCC1D");
                                            }
                                        }
                                    });
                                });

                                row.RelativeItem().Column(col3 =>
                                {
                                    col3.Item().AlignCenter().Text("Compliance Alerts");
                                    col3.Item().Width(250).PaddingTop(0).AlignCenter().Text("Contracts Alert Count  -  #" + model.ComplianceAlerts.Count()).FontColor(dangerColor).Bold().FontSize(10);
                                    col3.Spacing(10);
                                    col3.Item().Table(table =>
                                    {
                                        table.ColumnsDefinition(column =>
                                        {
                                            column.ConstantColumn(155);
                                            column.ConstantColumn(75);
                                            column.ConstantColumn(20);
                                        });
                                        
                                        table.Header(header =>
                                        {
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(Colors.White).Bold().FontSize(10);
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Expiration Date").FontColor(Colors.White).Bold().FontSize(10);
                                            header.Cell().Background(dangerColor).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("").FontSize(10);
                                        });

                                        foreach (var con in model.ComplianceAlerts)
                                        {
                                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.Name).FontSize(8);
                                            if (con.AlertType == "Danger")
                                            {
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ExpDate)).FontSize(8).FontColor(dangerColor);
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.RemainingDays).FontSize(8).FontColor(dangerColor);
                                            }
                                            else
                                            {
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(string.Format("{0:MM/dd/yyyy}", con.ExpDate)).FontSize(8).FontColor("#CFCC1D");
                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(con.RemainingDays).FontSize(8).FontColor("#CFCC1D");
                                            }
                                        }
                                    });
                                });
                            });
						});

                        column.Spacing(10);
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
