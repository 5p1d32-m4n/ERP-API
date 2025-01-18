using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ERP_API.Models.BusinessResources;
using SixLabors.ImageSharp; 
using SixLabors.ImageSharp.Formats.Jpeg; 
using SixLabors.ImageSharp.Processing;

namespace ERP_API.Models.Timesheet
{
	public class TimesheetReport
	{
        public static byte[] GetPaycodeListPDF(IWebHostEnvironment host, TimesheetPayCodeViewModel viewModel, string paycodeType, string searchTerm)
        {
            var document = Document.Create(doc =>
            {
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

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
                                col.Item().AlignRight().Text("Paycode List Report").FontSize(14).Bold();
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
                                cols.RelativeColumn();
                            });

                            table.Cell().Row(1).Column(1).Text("Title:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"STG - {paycodeType} Paycode List Report").FontSize(10);
                            table.Cell().Row(1).Column(3).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(100);  
                                cols.ConstantColumn(200);  
                                cols.ConstantColumn(150);  
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                      .AlignLeft().AlignBottom().Padding(2).Text("Paycode").FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                      .AlignLeft().AlignBottom().Padding(2).Text("Description").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                      .AlignLeft().AlignBottom().Padding(2).Text("Type").FontColor(secondaryColor).FontSize(8);
                            });

                            foreach (var paycode in viewModel.PayCodes)
                            {
                                if ((string.IsNullOrEmpty(searchTerm) || paycode.Code.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                                    (paycodeType == "All" ||
                                    (paycodeType == "Regular" && paycode.ProjectId == 0) ||
                                    (paycodeType == "Project" && paycode.ProjectId > 0)))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2)
                                        .Text(paycode.Code).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2)
                                        .Text(paycode.Name).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2)
                                        .Text(paycode.ProjectId > 0 ? "Project" : "Regular").FontSize(8);
                                }
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

        public static byte[] GetApproversListPDF(IWebHostEnvironment host, List<BusinessResource> approversList, string department, string searchTerm)
        {
            var document = Document.Create(doc =>
            {
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";

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
                                col.Item().AlignRight().Text("Timesheet Approvers List").FontSize(14).Bold();
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
                                cols.RelativeColumn();
                            });

                            table.Cell().Row(1).Column(1).Text("Title:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"Timesheet {department} Approvers List Report").FontSize(10);
                            table.Cell().Row(1).Column(3).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(60);  
                                cols.ConstantColumn(250);  
                                cols.ConstantColumn(200); 
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                      .AlignLeft().AlignBottom().Padding(2).Text("#").FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                      .AlignLeft().AlignBottom().Padding(2).Text("Approver Name").FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(0.8f).BorderColor(Colors.Black)
                                      .AlignLeft().AlignBottom().Padding(2).Text("Department").FontColor(secondaryColor).FontSize(8);
                            });

                            int counter = 1;
                            foreach (var approver in approversList)
                            {
                                if ((string.IsNullOrEmpty(searchTerm) || approver.Fullname.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                                  (department == "All" ||
                                  (department == "Administration") ||
                                  (department == "A&E") ||
                                  (department == "PMO") ||
                                  (department == "Outsourcing") ||
                                  (department == "Enviromental") ||
                                  (department == "Construction") ||
                                  (department == "Software Development")))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2)
                                      .Text(counter++.ToString()).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2)
                                          .Text(approver.Fullname).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2)
                                          .Text(approver.Department.Name).FontSize(8);

                                }
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

		public static byte[] GetTimesheetReportPDF(IWebHostEnvironment host, TimesheetReportCreateEditViewModel model)
		{
			var document = Document.Create(doc =>
			{
				string dangerColor = "#E61E24";
				string secondaryColor = "#303549";
				string borderColor = "#B6B6B6";
				string grayColor = "#B6B6B6";

				doc.Page(page =>
				{
					page.Margin(25);
					page.Size(PageSizes.Letter.Landscape());

					page.Header().ShowOnce().Column(col =>
					{
						var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");
						if (!File.Exists(imgPath))
						{
							throw new FileNotFoundException("Logo image not found.", imgPath);
						}

						byte[] imgData = File.ReadAllBytes(imgPath);

						col.Item().Row(row =>
						{
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
								col.Item().AlignRight().Text("Timesheet Report").FontSize(14).Bold();
							});
						});
					});

					page.Content().Column(column =>
					{
						if (model.GroupedTimeSheetEntries != null)
						{
							foreach (var resourceGroup in model.GroupedTimeSheetEntries)
							{
								var resourceName = model.ResourceNames.TryGetValue(resourceGroup.Key, out var name) ? name : "Unknown Resource";
								column.Item().Text($"Resource: {resourceName}").FontSize(10).Bold();
								column.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

								column.Item().Table(table =>
								{
									// Dynamically calculate column count
									int columnCount = 0;
									if (model.IncludeDate) columnCount++;
									if (model.IncludeDuration) columnCount++;
									if (model.IncludePayCodeTitle) columnCount++;
									if (model.IncludeDeliverable) columnCount++;
									if (model.IncludeComments) columnCount++;
									if (model.IncludeApproverName) columnCount++;
									if (model.IncludeApproveDate) columnCount++;

									table.ColumnsDefinition(columns =>
									{
										if (model.IncludeDate) columns.ConstantColumn(100);
										if (model.IncludeDuration) columns.ConstantColumn(100);
										if (model.IncludePayCodeTitle) columns.ConstantColumn(100);
										if (model.IncludeDeliverable) columns.ConstantColumn(100);
										if (model.IncludeComments) columns.ConstantColumn(100);
										if (model.IncludeApproverName) columns.ConstantColumn(100);
										if (model.IncludeApproveDate) columns.ConstantColumn(100);
									});

									table.Header(header =>
									{
										if (model.IncludeDate) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Entry Date").FontColor(secondaryColor).FontSize(7);
										if (model.IncludeDuration) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Duration (hrs)").FontColor(secondaryColor).FontSize(7);
										if (model.IncludePayCodeTitle) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Paycode Title").FontColor(secondaryColor).FontSize(7);
										if (model.IncludeDeliverable) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Deliverable Name").FontColor(secondaryColor).FontSize(7);
										if (model.IncludeComments) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Comments").FontColor(secondaryColor).FontSize(7);
										if (model.IncludeApproverName) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Approver Name").FontColor(secondaryColor).FontSize(7);
										if (model.IncludeApproveDate) header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Approved Date").FontColor(secondaryColor).FontSize(7);
									});

									float totalDurationForResource = 0;

									foreach (var dateGroup in resourceGroup.Value.GroupBy(e => e.EntryDate.Date))
									{
										float dailyTotal = 0;

										foreach (var entry in dateGroup)
										{
											if (model.IncludeDate) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(entry.EntryDate.ToString("yyyy-MM-dd")).FontSize(8);
											if (model.IncludeDuration) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(((float)entry.Duration / 3600).ToString("0.00")).FontSize(8);
											if (model.IncludePayCodeTitle) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(entry.Paycode?.Name).FontSize(8);
											if (model.IncludeDeliverable) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(entry.Deliverable).FontSize(8);
											if (model.IncludeComments) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(entry.Comments).FontSize(8);
											if (model.IncludeApproverName) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(entry.ApproverName).FontSize(8);
											if (model.IncludeApproveDate) table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(entry.ApprovedDate?.ToString("yyyy-MM-dd")).FontSize(8);

											dailyTotal += (float)entry.Duration / 3600;
										}
										if (model.IncludeDailyTotal) {
											table.Cell().AlignLeft().Text("Dailty Total:").FontSize(8).Bold();
											table.Cell().ColumnSpan((uint)(columnCount - 1)).BorderTop(0.5f).BorderColor(secondaryColor).Text($"{dailyTotal.ToString("0.00")} hrs").FontSize(8).Bold();
										}
										totalDurationForResource += dailyTotal;
									}

									if (model.IncludeTotal)
									{
										table.Footer(footer =>
										{
											table.Cell().AlignLeft().Text("Total:").FontSize(8).Bold();
											table.Cell().AlignLeft().Text($"{totalDurationForResource.ToString("0.00")} hrs").FontSize(8).Bold();
										});
									}
								});

								column.Item().PaddingVertical(10);
							}
						}
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

        public static byte[] GetResourcesListPDF(IWebHostEnvironment host, TimesheetResourceHourViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";

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
                                cols.ConstantColumn(40);  
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
                                    .AlignLeft().AlignBottom().Padding(2).Text("Image").FontColor(secondaryColor).FontSize(8);
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
                                    .AlignCenter().AlignBottom().Padding(2).Text("UR%").FontColor(secondaryColor).FontSize(8);
                            });

                            int counter = 1;
                            for (int i = 0; i < viewModel.resources.Count(); i++)
                            {
                                var resource = viewModel.resources[i];
                                var otherHours = viewModel.otherHours.ContainsKey(resource.Id) ? viewModel.otherHours[resource.Id] : 0;
                                var projectHours = viewModel.projectHours.ContainsKey(resource.Id) ? viewModel.projectHours[resource.Id] : 0;
                                var totalHours = otherHours + projectHours;
                                var utilizationRate = totalHours > 0 ? (projectHours / totalHours) * 100 : 0;
                                var projectPayCodeCount = viewModel.projectPayCodeCounts.ContainsKey(resource.Id) ? viewModel.projectPayCodeCounts[resource.Id] : 0;
                                
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(counter++.ToString()).FontSize(8);

                                if (!string.IsNullOrEmpty(resource.ImageName))
                                {
                                    string imageUrl = resource.GetImageUrl();
                                    string fullImagePath = Path.Combine(host.ContentRootPath, "wwwroot", imageUrl.TrimStart('/'));

                                    if (File.Exists(fullImagePath))
                                    {
                                        using (var image = Image.Load(fullImagePath))
                                        {
                                            int targetWidth = 150;
                                            int targetHeight = (int)(image.Height * ((float)targetWidth / image.Width));
                                            image.Mutate(x => x.Resize(targetWidth, targetHeight));

                                            using (var memoryStream = new MemoryStream())
                                            {
                                                image.Save(memoryStream, new JpegEncoder());
                                                byte[] resourceImage = memoryStream.ToArray();

                                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).Padding(5).Image(resourceImage);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        table.Cell().BorderBottom(0.5f).BorderColor(borderColor).Padding(5).Text("Image Not Found").FontSize(8);
                                    }
                                }
                                else
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).Padding(5).Text("No Image").FontSize(8);
                                }

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.Fullname).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resource.JobTitle).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(projectPayCodeCount).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", otherHours)).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", projectHours)).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}", totalHours)).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(string.Format("{0:F2}%", utilizationRate)).FontSize(8);
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

        #region Timesheet Excel export

        public static MemoryStream GetTimesheetReportExcel(TimesheetReportCreateEditViewModel model)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add("Timesheet Report");

				int row = 2;

				foreach (var resourceGroup in model.GroupedTimeSheetEntries)
				{
					var resourceName = model.ResourceNames.ContainsKey(resourceGroup.Key)
						? model.ResourceNames[resourceGroup.Key]
						: "Unknown Resource";

					worksheet.Cells[row, 1].Value = $"Resource: {resourceName}";
					worksheet.Cells[row, 1].Style.Font.Bold = true;
					worksheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
					worksheet.Cells[row, 1, row, 7].Merge = true;

					worksheet.Cells[row, 1, row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
					worksheet.Cells[row, 1, row, 2].Style.Font.Color.SetColor(System.Drawing.Color.White);
					worksheet.Cells[row, 1, row, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));
					worksheet.Cells[row, 1, row, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
					row++;

					int headerIndex = 1;
					if (model.IncludeDate) worksheet.Cells[row, headerIndex++].Value = "Entry Date";
					if (model.IncludeDuration) worksheet.Cells[row, headerIndex++].Value = "Duration (hrs)";
					if (model.IncludePayCodeTitle) worksheet.Cells[row, headerIndex++].Value = "Paycode Title";
					if (model.IncludeDeliverable) worksheet.Cells[row, headerIndex++].Value = "Deliverable Name";
					if (model.IncludeComments) worksheet.Cells[row, headerIndex++].Value = "Comments";
					if (model.IncludeApproverName) worksheet.Cells[row, headerIndex++].Value = "Approver Name";
					if (model.IncludeApproveDate) worksheet.Cells[row, headerIndex++].Value = "Approved Date";

					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
					row++;

					float totalDurationForResource = 0;
					float dailyTotal = 0;
					DateTime? currentDate = null;

					foreach (var entry in resourceGroup.Value)
					{
						headerIndex = 1;

						if (model.IncludeDate)
						{
							var entryDate = entry.EntryDate.Date;

							if (model.IncludeDailyTotal && currentDate != null && currentDate != entryDate)
							{
								worksheet.Cells[row, 1].Value = $"Daily Total ({currentDate.Value:yyyy-MM-dd}):";
								worksheet.Cells[row, 1].Style.Font.Bold = true;
								worksheet.Cells[row, 2].Value = dailyTotal.ToString("0.00");
								worksheet.Cells[row, 2].Style.Font.Bold = true;
								row++;
								dailyTotal = 0; 
							}

							currentDate = entryDate;
							worksheet.Cells[row, headerIndex++].Value = entryDate.ToString("yyyy-MM-dd");
						}

						if (model.IncludeDuration)
						{
							var durationHours = (float)entry.Duration / 3600;
							totalDurationForResource += durationHours;
							dailyTotal += durationHours;
							worksheet.Cells[row, headerIndex++].Value = durationHours.ToString("0.00");
						}
						if (model.IncludePayCodeTitle)
							worksheet.Cells[row, headerIndex++].Value = entry.Paycode?.Name;
						if (model.IncludeDeliverable)
						{
							var deliverableValue = entry.Deliverable == "Construction Support"
								? $"{entry.Deliverable} - {entry.ConstructionSupport}"
								: entry.Deliverable;

							worksheet.Cells[row, headerIndex++].Value = deliverableValue;
						}

						if (model.IncludeComments)
							worksheet.Cells[row, headerIndex++].Value = entry.Comments;
						if (model.IncludeApproverName)
							worksheet.Cells[row, headerIndex++].Value = entry.ApproverName;
						if (model.IncludeApproveDate)
							worksheet.Cells[row, headerIndex++].Value = entry.ApprovedDate?.ToString("yyyy-MM-dd");

						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#f0f0f0"));
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						row++;
					}

					if (model.IncludeDailyTotal && currentDate != null)
					{
						worksheet.Cells[row, 1].Value = $"Daily Total ({currentDate.Value:yyyy-MM-dd}):";
						worksheet.Cells[row, 1].Style.Font.Bold = true;
						worksheet.Cells[row, 2].Value = dailyTotal.ToString("0.00");
						worksheet.Cells[row, 2].Style.Font.Bold = true;
						row++;
					}

					if (model.IncludeTotal)
					{
						worksheet.Cells[row, 1].Value = "Total Duration (hrs):";
						worksheet.Cells[row, 1].Style.Font.Bold = true;
						worksheet.Cells[row, 2].Value = totalDurationForResource.ToString("0.00");
						worksheet.Cells[row, 2].Style.Font.Bold = true;
						worksheet.Cells[row, 1, row, headerIndex - 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
						row += 2; 
					}
				}

				worksheet.Cells.AutoFitColumns();
				package.Save();
			}

			return stream;
		}


		public static MemoryStream GetPaycodesListExcel(TimesheetPayCodeViewModel viewModel, string paycodeType, string searchTerm)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream)) 
            {
                var worksheet = package.Workbook.Worksheets.Add("Paycode List Report");

               
                worksheet.Cells[1, 1, 1, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1, 1, 4].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[1, 1, 1, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

              
                worksheet.Cells["A1"].Value = "Timesheet Paycodes List";
                worksheet.Cells["A1"].Style.Font.Size = 14;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));
                worksheet.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1:C1"].Merge = true; 

                
                worksheet.Cells[2, 1].Value = "#";
                worksheet.Cells[2, 2].Value = "Paycode";
                worksheet.Cells[2, 3].Value = "Description";
                worksheet.Cells[2, 4].Value = "Type";

               
                var filteredPayCodes = viewModel.PayCodes.AsEnumerable();

                
                if (!string.IsNullOrEmpty(paycodeType))
                {
                    if (paycodeType == "Project")
                    {
                        filteredPayCodes = filteredPayCodes.Where(pc => pc.ProjectId > 0);
                    }
                    else if (paycodeType == "Regular")
                    {
                        filteredPayCodes = filteredPayCodes.Where(pc => pc.ProjectId == 0);
                    }
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filteredPayCodes = filteredPayCodes.Where(pc =>
                        pc.Code.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                }

                int row = 3;
                int counter = 1;

                foreach (var paycode in filteredPayCodes)
                {
                    worksheet.Cells[row, 1].Value = counter++;
                    worksheet.Cells[row, 2].Value = paycode.Code;
                    worksheet.Cells[row, 3].Value = paycode.Name;
                    worksheet.Cells[row, 4].Value = paycode.ProjectId > 0 ? "Project" : "Regular";
                    row++;
                }

                worksheet.Cells.AutoFitColumns();

                package.Save(); 
            }

          
            stream.Position = 0;

            return stream; 
        }

		public static MemoryStream GetApproversListExcel(List<BusinessResource> approversList, string department, string searchTerm)
		{
			var stream = new MemoryStream();

			if (department != "All")
			{
				approversList = approversList.Where(a => a.Department.Name.Equals(department, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				approversList = approversList.Where(a => a.Fullname.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add("Timesheet Approvers List");

				worksheet.Cells[1, 1, 1, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells[1, 1, 1, 3].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells[1, 1, 1, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				worksheet.Cells[1, 1].Value = "#";
				worksheet.Cells[1, 2].Value = "Approver Name";
				worksheet.Cells[1, 3].Value = "Department";

				int row = 2;
				int counter = 1;

				foreach (var approver in approversList)
				{
					worksheet.Cells[row, 1].Value = counter++;
					worksheet.Cells[row, 2].Value = approver.Fullname;
					worksheet.Cells[row, 3].Value = approver.Department.Name;

					worksheet.Cells[row, 1, row, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
					worksheet.Cells[row, 1, row, 3].Style.Font.Color.SetColor(System.Drawing.Color.White);
					worksheet.Cells[row, 1, row, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
					worksheet.Cells[row, 1, row, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
					worksheet.Cells[row, 1, row, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;

					row++;
				}

				worksheet.Cells.AutoFitColumns();

				worksheet.Cells["A1"].Value = "Timesheet Approvers List";
				worksheet.Cells["A1"].Style.Font.Size = 14;
				worksheet.Cells["A1"].Style.Font.Bold = true;
				worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));
				worksheet.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
				worksheet.Cells["A1:C1"].Merge = true; 

				package.Save();
			}

			return stream;
		}

        public static MemoryStream GetResourcesListExcel(TimesheetResourceHourViewModel viewModel)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Resources List Report");

                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";

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

                foreach (var resource in viewModel.resources)
                {
                    var otherHours = viewModel.otherHours.ContainsKey(resource.Id) ? viewModel.otherHours[resource.Id] : 0;
                    var projectHours = viewModel.projectHours.ContainsKey(resource.Id) ? viewModel.projectHours[resource.Id] : 0;
                    var totalHours = otherHours + projectHours;
                    var utilizationRate = totalHours > 0 ? (projectHours / totalHours) * 100 : 0; // Avoid division by zero
                    var projectPayCodeCount = viewModel.projectPayCodeCounts.ContainsKey(resource.Id) ? viewModel.projectPayCodeCounts[resource.Id] : 0;
                    
                    worksheet.Cells[row, 1].Value = counter++;
                    worksheet.Cells[row, 2].Value = resource.Fullname;
                    worksheet.Cells[row, 3].Value = resource.JobTitle;
                    worksheet.Cells[row, 4].Value = projectPayCodeCount;
                    worksheet.Cells[row, 5].Value = string.Format("{0:F2}", otherHours);
                    worksheet.Cells[row, 6].Value = string.Format("{0:F2}", projectHours);
                    worksheet.Cells[row, 7].Value = string.Format("{0:F2}", totalHours); // Add Total Hours
                    worksheet.Cells[row, 8].Value = string.Format("{0:F2}%", utilizationRate); // Add Utilization Rate (URS%)

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
