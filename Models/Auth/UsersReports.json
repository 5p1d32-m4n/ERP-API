using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ERP_API.Models.Resources;
using ERP_API.Models.BusinessResources;
using ERP_API.Models.Helpers;
using ERP_API.Services;
using System.Data;
using System.Reflection;

namespace ERP_API.Models.Auth

{
    public class UsersReports
    {

        //Users - List
        public static byte[] GetUsersListPDF(IWebHostEnvironment host, ApplicationUserViewModel model)
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
                                cols.ConstantColumn(100);
                                cols.ConstantColumn(150);
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                                //cols.ConstantColumn(50);
                                //cols.ConstantColumn(50);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Status").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Email").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Phone Number").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Role").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                            // foreach (var item in Enumerable.Range(1, 20))
                            foreach (var applicationusers in model.ApplicationUsers)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(applicationusers.IsActive).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(applicationusers.FullName).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(applicationusers.Email).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(applicationusers.PhoneNumber).FontSize(8);
                                // Concatenate roles into a single string separated by commas
                                string rolesString = string.Join(", ", applicationusers.Roles);

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rolesString).FontSize(8);

                                num++;
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

        //Users - List
        public static byte[] GetRolesListPDF(IWebHostEnvironment host, ApplicationRoleViewModel model)
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
                            table.Cell().Row(1).Column(2).Text($"STG - Roles List Report").FontSize(10);
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
                                cols.ConstantColumn(100);
                                cols.ConstantColumn(250);
                                cols.ConstantColumn(60);
                                //cols.ConstantColumn(50);
                                //cols.ConstantColumn(50);
                            });
                           
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Role Name").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Description").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Users in Role").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                        // foreach (var item in Enumerable.Range(1, 20))
                        foreach (var applicationroles in model.ApplicationRoles)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(applicationroles.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(applicationroles.Description).FontSize(8);
                                
                                if (model.UserCountsByRole.ContainsKey($"{applicationroles.Name} ({applicationroles.Id})"))
                                {
                                    var userCount = model.UserCountsByRole[$"{applicationroles.Name} ({applicationroles.Id})"]; 
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(userCount.ToString()).FontSize(8);
                                }

                                
                                num ++;
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

        public static byte[] GetUsersListWithRolesPDF(IWebHostEnvironment host, ApplicationUserViewModel model, string searchTerm)
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
                            table.Cell().Row(1).Column(2).Text($"STG - User Roles List Report").FontSize(10);
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
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                                //cols.ConstantColumn(50);
                                //cols.ConstantColumn(50);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Full Name").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Role").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;

                            foreach (var applicationusers in model.ApplicationUsers)
                            {
                                
                                if (string.IsNullOrEmpty(searchTerm) || applicationusers.Email.Split('@')[0].Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(applicationusers.FullName).FontSize(8);

                                    string rolesString = string.Join(", ", applicationusers.Roles);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(rolesString).FontSize(8);

                                    num++;
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

        public static byte[] GenerateUserAccountListPDF(IWebHostEnvironment host, ApplicationUserViewModel model, string reportType, string searchTerm)
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
                        var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");
                        byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

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
                            table.Cell().Row(1).Column(2).Text($"STG - {reportType} Account List Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(60);
                                cols.ConstantColumn(150);
                                cols.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Email").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Status").FontColor(secondaryColor).FontSize(7);
                            });

                            int num = 1;
                            
                            var sortedUsers = model.ApplicationUsers.OrderByDescending(user => user.Id).ToList();
                            foreach (var user in sortedUsers)
                            {
                                if ((string.IsNullOrEmpty(searchTerm) || user.Email.Split('@')[0].Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                                     (reportType == "All" ||
                                     (reportType == "Active" && user.IsActive) ||
                                     (reportType == "Inactive" && !user.IsActive) ||
                                     (reportType == "Confirmed" && user.EmailConfirmed) ||
                                     (reportType == "Locked Out" && user.LockoutEnabled) ||
                                     (reportType == "Unconfirmed" && !user.EmailConfirmed) ||
                                     (reportType == "Unlocked" && !user.LockoutEnabled)))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(user.Email).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(GetStatusText(user, reportType)).FontSize(8);
                                    num++;
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


        private static string GetStatusText(ApplicationUser user, string reportType)
        {
            List<string> statuses = new List<string>();

            if (reportType == "All")
            {
                if (user.IsActive) statuses.Add("Active");
                else statuses.Add("Inactive");

                if (user.EmailConfirmed) statuses.Add("Confirmed");
                else statuses.Add("Unconfirmed");

                if (user.LockoutEnabled) statuses.Add("Locked Out");
                else statuses.Add("Unlocked");
            }
            else
            {
                switch (reportType)
                {
                    case "Active":
                        return "Active";
                    case "Inactive":
                        return "Inactive";
                    case "Confirmed":
                        return "Confirmed";
                    case "Locked Out":
                        return "Locked Out";
                    case "Unconfirmed":
                        return "Unconfirmed";
                    case "Unlocked":
                        return "Unlocked";
                    default:
                        return "Unknown Status";
                }
            }

            return string.Join(", ", statuses);
        }


		public static byte[] GetAuditTrailListPDF(IWebHostEnvironment host, IEnumerable<AuditTrail> model, string reportType, string searchTerm)
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
							table.Cell().Row(1).Column(2).Text($"STG - {reportType} Audit Trail List Report").FontSize(10);
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
								cols.ConstantColumn(120);
								cols.ConstantColumn(250);
								cols.ConstantColumn(150);
								cols.ConstantColumn(95);
							});

							table.Header(header =>
							{
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Module").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Action").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Description").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Email").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Date Time").Bold().FontColor(secondaryColor).FontSize(8);
							});

							var num = 1;
							// foreach (var item in Enumerable.Range(1, 20))
							foreach (var audit in model)
							{
                                if ((string.IsNullOrEmpty(searchTerm) || audit.UserEmail.Split('@')[0].Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                                  (reportType == "ALL" ||
                                  (reportType == "Administration") ||
                                  (reportType == "Clients") ||
                                  (reportType == "Resources") ||
                                  (reportType == "Timesheet") ||
                                  (reportType == "Proposals") ||
								  (reportType == "Projects") ||
								  (reportType == "Assets")))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(GetModuleText(audit, reportType)).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.Action).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.Description).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.UserEmail).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.DateTime).FontSize(8);
                                    num++;
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

		private static string GetModuleText(AuditTrail audit, string reportType)
		{
				switch (reportType)
				{
					case "Administration":
						return "Administration";
					case "Clients":
						return "Clients";
					case "Resources":
						return "Resources";
					case "Timesheet":
						return "Timesheet";
					case "Proposals":
						return "Proposals";
					case "Projects":
						return "Projects";
					case "Assets":
						return "Assets";
					default:
						return "Unknown Status";
				}
		}

		public static byte[] GetAuditTrailListPDF(IWebHostEnvironment host, IEnumerable<AuditTrail> model)
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
							table.Cell().Row(1).Column(2).Text($"STG - Audit Trail List Report").FontSize(10);
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
								cols.ConstantColumn(120);
								cols.ConstantColumn(250);
								cols.ConstantColumn(150);
								cols.ConstantColumn(95);
							});

							table.Header(header =>
							{
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Module").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Action").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Description").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Email").Bold().FontColor(secondaryColor).FontSize(8);
								header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Date Time").Bold().FontColor(secondaryColor).FontSize(8);
							});

							var num = 1;
							// foreach (var item in Enumerable.Range(1, 20))
							foreach (var audit in model)
							{
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.Module).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.Action).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.Description).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.UserEmail).FontSize(8);
								table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(audit.DateTime).FontSize(8);
								num ++;
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

        public static byte[] GetAccountLogsPDF(IWebHostEnvironment host, IEnumerable<UserLoginLog> model)
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
                            table.Cell().Row(1).Column(2).Text($"STG - Account Logs List Report").FontSize(10);
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
                                cols.ConstantColumn(100);
                                cols.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("#").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Date").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("FullName").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                            
                            foreach (var logs in model)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(num.ToString()).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(logs.LoginTime.ToString("MMM/dd/yyyy hh:mm tt")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(logs.UserName).FontSize(8);
                       
                                num++;
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

        public static MemoryStream GetAccountLogsExcel(IEnumerable<UserLoginLog> model)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Users List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Account Logs List Report";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "#";
                worksheet.Cells[4, 2].Value = "Date";
                worksheet.Cells[4, 3].Value = "Full Name";
                
                worksheet.Cells["A4:C4"].Style.Font.Bold = true;
                worksheet.Cells["A4:C4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:C4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:C4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r = 5;
                var counter = 1;
                foreach (var logs in model)
                {
                    worksheet.Cells[r, 1].Value = counter;
                    worksheet.Cells[r, 2].Value = logs.LoginTime.ToString("MMM/dd/yyyy hh:mm tt");
                    worksheet.Cells[r, 3].Value = logs.UserName;
                    
                    counter++;
                    r++;
                }

                worksheet.Cells.AutoFitColumns();
                worksheet.Column(1).Width = 7;
                package.Save();
            }

            return stream;
        }
        public static MemoryStream GetUsersListExcel(ApplicationUserViewModel model)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Users List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Users List Report";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "#";
                worksheet.Cells[4, 2].Value = "Status";
                worksheet.Cells[4, 3].Value = "Full Name";
                worksheet.Cells[4, 4].Value = "Email";
                worksheet.Cells[4, 5].Value = "Phone Number";
                worksheet.Cells[4, 6].Value = "Roles";
             

                //worksheet.Cells["A4:G6"].Style.Font.Bold = true;
                worksheet.Cells["A4:F4"].Style.Font.Bold = true;
                worksheet.Cells["A4:F4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:F4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:F4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r = 5;
                var counter = 1;
                foreach (var user in model.ApplicationUsers)
                {
                    worksheet.Cells[r, 1].Value = counter;
                    worksheet.Cells[r, 2].Value = user.IsActive;
                    worksheet.Cells[r, 3].Value = user.FullName;
                    worksheet.Cells[r, 4].Value = user.Email;
                    worksheet.Cells[r, 5].Value = user.PhoneNumber;
                    string rolesString = string.Join(", ", user.Roles);
                    worksheet.Cells[r, 6].Value = rolesString;
                    counter++;
                    r ++;
                }

                worksheet.Cells.AutoFitColumns();
                worksheet.Column(1).Width = 4;
                package.Save();
            }

            return stream;
        }
        public static MemoryStream GetRolesListExcel(ApplicationRoleViewModel model)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Roles List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Roles List Report";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "#";
                worksheet.Cells[4, 2].Value = "Role Name";
                worksheet.Cells[4, 3].Value = "Description";
                worksheet.Cells[4, 4].Value = "Users in Role";



                //worksheet.Cells["A4:G6"].Style.Font.Bold = true;
                worksheet.Cells["A4:D4"].Style.Font.Bold = true;
                worksheet.Cells["A4:D4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:D4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:D4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r = 5;
                var counter = 1;
                foreach (var role in model.ApplicationRoles)
                {
                    worksheet.Cells[r, 1].Value = counter;
                    worksheet.Cells[r, 2].Value = role.Name;
                    worksheet.Cells[r, 3].Value = role.Description;
                    if (model.UserCountsByRole.ContainsKey($"{role.Name} ({role.Id})"))
                    {
                        var userCount = model.UserCountsByRole[$"{role.Name} ({role.Id})"];
                        worksheet.Cells[r, 4].Value = userCount.ToString(); 
                    }
                    counter++;
                    r++;
                }

                worksheet.Cells.AutoFitColumns();
                worksheet.Column(1).Width = 4;
                package.Save();
            }

            return stream;
        }

        public static MemoryStream GetUsersListWithRolesExcel(ApplicationUserViewModel model, string searchTerm)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Users List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - User Roles List Report";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "#";
                worksheet.Cells[4, 2].Value = "Full Name";
                worksheet.Cells[4, 3].Value = "Roles";


                //worksheet.Cells["A4:G6"].Style.Font.Bold = true;
                worksheet.Cells["A4:C4"].Style.Font.Bold = true;
                worksheet.Cells["A4:C4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:C4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:C4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                var r = 5;
                var counter = 1;
                foreach (var user in model.ApplicationUsers.Where(u => string.IsNullOrEmpty(searchTerm) ||
											 u.Email.Split('@')[0].Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
				{
                    worksheet.Cells[r, 1].Value = counter;
                    worksheet.Cells[r, 2].Value = user.FullName;
                    string rolesString = string.Join(", ", user.Roles);
                    worksheet.Cells[r, 3].Value = rolesString;
                    counter++;
                    r++;
                }

                worksheet.Cells.AutoFitColumns();
                worksheet.Column(1).Width = 4;
                package.Save();
            }

            return stream;
        }

		public static MemoryStream GetAccountListExcel(ApplicationUserViewModel model, string reportType, string searchTerm)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add("Users List");

				string title = "STG - All Account List Report";
				string statusHeader = "Status";

				// Set title and status header based on report type
				if (reportType != "All")
				{
					// Use existing logic for specific report types
					switch (reportType)
					{
						case "Active":
							title = "STG - Active Account List Report";
							statusHeader = "Status";
							break;
						case "Inactive":
							title = "STG - Inactive Account List Report";
							statusHeader = "Status";
							break;
						case "Confirmed":
							title = "STG - Confirmed Account List Report";
							statusHeader = "Confirmed";
							break;
						case "Unconfirmed":
							title = "STG - Unconfirmed Account List Report";
							statusHeader = "Unconfirmed";
							break;
						case "Locked":
							title = "STG - Locked Account List Report";
							statusHeader = "Lockout Enabled";
							break;
						case "Unlocked":
							title = "STG - Unlocked Account List Report";
							statusHeader = "Lockout Disabled";
							break;
						default:
							throw new ArgumentException("Invalid report type");
					}
				}

				// Header setup
				worksheet.Cells[1, 1].Value = "Title:";
				worksheet.Cells[1, 2].Value = title;
				worksheet.Cells[2, 1].Value = "Generated at:";
				worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheet.Cells[4, 1].Value = "#";
				worksheet.Cells[4, 2].Value = "Email";
				worksheet.Cells[4, 3].Value = statusHeader;

				worksheet.Cells["A4:C4"].Style.Font.Bold = true;
				worksheet.Cells["A4:C4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A4:C4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A4:C4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				var r = 5;
				var counter = 1;
				var sortedUsers = model.ApplicationUsers.OrderByDescending(user => user.Id).ToList();

				foreach (var user in sortedUsers
							 .Where(u => string.IsNullOrEmpty(searchTerm) ||
										 u.Email.Split('@')[0].Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
				{
					worksheet.Cells[r, 1].Value = counter;
					worksheet.Cells[r, 2].Value = user.Email;

					
					if (reportType == "All")
					{
						var statuses = new List<string>();
						statuses.Add(user.IsActive ? "Active" : "Inactive");
						statuses.Add(user.EmailConfirmed ? "Confirmed" : "Unconfirmed");
						statuses.Add(user.LockoutEnabled ? "Locked" : "Unlocked");
						worksheet.Cells[r, 3].Value = string.Join(", ", statuses);
					}
					else
					{
						
						switch (reportType)
						{
							case "Active":
								worksheet.Cells[r, 3].Value = user.IsActive ? "Active" : "";
								break;
							case "Inactive":
								worksheet.Cells[r, 3].Value = user.IsActive ? "" : "Inactive";
								break;
							case "Confirmed":
								worksheet.Cells[r, 3].Value = user.EmailConfirmed ? "Confirmed" : "";
								break;
							case "Unconfirmed":
								worksheet.Cells[r, 3].Value = user.EmailConfirmed ? "" : "Unconfirmed";
								break;
							case "Locked":
								worksheet.Cells[r, 3].Value = user.LockoutEnabled ? "Locked" : "";
								break;
							case "Unlocked":
								worksheet.Cells[r, 3].Value = user.LockoutEnabled ? "" : "Unlocked";
								break;
						}
					}

					counter++;
					r++;
				}

				worksheet.Cells.AutoFitColumns();
				worksheet.Column(1).Width = 4;
				package.Save();
			}

			return stream;
		}


		public static async Task<MemoryStream> GetImportTemplateExcel(List<RoleModuleViewModel> groupedRoles, List<BusinessResource> resources)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Users List");

                // Header
                worksheet.Cells[1, 1].Value = "Title:";
                worksheet.Cells[1, 2].Value = "STG - Import User List Template";
                worksheet.Cells[2, 1].Value = "Generated at:";
                worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

                worksheet.Cells[4, 1].Value = "Full Name";
                worksheet.Cells[4, 2].Value = "Email";
                worksheet.Cells[4, 3].Value = "Password";
                worksheet.Cells[4, 4].Value = "Roles (comma-separated)";
                worksheet.Cells[4, 5].Value = "Resources";
                worksheet.Cells[4, 6].Value = "Phone Number";

                worksheet.Cells["A4:F4"].Style.Font.Bold = true;
                worksheet.Cells["A4:F4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:F4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells["A4:F4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                // Adding dropdowns for Roles (single selection as a guide)
                var rolesList = groupedRoles.SelectMany(gr => gr.Roles).Distinct().ToList();
                for (int i = 0; i < rolesList.Count; i++)
                {
                    worksheet.Cells["H" + (i + 1)].Value = rolesList[i];
                    worksheet.Column(8).Hidden = true;
                }
                var rolesValidation = worksheet.DataValidations.AddListValidation("D5:D1048576");
                rolesValidation.Formula.ExcelFormula = "H1:H" + rolesList.Count;

                // Adding dropdowns for Resources
                for (int i = 0; i < resources.Count; i++)
                {
                    worksheet.Cells["I" + (i + 1)].Value = resources[i].Fullname;
                    worksheet.Cells["J" + (i + 1)].Value = resources[i].Id; // Add resource ID in the next column
                    worksheet.Column(9).Hidden = true;
                    worksheet.Column(10).Hidden = true; // Hide the column containing resource IDs
                }
                var resourcesValidation = worksheet.DataValidations.AddListValidation("E5:E1048576");
                resourcesValidation.Formula.ExcelFormula = "I1:I" + resources.Count;

                // Instructions for user
                worksheet.Cells[3, 1].Value = "Instructions:";
                worksheet.Cells[3, 2].Value = "For Roles, you can select from the dropdown and input multiple roles separated by commas.";

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;
            return stream;
        }

		public static MemoryStream GetAuditTrailListExcel(IEnumerable<AuditTrail> model, string reportType, string searchTerm)
		{
			var stream = new MemoryStream();

			using (var package = new ExcelPackage(stream))
			{
				var worksheet = package.Workbook.Worksheets.Add("Audit Trail List");

				worksheet.Cells[1, 1].Value = "Title:";
				worksheet.Cells[1, 2].Value = $"STG - {reportType} Audit Trail List Report";
				worksheet.Cells[2, 1].Value = "Generated at:";
				worksheet.Cells[2, 2].Value = DateTime.Now.ToString();

				worksheet.Cells[4, 1].Value = "#";
				worksheet.Cells[4, 2].Value = "Module";
				worksheet.Cells[4, 3].Value = "Action";
				worksheet.Cells[4, 4].Value = "Description";
				worksheet.Cells[4, 5].Value = "Email";
				worksheet.Cells[4, 6].Value = "Date Time";

				worksheet.Cells["A4:F4"].Style.Font.Bold = true;
				worksheet.Cells["A4:F4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
				worksheet.Cells["A4:F4"].Style.Font.Color.SetColor(System.Drawing.Color.White);
				worksheet.Cells["A4:F4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

				var r = 5;
				var counter = 1;

				foreach (var audit in model)
				{
					if ((string.IsNullOrEmpty(searchTerm) || audit.UserEmail.Split('@')[0].Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
						(reportType == "All" ||
						reportType == "Administration" ||
						reportType == "Clients" ||
						reportType == "Resources" ||
						reportType == "Timesheet" ||
						reportType == "Proposals" ||
						reportType == "Projects" ||
						reportType == "Assets"))
					{
						worksheet.Cells[r, 1].Value = counter;
						worksheet.Cells[r, 2].Value = reportType == "All" ? audit.Module : GetModuleText(audit, reportType);
						worksheet.Cells[r, 3].Value = audit.Action;
						worksheet.Cells[r, 4].Value = audit.Description;
						worksheet.Cells[r, 5].Value = audit.UserEmail;
						worksheet.Cells[r, 6].Value = audit.DateTime.ToString();
						counter++;
						r++;
					}
				}

				worksheet.Cells.AutoFitColumns();
				worksheet.Column(1).Width = 7;
				package.Save();
			}

			return stream;
		}

		

	}
}








