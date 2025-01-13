using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Data;
using ERP_API.Models.Projects.Projects;
using Microsoft.IdentityModel.Tokens;

namespace ERP_API.Models.Projects.Proposals
{
    public class ProposalReports
    {
        public static MemoryStream GetProposalListExcel(IEnumerable<ProposalCreateEditViewModel> viewModels)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Proposals");

                // Coloring
                worksheet.Cells[1, 1, 1, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1, 1, 13].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[1, 1, 1, 13].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                // Table Headers
                worksheet.Cells[1, 1].Value = "Proposal ID";
                worksheet.Cells[1, 2].Value = "Project Number";
                worksheet.Cells[1, 3].Value = "Project Name";
                worksheet.Cells[1, 4].Value = "Proposal Date";
                worksheet.Cells[1, 5].Value = "Client Name";
                worksheet.Cells[1, 6].Value = "Sector Name";
                worksheet.Cells[1, 7].Value = "Proposal Type";
                worksheet.Cells[1, 8].Value = "Project Type";
                worksheet.Cells[1, 9].Value = "Service Type";
                worksheet.Cells[1, 10].Value = "Complexity Level";
                worksheet.Cells[1, 11].Value = "Impact";
                worksheet.Cells[1, 12].Value = "Status";
                worksheet.Cells[1, 13].Value = "Total";
                var r = 2;
                foreach (var proposal in viewModels)
                {

                    // Assuming you want to fill the Excel cells with proposal data
                    worksheet.Cells[r, 1].Value = proposal.ProposalId;
                    worksheet.Cells[r, 2].Value = proposal.ProjectNumber; // Assuming Number is part of Proposal model
                    worksheet.Cells[r, 3].Value = proposal.ProjectName;
                    worksheet.Cells[r, 4].Value = proposal.ProposalDateString; // Assuming ProposalDate is formatted to string
                    worksheet.Cells[r, 5].Value = proposal.ClientName;
                    worksheet.Cells[r, 6].Value = proposal.SectorName;
                    worksheet.Cells[r, 7].Value = proposal.ProposalTypeName;
                    worksheet.Cells[r, 8].Value = proposal.ProjectTypeName;
                    worksheet.Cells[r, 9].Value = proposal.ServiceTypeName;
                    worksheet.Cells[r, 10].Value = proposal.ComplexityName;
                    worksheet.Cells[r, 11].Value = proposal.ImpactName;
                    worksheet.Cells[r, 12].Value = proposal.ProposalStatus;
                    worksheet.Cells[r, 13].Value = proposal.ProposalTotal?.ToString("C");

                    //Theming the range

                    worksheet.Cells[r, 1, r, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[r, 1, r, 13].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[r, 1, r, 13].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[r, 1, r, 13].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, 1, r, 13].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, 1, r, 13].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, 1, r, 13].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    r++;
                }

                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }

        #region Excel PM Proposal
        public static MemoryStream GetPMProposalExcel(ProposalCreateEditViewModel viewModel)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Proposal Data");

                //// The theme for data cells.
                //var dataStyle = package.Workbook.Styles.CreateNamedStyle("dataStyle");
                //dataStyle.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                //dataStyle.Style.Fill.PatternType = ExcelFillStyle.Solid;
                //dataStyle.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                //dataStyle.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                //PROPOSAL GENERAL DATA
                worksheet.Cells[1, 1].Value = "Proposal Data";
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[2, 1].Value = "Project Number";
                worksheet.Cells[2, 2].Value = "Project Name";
                worksheet.Cells[2, 3].Value = "Proposal Date";
                worksheet.Cells[2, 4].Value = "Client Name";
                worksheet.Cells[2, 5].Value = "Sector Name";
                worksheet.Cells[2, 6].Value = "Proposal Type";
                worksheet.Cells[2, 7].Value = "Project Type";
                worksheet.Cells[2, 8].Value = "Service Type";
                worksheet.Cells[2, 9].Value = "Complexity Level";
                worksheet.Cells[2, 10].Value = "Impact";
                worksheet.Cells[2, 11].Value = "Status";
                worksheet.Cells[2, 12].Value = "Duration(Months)";
                worksheet.Cells[2, 13].Value = "Duration(Hours)";

                for (var cell = 1; cell <= 13; cell++)
                {
                    worksheet.Cells[2, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[2, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[2, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }


                worksheet.Cells[3, 1].Value = viewModel.ProjectNumber; // Assuming Number is part of Proposal model
                worksheet.Cells[3, 2].Value = viewModel.ProjectName;
                worksheet.Cells[3, 3].Value = viewModel.ProposalDateString; // Assuming ProposalDate is formatted to string
                worksheet.Cells[3, 4].Value = viewModel.ClientName;
                worksheet.Cells[3, 5].Value = viewModel.SectorName;
                worksheet.Cells[3, 6].Value = viewModel.ProposalTypeName;
                worksheet.Cells[3, 7].Value = viewModel.ProjectTypeName;
                worksheet.Cells[3, 8].Value = viewModel.ServiceTypeName;
                worksheet.Cells[3, 9].Value = viewModel.ComplexityName;
                worksheet.Cells[3, 10].Value = viewModel.ImpactName;
                worksheet.Cells[3, 11].Value = viewModel.StatusName;
                worksheet.Cells[3, 12].Value = viewModel.Proposal.Duration; // Assuming Total is part of Proposal model
                worksheet.Cells[3, 13].Value = viewModel.Proposal.Duration * 172; // Assuming Total is part of Proposal model

                // data styling loop:
                for (int col = 1; col <= 13; col++)
                {
                    var cell = worksheet.Cells[3, col];
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                //PROPOSAL RESOURCE DATA
                worksheet.Cells[6, 1].Value = "Resources";
                worksheet.Cells[6, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[6, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[6, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[7, 1].Value = "PositionName";
                worksheet.Cells[7, 2].Value = "BareRate";
                worksheet.Cells[7, 3].Value = "Multiplier";
                worksheet.Cells[7, 4].Value = "BillRate";
                worksheet.Cells[7, 5].Value = "CommitPerc";
                worksheet.Cells[7, 6].Value = "Hours";
                worksheet.Cells[7, 7].Value = "Quantity";
                worksheet.Cells[7, 8].Value = "Cost";

                // Data header row color styling

                for (var cell = 1; cell <= 8; cell++)
                {
                    worksheet.Cells[7, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[7, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[7, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[7, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                var r = 8;
                foreach (var resource in viewModel.Proposal.Resources)
                {
                    worksheet.Cells[r, 1].Value = resource.Position;
                    worksheet.Cells[r, 2].Value = resource.BareRate.ToString("C");
                    worksheet.Cells[r, 3].Value = resource.Multiplier;
                    worksheet.Cells[r, 4].Value = resource.BillRate.ToString("C");
                    worksheet.Cells[r, 5].Value = resource.CommitPerc.ToString("P2");
                    worksheet.Cells[r, 6].Value = resource.Hours.ToString("N2");
                    worksheet.Cells[r, 7].Value = resource.Quantity;
                    worksheet.Cells[r, 8].Value = resource.CalcResourceCost().ToString("C");

                    // data styling loop:
                    for (int col = 1; col <= 8; col++)
                    {
                        var cell = worksheet.Cells[r, col];
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                    }

                    r += 1;
                }

                //making a little space for additional costs.

                r += 3;

                //PROPOSAL ADDITIONALCOSTS DATA

                worksheet.Cells[r, 1].Value = "AdditionalCosts";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[r + 1, 1].Value = "Item Name";
                worksheet.Cells[r + 1, 2].Value = "Description";
                worksheet.Cells[r + 1, 3].Value = "Units";
                worksheet.Cells[r + 1, 4].Value = "Cost x Units";
                worksheet.Cells[r + 1, 5].Value = "Quantity";
                worksheet.Cells[r + 1, 6].Value = "Cost";

                for (var cell = 1; cell <= 6; cell++)
                {
                    worksheet.Cells[r + 1, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[r + 1, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[r + 1, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[r + 1, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r + 1, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r + 1, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r + 1, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                r += 2;
                foreach (var additionalCost in viewModel.Proposal.AdditionalCosts)
                {
                    worksheet.Cells[r, 1].Value = additionalCost.Name;
                    worksheet.Cells[r, 2].Value = additionalCost.Description;
                    worksheet.Cells[r, 3].Value = additionalCost.Unit;
                    worksheet.Cells[r, 4].Value = additionalCost.CostPerUnit.ToString("C");
                    worksheet.Cells[r, 5].Value = additionalCost.Quantity;
                    worksheet.Cells[r, 6].Value = additionalCost.TotalCost.ToString("C");

                    // data styling loop:
                    for (int col = 1; col <= 6; col++)
                    {
                        var cell = worksheet.Cells[r, col];
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                    }

                    r += 1;
                }

                //PROPOSAL Indirect Cost DATA
                r += 2;
                worksheet.Cells[r, 1].Value = "Indirect Cost";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[r + 1, 1].Value = "Resource Costs Total";
                worksheet.Cells[r + 1, 2].Value = "Additional Costs Total";
                worksheet.Cells[r + 1, 3].Value = "Percentage";
                worksheet.Cells[r + 1, 4].Value = "Total Cost";

                for (var cell = 1; cell <= 4; cell++)
                {
                    worksheet.Cells[r + 1, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[r + 1, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[r + 1, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[r + 1, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r + 1, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r + 1, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r + 1, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                r += 2;
                worksheet.Cells[r, 1].Value = viewModel.Proposal.Resources.Sum(r => r.CalcResourceCost()).ToString("C");
                worksheet.Cells[r, 2].Value = viewModel.Proposal.AdditionalCosts.Sum(a => a.CalcTotalCost()).ToString("C");
                worksheet.Cells[r, 3].Value = viewModel.Proposal.IndirectPercentage * 100;
                worksheet.Cells[r, 4].Value = viewModel.Proposal.IndirectCost.ToString("C");

                // data styling loop:
                for (int col = 1; col <= 4; col++)
                {
                    var cell = worksheet.Cells[r, col];
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }


                r += 3;

                worksheet.Cells[r, 1].Value = "Proposal Total Cost Summary:";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                //Operations to get the sum of resources
                worksheet.Cells[r += 1, 1].Value = "Resources Total:";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = viewModel.Proposal.Resources.Sum(r => r.CalcResourceCost()).ToString("C");

                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);


                //Operations to get the sumo of additional costs.
                worksheet.Cells[r += 1, 1].Value = "Additional Costs Total:";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = viewModel.Proposal.AdditionalCosts.Sum(a => a.CalcTotalCost()).ToString("C");

                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);


                //Operations to get the sumo of additional costs.
                worksheet.Cells[r += 1, 1].Value = $"Indirect Costs Total (% {viewModel.Proposal.IndirectPercentage}):";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = viewModel.Proposal.IndirectCost.ToString("C");

                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);

                //Operations to get the sumo of the proposals costs.
                worksheet.Cells[r += 1, 1].Value = $"Proposal Costs Total:";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = (viewModel.Proposal.Resources.Sum(r => r.CalcResourceCost()) + viewModel.Proposal.AdditionalCosts.Sum(a => a.TotalCost) + viewModel.Proposal.IndirectCost).ToString("C");

                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                //write the file:
                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }

        #endregion Excel PM Proposal

        #region Excel AE Proposal

        public static MemoryStream GetAEDiscPercentProposalExcel(ProposalCreateEditViewModel viewModel)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Proposal Data");

                //PROPOSAL GENERAL DATA
                worksheet.Cells[1, 1].Value = "Proposal Data";
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[2, 1].Value = "Proposal Id";
                worksheet.Cells[2, 2].Value = "Project Number";
                worksheet.Cells[2, 3].Value = "Project Name";
                worksheet.Cells[2, 4].Value = "Proposal Date";
                worksheet.Cells[2, 5].Value = "Client Name";
                worksheet.Cells[2, 6].Value = "Sector Name";
                worksheet.Cells[2, 7].Value = "Proposal Type";
                worksheet.Cells[2, 8].Value = "Project Type";
                worksheet.Cells[2, 9].Value = "Service Type";
                worksheet.Cells[2, 10].Value = "Complexity Level";
                worksheet.Cells[2, 11].Value = "Impact";
                worksheet.Cells[2, 12].Value = "Status";
                worksheet.Cells[2, 13].Value = "Total";
                for (var cell = 1; cell <= 13; cell++)
                {
                    worksheet.Cells[2, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[2, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[2, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                worksheet.Cells[3, 1].Value = viewModel.ProposalId;
                worksheet.Cells[3, 2].Value = viewModel.ProjectNumber; // Assuming Number is part of Proposal model
                worksheet.Cells[3, 3].Value = viewModel.ProjectName;
                worksheet.Cells[3, 4].Value = viewModel.ProposalDateString; // Assuming ProposalDate is formatted to string
                worksheet.Cells[3, 5].Value = viewModel.ClientName;
                worksheet.Cells[3, 6].Value = viewModel.SectorName;
                worksheet.Cells[3, 7].Value = viewModel.ProposalTypeName;
                worksheet.Cells[3, 8].Value = viewModel.ProjectTypeName;
                worksheet.Cells[3, 9].Value = viewModel.ServiceTypeName;
                worksheet.Cells[3, 10].Value = viewModel.ComplexityName;
                worksheet.Cells[3, 11].Value = viewModel.ImpactName;
                worksheet.Cells[3, 12].Value = viewModel.StatusName;
                worksheet.Cells[3, 13].Value = viewModel.Proposal.Total?.ToString("C"); // Assuming Total is part of Proposal model

                // data styling loop:
                for (int col = 1; col <= 13; col++)
                {
                    var cell = worksheet.Cells[3, col];
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                //Discipline DATA
                worksheet.Cells[6, 1].Value = "Disciplines";
                worksheet.Cells[6, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[6, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[6, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[7, 1].Value = "Discipline Id";
                worksheet.Cells[7, 2].Value = "Discipline Name";
                worksheet.Cells[7, 3].Value = "Budget Percentage";
                worksheet.Cells[7, 4].Value = "Discipline Cost";
                worksheet.Cells[7, 5].Value = "Hours Allocated";

                for (var cell = 1; cell <= 5; cell++)
                {
                    worksheet.Cells[7, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[7, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[7, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[7, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                var r = 8;
                foreach (var discipline in viewModel.Proposal.DisciplinePercents)
                {
                    // Calculate PotentialAECostTotal based on the sum of discipline costs
                    decimal? potentialCostNullable = viewModel.Proposal.PotentialAECostTotal * (discipline.Percentage / 100);
                    decimal potentialCost = potentialCostNullable ?? 0;

                    // Calculate PotentialHrRate based on the potential A&E cost and proposal total
                    decimal? potentialTotalHoursNullable = potentialCostNullable / viewModel.Proposal.PotentialHrRate;
                    decimal potentialTotalHours = potentialTotalHoursNullable ?? 0;

                    worksheet.Cells[r, 1].Value = discipline.Discipline.Id;
                    worksheet.Cells[r, 2].Value = discipline.Discipline.Name;
                    worksheet.Cells[r, 3].Value = discipline.Percentage;
                    worksheet.Cells[r, 4].Value = potentialCost.ToString("C");
                    worksheet.Cells[r, 5].Value = potentialTotalHours;

                    // data styling loop:
                    for (int col = 1; col <= 5; col++)
                    {
                        var cell = worksheet.Cells[r, col];
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                    }

                    r += 1;
                }

                r += 3;

                worksheet.Cells[r, 1].Value = "Discipline Total Overview";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[r += 1, 1].Value = "Discipline Percentage Covered: ";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[r, 2].Value = viewModel.Proposal.DisciplinePercents.Sum(dp => dp.Percentage);
                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);

                worksheet.Cells[r += 1, 1].Value = "Discipline Hours Covered: ";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = viewModel.Proposal.DisciplinePercents.Sum(dp => dp.Hours);
                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);

                worksheet.Cells[r += 1, 1].Value = "Total Discipline Potential Cost: ";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = viewModel.Proposal.DisciplinePercents.Sum(dp => dp.PotentialDisciplineCost).ToString("C");
                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);


                //write the file:
                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }

        public static MemoryStream GetAEDesignPercentProposalExcel(ProposalCreateEditViewModel viewModel)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Proposal Data");

                //PROPOSAL GENERAL DATA
                worksheet.Cells[1, 1].Value = "Proposal Data";
                worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[2, 1].Value = "Proposal Id";
                worksheet.Cells[2, 2].Value = "Project Number";
                worksheet.Cells[2, 3].Value = "Project Name";
                worksheet.Cells[2, 4].Value = "Proposal Date";
                worksheet.Cells[2, 5].Value = "Client Name";
                worksheet.Cells[2, 6].Value = "Sector Name";
                worksheet.Cells[2, 7].Value = "Proposal Type";
                worksheet.Cells[2, 8].Value = "Project Type";
                worksheet.Cells[2, 9].Value = "Service Type";
                worksheet.Cells[2, 10].Value = "Complexity Level";
                worksheet.Cells[2, 11].Value = "Impact";
                worksheet.Cells[2, 12].Value = "Status";
                worksheet.Cells[2, 13].Value = "Total";
                for (var cell = 1; cell <= 13; cell++)
                {
                    worksheet.Cells[2, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[2, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[2, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[2, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                worksheet.Cells[3, 1].Value = viewModel.ProposalId;
                worksheet.Cells[3, 2].Value = viewModel.ProjectNumber; // Assuming Number is part of Proposal model
                worksheet.Cells[3, 3].Value = viewModel.ProjectName;
                worksheet.Cells[3, 4].Value = viewModel.ProposalDateString; // Assuming ProposalDate is formatted to string
                worksheet.Cells[3, 5].Value = viewModel.ClientName;
                worksheet.Cells[3, 6].Value = viewModel.SectorName;
                worksheet.Cells[3, 7].Value = viewModel.ProposalTypeName;
                worksheet.Cells[3, 8].Value = viewModel.ProjectTypeName;
                worksheet.Cells[3, 9].Value = viewModel.ServiceTypeName;
                worksheet.Cells[3, 10].Value = viewModel.ComplexityName;
                worksheet.Cells[3, 11].Value = viewModel.ImpactName;
                worksheet.Cells[3, 12].Value = viewModel.StatusName;
                worksheet.Cells[3, 13].Value = viewModel.Proposal.Total?.ToString("C"); // Assuming Total is part of Proposal model

                // data styling loop:
                for (int col = 1; col <= 13; col++)
                {
                    var cell = worksheet.Cells[3, col];
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                //Field Assessment Deliverable DATA
                worksheet.Cells[6, 1].Value = "Field Assessment Deliverables";
                worksheet.Cells[6, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[6, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[6, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[7, 1].Value = "Deliverable Id";
                worksheet.Cells[7, 2].Value = "Deliverable Name";
                worksheet.Cells[7, 3].Value = "Deliverable Cost";
                worksheet.Cells[7, 4].Value = "Start Date";
                worksheet.Cells[7, 5].Value = "End Date";

                for (var cell = 1; cell <= 5; cell++)
                {
                    worksheet.Cells[7, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[7, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[7, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[7, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[7, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                var r = 8;
                foreach (var deliverable in viewModel.Proposal.Deliverables.Where(d => d.Category == "Field Assessments and Studies"))
                {
                    worksheet.Cells[r, 1].Value = deliverable.Id;
                    worksheet.Cells[r, 2].Value = deliverable.Name;
                    worksheet.Cells[r, 3].Value = deliverable.Cost.ToString("C");
                    worksheet.Cells[r, 4].Value = deliverable.PlannedStartDate != DateTime.MinValue ? deliverable.PlannedStartDate.ToString("d") : "Date Not Set";
                    worksheet.Cells[r, 5].Value = deliverable.PlannedEndDate != DateTime.MinValue ? deliverable.PlannedEndDate.ToString("d") : "Date Not Set";

                    // data styling loop:
                    for (int col = 1; col <= 5; col++)
                    {
                        var cell = worksheet.Cells[r, col];
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                    }

                    r += 1;
                }

                r += 2;


                // Design Deliverable DATA
                worksheet.Cells[r, 1].Value = "Design Phase";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                r += 1;

                worksheet.Cells[r, 1].Value = "Deliverable Id";
                worksheet.Cells[r, 2].Value = "Deliverable Name";
                worksheet.Cells[r, 3].Value = "Deliverable Percent";
                worksheet.Cells[r, 4].Value = "Deliverable Cost";
                worksheet.Cells[r, 5].Value = "Start Date";
                worksheet.Cells[r, 6].Value = "End Date";

                for (var cell = 1; cell <= 6; cell++)
                {
                    worksheet.Cells[r, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[r, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[r, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[r, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                r += 1;

                foreach (var deliverable in viewModel.Proposal.Deliverables.Where(d => d.Category == "Design Phase"))
                {
                    worksheet.Cells[r, 1].Value = deliverable.Id;
                    worksheet.Cells[r, 2].Value = deliverable.Name;
                    worksheet.Cells[r, 3].Value = (deliverable.Percentage).ToString("P2");
                    worksheet.Cells[r, 4].Value = deliverable.Cost.ToString("C");
                    worksheet.Cells[r, 5].Value = deliverable.PlannedStartDate != DateTime.MinValue ? deliverable.PlannedStartDate.ToString("d") : "Date Not Set";
                    worksheet.Cells[r, 6].Value = deliverable.PlannedEndDate != DateTime.MinValue ? deliverable.PlannedEndDate.ToString("d") : "Date Not Set";

                    // data styling loop:
                    for (int col = 1; col <= 6; col++)
                    {
                        var cell = worksheet.Cells[r, col];
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                    }

                    r += 1;
                }

                r += 2;


                // Additional Services Deliverable DATA
                worksheet.Cells[r, 1].Value = "Additional Services";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                r += 1;

                worksheet.Cells[r, 1].Value = "Deliverable Id";
                worksheet.Cells[r, 2].Value = "Deliverable Name";
                worksheet.Cells[r, 3].Value = "Deliverable Cost";
                worksheet.Cells[r, 4].Value = "Start Date";
                worksheet.Cells[r, 5].Value = "End Date";

                for (var cell = 1; cell <= 5; cell++)
                {
                    worksheet.Cells[r, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[r, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[r, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[r, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                r += 1;

                foreach (var deliverable in viewModel.Proposal.Deliverables.Where(d => d.Category == "Additional Services"))
                {
                    worksheet.Cells[r, 1].Value = deliverable.Id;
                    worksheet.Cells[r, 2].Value = deliverable.Name;
                    worksheet.Cells[r, 3].Value = deliverable.Cost.ToString("C");
                    worksheet.Cells[r, 4].Value = deliverable.PlannedStartDate != DateTime.MinValue ? deliverable.PlannedStartDate.ToString("d") : "Date Not Set";
                    worksheet.Cells[r, 5].Value = deliverable.PlannedEndDate != DateTime.MinValue ? deliverable.PlannedEndDate.ToString("d") : "Date Not Set";

                    // data styling loop:
                    for (int col = 1; col <= 5; col++)
                    {
                        var cell = worksheet.Cells[r, col];
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                    }

                    r += 1;
                }



                r += 2;


                // Construction Support Lines
                worksheet.Cells[r, 1].Value = "Construction Support";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                r += 1;

                worksheet.Cells[r, 1].Value = "Support Costs";
                worksheet.Cells[r, 2].Value = "Support Percentage";
                worksheet.Cells[r, 3].Value = "Support Comment";

                for (var cell = 1; cell <= 3; cell++)
                {
                    worksheet.Cells[r, cell].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[r, cell].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    worksheet.Cells[r, cell].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                    worksheet.Cells[r, cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[r, cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                r += 1;

                worksheet.Cells[r, 1].Value = viewModel.Proposal.ConstructionSupportCost.ToString("C");
                worksheet.Cells[r, 2].Value = viewModel.Proposal.ConstructionSupportPercentage.ToString("P2");
                worksheet.Cells[r, 3].Value = viewModel.Proposal.ConstructionSupportComment;
                // worksheet.Cells[r, 4].Value = deliverable.PlannedEndDate?.ToString("d");

                // data styling loop:
                for (int col = 1; col <= 3; col++)
                {
                    var cell = worksheet.Cells[r, col];
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                r += 1;


                // Deliverable totals Overview

                r += 3;

                worksheet.Cells[r, 1].Value = "Design Total Overview";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#303549"));

                worksheet.Cells[r += 1, 1].Value = "Design Phase Percentage Covered: ";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;


                worksheet.Cells[r, 2].Value = viewModel.Proposal.Deliverables.Where(d => d.Category == "Design Phase").Sum(d => d.Percentage).ToString("P2");
                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);

                worksheet.Cells[r += 1, 1].Value = "Total Deliverable Cost: ";
                worksheet.Cells[r, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[r, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#9ea0a1"));
                worksheet.Cells[r, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[r, 2].Value = viewModel.Proposal.Deliverables.Sum(dp => dp.Cost).ToString("C");
                worksheet.Cells[r, 2].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[r, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cbced1"));
                worksheet.Cells[r, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                worksheet.Cells[r, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[r, 2].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);


                //write the file:
                worksheet.Cells.AutoFitColumns();
                package.Save();
            }

            return stream;
        }


        #endregion Excel AE Proposal

        #region PDF PM Proposal

        public static byte[] GetProposalsListPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Landscape());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't goin to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This pupy automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignRight().Text("Proposal Report").FontSize(14).Bold();
                            });
                        });
                    });

                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        //This is supposed to create a table 'row'?
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
                            table.Cell().Row(1).Column(2).Text($"STG - Proposal List Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);

                        });

                        // vertical border w/ padding.
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
                                // Project Number
                                cols.ConstantColumn(70);
                                // Proposal Name
                                cols.ConstantColumn(80);
                                // Client (Name)
                                cols.RelativeColumn();
                                // Sector
                                cols.ConstantColumn(50);
                                //  Proposal Type
                                cols.ConstantColumn(170);
                                // // Serervice Type
                                // cols.ConstantColumn(70);
                                // Project Type
                                cols.ConstantColumn(120);
                                // Status
                                cols.ConstantColumn(50);
                                // Status
                                cols.ConstantColumn(70);
                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Project Number").FontColor(dangerColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Proposal Name").Bold().FontColor(secondaryColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Client").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Sector").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Proposal & Service Type").FontColor(secondaryColor).FontSize(7);
                                // header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Service Type").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Project Type").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Status").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Total").FontColor(secondaryColor).FontSize(7);
                            });

                            var num = 1;
                            foreach (var proposal in viewModel.Proposals)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(proposal.Number).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(proposal.ProjectName).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(proposal.Client.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(proposal.SectorCategory.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text($"{proposal.ServiceType.Name}\n{proposal.ProposalType.Name}").FontSize(8);
                                // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(proposal.ServiceType.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(proposal.ProjectType.Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(proposal.ProposalStatus.StatusString).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(proposal.Total?.ToString("C")).FontSize(8);

                                num += 1;
                            }

                            //Section for totals

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(0).Text(viewModel.Proposals.Sum(p => p.Total)?.ToString("C")).FontColor(dangerColor).FontSize(8);

                        });

                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //throw new NotImplementedException();

            return document;
        }


        // PDF Generator for PM Proposals
        public static byte[] GetPMProposalDetailPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't goin to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            // row.ConstantItem(100).Column(col =>
                            // {
                            // var clientImgPath = Path.Combine(host.WebRootPath, "uploads", "clients", viewModel.Proposal.Client.ImageName);
                            // var clientImgData = System.IO.File.ReadAllBytes(clientImgPath);
                            //     col.Item().Border(0).Image(clientImgData);
                            //     col.Item().Border(0).AlignCenter().Text($"{viewModel.Proposal.Client.Name}").FontSize(9);
                            // });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignCenter().Text("Proposal Report").FontSize(14).Bold();
                                col.Item().AlignRight().Text("Generated at: " + DateTime.Now.ToString()).FontSize(10).Bold();
                            });
                        });
                    });

                    // Pages main content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // First content row (title & generation date)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(100);
                                cols.ConstantColumn(300);
                                cols.RelativeColumn();
                                cols.ConstantColumn(50);
                            });

                            table.Cell().Row(1).Column(1).Text("Proposal Title:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.Number} Report").FontSize(10);
                            table.Cell().Row(2).Column(1).Text("Proposal Description:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).Text($"{viewModel.Proposal.Description}").FontSize(10);

                            var clientImgPath = Path.Combine(host.ContentRootPath, "uploads", "clientsVendors", "images", viewModel.Proposal.Client.ImageName);
                            var clientImgData = System.IO.File.ReadAllBytes(clientImgPath);
                            table.Cell().RowSpan(2).Column(4).AlignRight().Image(clientImgData).FitArea();
                            // table.Cell().Row(2).Column(4).AlignCenter().Text($"{viewModel.Proposal.Client.ImageName}").FontSize(9);
                            // table.Cell().Row(3).Column(1).AlignCenter().Text("").FontSize(9);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Second content row (general proposal data)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(90);
                                cols.ConstantColumn(160);
                                cols.ConstantColumn(140);
                                cols.ConstantColumn(160);
                            });

                            // Left Half column

                            table.Cell().Row(1).Column(1).Text("Proposal Name:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.ProjectName}").FontSize(10);

                            table.Cell().Row(2).Column(1).Text("Service Type:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).AlignLeft().Text($"{viewModel.Proposal.ServiceType.Name}").FontSize(10);

                            table.Cell().Row(3).Column(1).Text("Project Type:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(2).AlignLeft().Text($"{viewModel.Proposal.ProjectType.Name}").FontSize(10);

                            table.Cell().Row(4).Column(1).Text("Sector:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(2).AlignLeft().Text($"{viewModel.Proposal.SectorCategory.Name}").FontSize(10);

                            // Right Half column

                            table.Cell().Row(1).Column(3).PaddingLeft(40).Text("Project Num:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(4).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.Number}").FontSize(10);

                            table.Cell().Row(2).Column(3).PaddingLeft(40).Text("Client:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(4).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.Client.Name}").FontSize(10);

                            table.Cell().Row(3).Column(3).PaddingLeft(40).Text("Service Duration:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(4).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.Duration} Months").FontSize(10);

                            table.Cell().Row(4).Column(3).PaddingLeft(40).Text("Proposal Hours:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(4).PaddingLeft(10).AlignLeft().Text($"{(viewModel.Proposal.Resources.Sum(r => r.Hours)).ToString("N0")} Hours").FontSize(10);

                        });

                        //  vertical border w/ padding.
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(90);
                                cols.RelativeColumn();
                            });

                        });

                        // Proposal Resources
                        if (viewModel.Proposal.Resources.Count > 0)
                        {

                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Discipline
                                    cols.RelativeColumn();
                                    // Budget Percentage
                                    cols.ConstantColumn(45);
                                    // Discipline Cost
                                    cols.ConstantColumn(35);
                                    // Discipline
                                    cols.ConstantColumn(55);
                                    // Budget Percentage
                                    cols.ConstantColumn(55);
                                    // Discipline Cost
                                    cols.ConstantColumn(55);
                                    // Discipline Cost
                                    cols.ConstantColumn(55);
                                    // Approx. Hours
                                    cols.ConstantColumn(60);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Resource").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Bare Rate").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Multiplier").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Bill Rate").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("% Commitment").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Hours").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Quantity").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);

                                });


                                foreach (ProjectResource resources in viewModel.Proposal.Resources)
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(resources.Position).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resources.BareRate.ToString("C")).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resources.Multiplier.ToString("0.##")).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resources.BillRate.ToString("C")).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text($"{resources.CommitPerc.ToString("P2")}").FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resources.Hours.ToString("N0") + " hr").FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resources.Quantity).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(resources.CalcResourceCost().ToString("C")).FontSize((float)7.5);

                                }



                                // Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("Total").Bold().FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.Resources.Sum(r => r.Hours).ToString("N0")).FontColor(dangerColor).FontSize((float)8.5);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.Resources.Sum(p => p.Quantity).ToString()).FontColor(dangerColor).FontSize((float)8.5);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.Resources.Sum(p => p.CalcResourceCost()).ToString("C")).FontColor(dangerColor).FontSize((float)8.5);

                            });
                        }

                        // Proposal Additional Costs
                        if (viewModel.Proposal.AdditionalCosts.Count > 0)
                        {

                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Discipline
                                    cols.RelativeColumn();
                                    // Budget Percentage
                                    cols.RelativeColumn();
                                    // Discipline Cost
                                    cols.ConstantColumn(70);
                                    // Cost per unit
                                    cols.ConstantColumn(70);
                                    // Discipline
                                    cols.ConstantColumn(55);
                                    // Approx. Hours
                                    cols.ConstantColumn(60);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Additional Item").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Description").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Unit").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost x Unit").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Quantity").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);

                                });

                                //And now we start dumping in OUR GOOD SHIIIIII.

                                foreach (AdditionalCost additionalCost in viewModel.Proposal.AdditionalCosts)
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(additionalCost.Name).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(additionalCost.Description).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(additionalCost.Unit).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(additionalCost.CostPerUnit.ToString("C")).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(additionalCost.Quantity).FontSize((float)7.5);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(additionalCost.TotalCost.ToString("C")).FontSize((float)7.5);
                                }



                                //Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(4).PaddingLeft(15).Text("Total").Bold().FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.AdditionalCosts.Sum(a => a.Quantity)).FontColor(dangerColor).FontSize((float)8.5);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.AdditionalCosts.Sum(p => p.CalcTotalCost()).ToString("C")).FontColor(dangerColor).FontSize((float)8.5);

                            });
                        }

                        // Proposal Indirect Costs
                        if (viewModel.Proposal.IndirectCost > 0)
                        {

                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Name
                                    cols.RelativeColumn();
                                    // Cost
                                    cols.ConstantColumn(60);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Indirect Cost").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Cost").FontColor(secondaryColor).FontSize(7);

                                });

                                if (!viewModel.Proposal.IndirectCostComment.IsNullOrEmpty())
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.IndirectPercentage.ToString("P2") + $"   ({viewModel.Proposal.IndirectCostComment})").FontSize((float)7.5);
                                }
                                else
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.IndirectPercentage.ToString("P2")).FontSize((float)7.5);
                                }
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.IndirectCost.ToString("C")).FontSize((float)7.5);



                                //Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingTop(4).PaddingRight(75).Text("Total").Bold().FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.IndirectCost.ToString("C")).FontColor(dangerColor).FontSize((float)8.5);

                            });
                        }



                        //col1.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(borderColor);


                        //Totals tables
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Total Headings
                                cols.RelativeColumn();
                                // Sums
                                cols.ConstantColumn(80);

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").FontColor(secondaryColor).FontSize(10);

                            });


                            //Caluclating totals & adding to final tally.

                            var total = viewModel.Proposal.Resources.Sum(r => r.CalcResourceCost()) + viewModel.Proposal.AdditionalCosts.Sum(a => a.CalcTotalCost()) + viewModel.Proposal.CalcTotalIndirectCost;
                            var b2bCost = viewModel.Proposal.IsB2B ? viewModel.Proposal.CalcB2BCost() : 0;

                            table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Resource Cost: ").Bold().FontSize(8);
                            table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.Resources.Sum(r => r.CalcResourceCost()).ToString("C")).FontSize(7);

                            table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Additional Cost:").Bold().FontSize(8);
                            table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.AdditionalCosts.Sum(a => a.CalcTotalCost()).ToString("C")).FontSize(7);

                            table.Cell().Row(3).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"Indirect Cost({viewModel.Proposal.IndirectPercentage.ToString("P2")}):").Bold().FontSize(8);
                            table.Cell().Row(3).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.CalcTotalIndirectCost.ToString("C")).FontSize(7);

                            if (viewModel.Proposal.IsB2B)
                            {
                                table.Cell().Row(4).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().PaddingTop(2).Text("B2B Cost:").Bold().FontSize(8);
                                table.Cell().Row(4).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignCenter().Padding(2).Text(b2bCost.ToString("C")).FontSize(7);

                                table.Cell().Row(5).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingTop(2).PaddingRight(60).Text("Total Cost:").Bold().FontSize(8);
                                table.Cell().Row(5).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignCenter().Padding(2).Text((total + viewModel.Proposal.CalcB2BCost()).ToString("C")).FontSize(9).Bold().FontColor(dangerColor);
                            }
                            else
                            {
                                table.Cell().Row(4).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingTop(2).PaddingRight(60).Text("Total Cost:").Bold().FontSize(8);
                                table.Cell().Row(4).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignCenter().Padding(2).Text(total.ToString("C")).FontSize(9).Bold().FontColor(dangerColor);
                            }



                        });

                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //Comment out after we got cheese.
            //throw new NotImplementedException();

            return document;
        }

        #endregion PDF PM Proposal

        #region PDF AE Proposal

        public static byte[] GetAEProposalDetailPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't goin to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This pupy automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignCenter().Text("Proposal Report").FontSize(14).Bold();
                                col.Item().AlignRight().Text("Generated at: " + DateTime.Now.ToString()).FontSize(10).Bold();
                            });
                        });
                    });

                    // Pages main content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // First content row (title & generation date)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(100);
                                cols.ConstantColumn(300);
                                cols.RelativeColumn();
                                cols.ConstantColumn(50);
                            });

                            table.Cell().Row(1).Column(1).Text("Proposal Title:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.Number} Report").FontSize(10);
                            table.Cell().Row(2).Column(1).Text("Proposal Description:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).Text($"{viewModel.Proposal.Description}").FontSize(10);

                            var clientImgPath = Path.Combine(
                                host.ContentRootPath, "uploads", "clientsVendors", "images", viewModel.Proposal.Client.ImageName
                                );
                            var clientImgData = System.IO.File.ReadAllBytes(clientImgPath);
                            table.Cell().RowSpan(2).Column(4).AlignRight().Image(clientImgData).FitArea();
                            // table.Cell().Row(2).Column(4).AlignCenter().Text($"{viewModel.Proposal.Client.ImageName}").FontSize(9);
                            // table.Cell().Row(3).Column(1).AlignCenter().Text("").FontSize(9);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Second content row (general proposal data)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(90);
                                cols.RelativeColumn();
                                cols.ConstantColumn(80);
                                cols.ConstantColumn(80);
                                cols.ConstantColumn(140);
                                cols.RelativeColumn();
                            });

                            // Left Half column

                            table.Cell().Row(1).Column(1).Text("Proposal Name:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.ProjectName}").FontSize(10);

                            table.Cell().Row(2).Column(1).Text("Service Type:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).AlignLeft().Text($"{viewModel.Proposal.ServiceType.Name}").FontSize(10);

                            table.Cell().Row(3).Column(1).Text("Project Type:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(2).AlignLeft().Text($"{viewModel.Proposal.ProjectType.Name}").FontSize(10);

                            table.Cell().Row(4).Column(1).Text("Sector:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(2).AlignLeft().Text($"{viewModel.Proposal.SectorCategory.Name}").FontSize(10);

                            // Center Half column

                            table.Cell().Row(1).Column(3).PaddingLeft(40).Text("Project Num:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(4).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.Number}").FontSize(10);

                            table.Cell().Row(2).Column(3).PaddingLeft(40).Text("Client:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(4).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.Client.Name}").FontSize(10);

                            table.Cell().Row(3).Column(3).PaddingLeft(40).Text("Status:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(4).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.ProposalStatus.StatusString}").FontSize(10);


                            // Right hand column

                            table.Cell().Row(1).Column(5).PaddingLeft(40).Text("Construction Duration:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(6).PaddingLeft(10).AlignLeft().Text($"{viewModel.Proposal.Duration} Months").FontSize(10);

                            table.Cell().Row(2).Column(5).PaddingLeft(40).Text("Proposal Hours:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(6).PaddingLeft(10).AlignLeft().Text($"{(viewModel.Proposal.Total / viewModel.Proposal.PotentialHrRate)?.ToString("N2")} Hours").FontSize(10);


                            table.Cell().Row(3).Column(5).PaddingLeft(40).Text("Project Budget:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(6).PaddingLeft(10).AlignLeft().Text($"{(viewModel.Proposal.Total.HasValue ? viewModel.Proposal.Total.Value.ToString("C") : "N/A")}").FontSize(10);

                        });


                        //  vertical border w/ padding.
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Third Content row
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(90);
                                cols.RelativeColumn();
                            });

                        });
                        if (viewModel.Proposal.Resources.Count > 0)
                        {
                            // Team Members

                            col1.Item().Text("Team Members").Bold().FontSize(12).FontColor(dangerColor);

                            // How many team members per row.
                            const int maxEntries = 10;

                            // Calculating required rows.
                            int totalMembers = viewModel.Proposal.Resources.Count;
                            int numRows = (int)Math.Ceiling(totalMembers / (double)maxEntries);

                            for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
                            {
                                // Add a new row for each set of up to 10 team members
                                col1.Item().Row(row =>
                                {
                                    row.Spacing(10);
                                    for (int colIndex = 0; colIndex < maxEntries; colIndex++)
                                    {
                                        // Calculate the actual index of the team member in the list
                                        int teamMemberIndex = rowIndex * maxEntries + colIndex;

                                        // Ensure the index is valid
                                        if (teamMemberIndex < totalMembers)
                                        {
                                            var teamMember = viewModel.Proposal.Resources[teamMemberIndex];

                                            // Render each team member in a relative column
                                            row.RelativeItem().Column(col =>
                                            {
                                                // Render team member image
                                                var imageURl = teamMember.Resource.GetImageUrl();
                                                if (!string.IsNullOrEmpty(imageURl))
                                                {
                                                    var imagePath = Path.Combine(host.WebRootPath, teamMember.Resource.GetImageUrl().TrimStart('/'));
                                                    if (File.Exists(imagePath))
                                                    {
                                                        try
                                                        {
                                                            byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
                                                            if (imageData != null && imageData.Length > 0)
                                                            {
                                                                byte[] circularImageData = ERP_API.Utils.Helpers.CreateCircularImage(imageData);
                                                                col.Item().Image(circularImageData);
                                                                col.Item().AlignCenter().Text(teamMember.Resource.Fullname).FontSize(8).Bold().FontColor(dangerColor);
                                                                col.Item().AlignCenter().Text(teamMember.Position).FontSize(7);
                                                            }
                                                            else
                                                            {
                                                                col.Item().Text("Image not available").FontSize(8).Italic();
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine($"Error loading image: {ex.Message}");
                                                            col.Item().Text("Error loading image").FontSize(8).Italic();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        col.Item().Text("Image not available").FontSize(8).Italic();
                                                    }
                                                }

                                                // Render team member name and position
                                                // col.Item().AlignCenter().Text(teamMember.Resource.Fullname).FontSize(8).Bold();
                                                // col.Item().AlignCenter().Text(teamMember.Position).FontSize(7);
                                            });
                                        }
                                        else
                                        {
                                            // Add an empty space to maintain alignment
                                            row.RelativeItem(1);  // Use the same relative size as for team members
                                        }
                                    }
                                });
                            }
                        }
                        if (viewModel.Proposal.Deliverables.Count > 0)
                        {

                            // Field Assessment Table
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Design
                                    cols.RelativeColumn();
                                    // Blank
                                    cols.RelativeColumn();
                                    // Subconsultant
                                    cols.ConstantColumn(60);
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Cost
                                    cols.ConstantColumn(80);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Field Assessments & Studies").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Subconsultant").Bold().FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Design Cost").FontColor(secondaryColor).FontSize(7);

                                });

                                var num = 1;
                                foreach (ProjectDeliverable deliverable in viewModel.Proposal.Deliverables.Where(d => d.Category == "Field Assessments and Studies"))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.Name).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(deliverable.IsSubconsultant ? "Yes" : "No").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(deliverable.TotalCost.ToString("C")).FontSize(8);
                                }


                                num += 1;


                                //Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingTop(2).Padding(2).Text("Total").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.Deliverables.Where(d => d.Category == "Field Assessments and Studies").Sum(p => p.TotalCost).ToString("C")).FontColor(dangerColor).FontSize(7);

                            });

                            //Design Phase Table
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Design Name
                                    cols.RelativeColumn();
                                    // Subconsultant
                                    cols.ConstantColumn(60);
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Budget percentage
                                    cols.ConstantColumn(60);
                                    // Design Cost
                                    cols.ConstantColumn(80);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Design Phase").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Subconsultant").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignRight().AlignBottom().Padding(2).Text("Budget %").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignRight().AlignBottom().PaddingRight(18).Padding(2).Text("Design Cost").FontColor(secondaryColor).FontSize(7);

                                });

                                var num = 1;
                                foreach (ProjectDeliverable deliverable in viewModel.Proposal.Deliverables.Where(d => d.Category == "Design Phase" && d.Category != "Construction Support"))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.Name).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(deliverable.IsSubconsultant ? "Yes" : "No").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(deliverable.Percentage.ToString("P2")).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(deliverable.TotalCost.ToString("C")).FontSize(8);
                                }


                                num += 1;


                                //Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().PaddingTop(0).Padding(0);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingTop(2).Padding(2).Text("Total").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text((viewModel.Proposal.Deliverables.Where(d => d.Category == "Design Phase").Sum(d => d.Percentage).ToString("P2"))).FontColor(dangerColor).FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(viewModel.Proposal.Deliverables.Where(d => d.Category == "Design Phase").Sum(p => p.TotalCost).ToString("C")).FontColor(dangerColor).FontSize(7);
                                // table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);

                            });


                            // Additional Services Table
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Discipline
                                    cols.RelativeColumn();
                                    // Is subconsultant
                                    cols.ConstantColumn(60);
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Approx. Hours
                                    cols.ConstantColumn(80);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Additional Services").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(dangerColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Subconsultant").FontColor(secondaryColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(dangerColor).FontSize(7);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignCenter().AlignBottom().Padding(2).Text("Design Cost").FontColor(secondaryColor).FontSize(7);

                                });

                                var num = 1;
                                foreach (ProjectDeliverable deliverable in viewModel.Proposal.Deliverables.Where(d => d.Category == "Additional Services"))
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(deliverable.Name).FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(deliverable.IsSubconsultant ? "Yes" : "No").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").FontSize(8);
                                    table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(deliverable.TotalCost.ToString("C")).FontSize(8);
                                }


                                num += 1;


                                //Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingTop(2).Padding(2).Text("Total").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().Padding(2).Text(viewModel.Proposal.Deliverables.Where(d => d.Category == "Additional Services").Sum(p => p.TotalCost).ToString("C")).FontColor(dangerColor).FontSize(7);

                            });

                            // Construction Support Table
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Discipline
                                    cols.RelativeColumn();
                                    // Approx. Hours
                                    cols.ConstantColumn(60);
                                    // Approx. Hours
                                    cols.ConstantColumn(60);
                                    // Approx. Hours
                                    cols.ConstantColumn(60);
                                    // Approx. Hours
                                    cols.ConstantColumn(60);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Construction Support").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").Bold().FontColor(dangerColor).FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Service Cost").FontColor(secondaryColor).FontSize(7);

                                });

                                var num = 1;

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.ConstructionSupportPercentage.ToString("P2")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.ConstructionSupportCost.ToString("C")).FontSize(8);

                                num += 1;


                                //Section for totals

                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("Total").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("").FontSize(6);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.ConstructionSupportCost.ToString("C")).FontColor(dangerColor).FontSize(7);

                            });

                            //Totals tables
                            col1.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    // Total Headings
                                    cols.RelativeColumn();
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Blank
                                    cols.ConstantColumn(60);
                                    // Sums
                                    cols.ConstantColumn(100);

                                });

                                //table headers
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").Bold().FontSize(8);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2);
                                    header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2);

                                });


                                var designPaseCost = viewModel.Proposal.Deliverables.Where(d => d.Category == "Design Phase").Sum(x => x.TotalCost);
                                var fieldAssessmentCost = viewModel.Proposal.Deliverables.Where(d => d.Category == "Field Assessments and Studies").Sum(x => x.TotalCost);
                                var additionalServiceCost = viewModel.Proposal.Deliverables.Where(d => d.Category == "Additional Services").Sum(x => x.TotalCost);
                                var constructionSupportCost = viewModel.Proposal.ConstructionSupportCost;
                                var supervisionServiceCost = viewModel.Proposal.SupervisionCost;
                                var totalCost = viewModel.Proposal.Deliverables.Sum(p => p.TotalCost) + constructionSupportCost + supervisionServiceCost;
                                var b2bCost = viewModel.Proposal.CalcB2BCost();

                                // table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Calculated Hours:").Bold().FontSize(8);
                                // table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text($"{sumOfHours}").FontSize(7);

                                table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Design Cost:").Bold().FontSize(8);
                                table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(1).Column(3).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(1).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(1).Column(5).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(designPaseCost.ToString("C")).FontSize(7);


                                table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Field Assessment Cost:").Bold().FontSize(8);
                                table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(2).Column(3).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(2).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(2).Column(5).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(fieldAssessmentCost.ToString("C")).FontSize(7);

                                table.Cell().Row(3).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Additional Service Cost:").Bold().FontSize(8);
                                table.Cell().Row(3).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(3).Column(3).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(3).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(3).Column(5).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(additionalServiceCost.ToString("C")).FontSize(7);

                                table.Cell().Row(4).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Supervision Services:").Bold().FontSize(8);
                                table.Cell().Row(4).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(4).Column(3).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(4).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(4).Column(5).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(supervisionServiceCost.ToString("C")).FontSize(7);

                                table.Cell().Row(5).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Construciton Support:").Bold().FontSize(8);
                                table.Cell().Row(5).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(5).Column(3).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(5).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                table.Cell().Row(5).Column(5).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(constructionSupportCost.ToString("C")).FontSize(7);

                                if (viewModel.Proposal.IsB2B)
                                {
                                    table.Cell().Row(6).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("B2B Cost:").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(3).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(5).BorderBottom(.8f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text(viewModel.Proposal.CalcB2BCost().ToString("C")).FontSize(7);

                                    table.Cell().Row(7).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(7).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(7).Column(3).BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("Total").FontSize(8);
                                    table.Cell().Row(7).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(7).Column(5).BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text((viewModel.Proposal.IsB2B ? totalCost + b2bCost : totalCost).ToString("C")).FontColor(dangerColor).Bold().FontSize(9);
                                }
                                else
                                {
                                    table.Cell().Row(6).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(3).BorderBottom(0.5f).BorderColor(borderColor).AlignCenter().PaddingTop(2).Padding(2).Text("Total").FontSize(8);
                                    table.Cell().Row(6).Column(4).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("").Bold().FontSize(8);
                                    table.Cell().Row(6).Column(5).BorderBottom(0.5f).BorderColor(borderColor).AlignRight().PaddingRight(18).Padding(2).Text((viewModel.Proposal.IsB2B ? totalCost + b2bCost : totalCost).ToString("C")).FontColor(dangerColor).Bold().FontSize(9);
                                }
                            });
                        }


                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //throw new NotImplementedException();

            return document;
        }

        public static byte[] GetStartingBudgetPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't goin to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignRight().Text("Proposal Report").FontSize(14).Bold();
                                col.Item().AlignRight().Text($"{viewModel.Proposal.ProposalFormat.Name} - {viewModel.Proposal.BillingStyle.Name}").FontSize(9).Bold();
                            });
                        });
                    });

                    // Pages main content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // First content row (title & generation date)
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
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.Number} Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Second content row (general proposal data)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(90);
                                cols.RelativeColumn();
                                cols.ConstantColumn(120);
                                cols.RelativeColumn();
                            });

                            // Left Half column

                            table.Cell().Row(1).Column(1).Text("Proposal Name:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.ProjectName}").FontSize(10);

                            table.Cell().Row(2).Column(1).Text("Service Type:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).Text($"{viewModel.Proposal.ServiceType.Name}").FontSize(10);

                            table.Cell().Row(3).Column(1).Text("Project Type").Bold().FontSize(10);
                            table.Cell().Row(3).Column(2).Text($"{viewModel.Proposal.ProjectType.Name}").FontSize(10);

                            table.Cell().Row(4).Column(1).Text("Sector").Bold().FontSize(10);
                            table.Cell().Row(4).Column(2).Text($"{viewModel.Proposal.SectorCategory.Name}").FontSize(10);

                            // Right Half column

                            table.Cell().Row(1).Column(3).PaddingLeft(40).Text("Project Number:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Number}").FontSize(10);

                            table.Cell().Row(2).Column(3).PaddingLeft(40).Text("Client:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Client.Name}").FontSize(10);

                            table.Cell().Row(3).Column(3).PaddingLeft(40).Text("Complexity:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Complexity.Name}").FontSize(10);

                            table.Cell().Row(4).Column(3).PaddingLeft(40).Text("Status:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.ProposalStatus.StatusString}").FontSize(10);

                        });


                        //  vertical border w/ padding.
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
                                // Budget
                                cols.RelativeColumn();
                                // Total
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocation").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").FontColor(secondaryColor).FontSize(7);

                            });

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Project Budget").FontSize(8);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.Total?.ToString("C")).FontSize(8);
                            table.Cell().Row(2).Column(1).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"A&E Budget (Eng  %${viewModel.Proposal.EngPercentStd})").FontSize(8);
                            table.Cell().Row(2).Column(2).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"{viewModel.Proposal.PotentialAECostTotal.ToString("C")}").FontSize(8);
                        });

                        // Floating Line Sepperator

                        //col1.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(borderColor);




                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //throw new NotImplementedException();

            return document;
        }
        public static byte[] GetBudgetedPhasesPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't goin to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignRight().Text("Proposal Report").FontSize(14).Bold();
                                col.Item().AlignRight().Text($"{viewModel.Proposal.ProposalFormat.Name} - {viewModel.Proposal.BillingStyle.Name}").FontSize(9).Bold();
                            });
                        });
                    });

                    // Pages main content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // First content row (title & generation date)
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
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.Number} Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Second content row (general proposal data)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(90);
                                cols.RelativeColumn();
                                cols.ConstantColumn(120);
                                cols.RelativeColumn();
                            });

                            // Left Half column

                            table.Cell().Row(1).Column(1).Text("Proposal Name:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.ProjectName}").FontSize(10);

                            table.Cell().Row(2).Column(1).Text("Service Type:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).Text($"{viewModel.Proposal.ServiceType.Name}").FontSize(10);

                            table.Cell().Row(3).Column(1).Text("Project Type").Bold().FontSize(10);
                            table.Cell().Row(3).Column(2).Text($"{viewModel.Proposal.ProjectType.Name}").FontSize(10);

                            table.Cell().Row(4).Column(1).Text("Sector").Bold().FontSize(10);
                            table.Cell().Row(4).Column(2).Text($"{viewModel.Proposal.SectorCategory.Name}").FontSize(10);

                            // Right Half column

                            table.Cell().Row(1).Column(3).PaddingLeft(40).Text("Project Number:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Number}").FontSize(10);

                            table.Cell().Row(2).Column(3).PaddingLeft(40).Text("Client:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Client.Name}").FontSize(10);

                            table.Cell().Row(3).Column(3).PaddingLeft(40).Text("Complexity:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Complexity.Name}").FontSize(10);

                            table.Cell().Row(4).Column(3).PaddingLeft(40).Text("Status:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.ProposalStatus.StatusString}").FontSize(10);

                        });


                        //  vertical border w/ padding.
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
                                // Budget
                                cols.RelativeColumn();
                                // Total
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocation").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").FontColor(secondaryColor).FontSize(7);

                            });

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Project Budget").FontSize(8);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.Total?.ToString("C")).FontSize(8);
                            table.Cell().Row(2).Column(1).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"A&E Budget (Eng  {viewModel.Proposal.EngPercentStd} %)").FontSize(8);
                            table.Cell().Row(2).Column(2).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"{viewModel.Proposal.PotentialAECostTotal.ToString("C")}").FontSize(8);
                        });

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Phase
                                cols.RelativeColumn();
                                // Allocated Percent
                                cols.RelativeColumn();
                                // Phase Cost
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Phase").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocated Percentage").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Phase Cost").FontColor(secondaryColor).FontSize(7);

                            });

                            var num = 1;
                            foreach (ProposalPhase proposalPhase in viewModel.Proposal.ProposalPhases)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Phases.FirstOrDefault(p => p.Id == proposalPhase.ServiceDeliverableId).Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"{proposalPhase.Percentage} %").FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(proposalPhase.Cost.ToString("C")).FontSize(8);
                            }


                            num += 1;


                            //Section for totals

                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(viewModel.Proposal.Sum(p => p.Total).ToString()).FontColor(dangerColor).FontSize(7);

                        });

                        // Floating Line Sepperator

                        //col1.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(borderColor);


                        //Totals tables
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Total Headings
                                cols.RelativeColumn();
                                // Sums
                                cols.ConstantColumn(60);

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").FontColor(secondaryColor).FontSize(7);

                            });


                            var sumOfPercentages = viewModel.Proposal.ProposalPhases.Sum(x => x.Percentage);
                            var sumOfCosts = viewModel.Proposal.ProposalPhases.Sum(x => x.Cost);

                            table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Calculated Phase Percentage:").Bold().FontSize(8);
                            table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text($"{sumOfPercentages} %").FontSize(7);

                            table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Potential Proposal Cost:").Bold().FontSize(8);
                            table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text(sumOfCosts.ToString("C")).FontSize(7);

                        });


                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //throw new NotImplementedException();

            return document;
        }

        public static byte[] GetDisciplinePercentPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't going to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignRight().Text("Proposal Report").FontSize(14).Bold();
                                col.Item().AlignRight().Text($"{viewModel.Proposal.ProposalFormat.Name} - {viewModel.Proposal.BillingStyle.Name}").FontSize(9).Bold();
                            });
                        });
                    });

                    // Pages main content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // First content row (title & generation date)
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
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.Number} Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Second content row (general proposal data)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(90);
                                cols.RelativeColumn();
                                cols.ConstantColumn(120);
                                cols.RelativeColumn();
                            });

                            // Left Half column

                            table.Cell().Row(1).Column(1).Text("Proposal Name:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.ProjectName}").FontSize(10);

                            table.Cell().Row(2).Column(1).Text("Service Type:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).Text($"{viewModel.Proposal.ServiceType.Name}").FontSize(10);

                            table.Cell().Row(3).Column(1).Text("Project Type").Bold().FontSize(10);
                            table.Cell().Row(3).Column(2).Text($"{viewModel.Proposal.ProjectType.Name}").FontSize(10);

                            table.Cell().Row(4).Column(1).Text("Sector").Bold().FontSize(10);
                            table.Cell().Row(4).Column(2).Text($"{viewModel.Proposal.SectorCategory.Name}").FontSize(10);

                            // Right Half column

                            table.Cell().Row(1).Column(3).PaddingLeft(40).Text("Project Number:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Number}").FontSize(10);

                            table.Cell().Row(2).Column(3).PaddingLeft(40).Text("Client:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Client.Name}").FontSize(10);

                            table.Cell().Row(3).Column(3).PaddingLeft(40).Text("Complexity:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Complexity.Name}").FontSize(10);

                            table.Cell().Row(4).Column(3).PaddingLeft(40).Text("Status:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.ProposalStatus.StatusString}").FontSize(10);

                        });


                        //  vertical border w/ padding.
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(90);
                                cols.RelativeColumn();
                            });

                        });

                        // Allocation Table.
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Budget
                                cols.RelativeColumn();
                                // Total
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocation").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").FontColor(secondaryColor).FontSize(7);

                            });

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Project Budget").FontSize(8);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.Total?.ToString("C")).FontSize(8);
                            table.Cell().Row(2).Column(1).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"A&E Budget (Eng  {viewModel.Proposal.EngPercentStd} %)").FontSize(8);
                            table.Cell().Row(2).Column(2).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"{viewModel.Proposal.PotentialAECostTotal.ToString("C")}").FontSize(8);
                        });

                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Discipline
                                cols.RelativeColumn();
                                // Allocated Percent
                                cols.RelativeColumn();
                                // Discipline Cost
                                cols.RelativeColumn();
                                // Hourly Rate
                                cols.RelativeColumn();
                                // Hours
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Discipline").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocated Percentage").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Discipline Cost").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Hourly Rate").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Hours").FontColor(secondaryColor).FontSize(7);

                            });

                            var num = 1;
                            foreach (DisciplinePercent disciplinePercent in viewModel.Proposal.DisciplinePercents)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Disciplines.FirstOrDefault(p => p.Id == disciplinePercent.DisciplineId).Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"{disciplinePercent.Percentage} %").FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(disciplinePercent.CalcPotentialDisciplineCost(viewModel.Proposal.PotentialAECostTotal)?.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(disciplinePercent.HourlyRate.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(disciplinePercent.Hours).FontSize(8);
                            }


                            num += 1;


                            //Section for totals

                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Total").FontColor(borderColor).FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text("").FontSize(6);
                            //table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignRight().Padding(2).Text(viewModel.Proposal.Sum(p => p.Total).ToString()).FontColor(dangerColor).FontSize(7);

                        });

                        // Floating Line Sepperator

                        //col1.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(borderColor);


                        //Totals tables
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Total Headings
                                cols.RelativeColumn();
                                // Sums
                                cols.ConstantColumn(60);

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").FontColor(secondaryColor).FontSize(7);

                            });


                            var sumOfPercentages = viewModel.Proposal.DisciplinePercents.Sum(x => x.Percentage);
                            var sumOfCosts = viewModel.Proposal.DisciplinePercents.Sum(x => x.CalcPotentialDisciplineCost(viewModel.Proposal.PotentialAECostTotal));

                            if (sumOfPercentages < 100 || sumOfPercentages > 100)
                            {
                                table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Calculated Phase Percentage:").Bold().FontSize(8);
                                table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text($"{sumOfPercentages} %").FontColor(dangerColor).FontSize(7);

                                table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Potential Proposal Cost:").Bold().FontSize(8);
                                table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text(sumOfCosts?.ToString("C")).FontColor(dangerColor).FontSize(7);
                            }

                            if (sumOfPercentages == 100)
                            {
                                table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Calculated Phase Percentage:").Bold().FontSize(8);
                                table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text($"{sumOfPercentages} %").FontSize(7);

                                table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Potential Proposal Cost:").Bold().FontSize(8);
                                table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text(sumOfCosts?.ToString("C")).FontSize(7);
                            }


                        });


                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //throw new NotImplementedException();

            return document;
        }

        public static byte[] GetArchDrafterPercentPDF(IWebHostEnvironment host, ProposalCreateEditViewModel viewModel)
        {
            var document = Document.Create(doc =>
            {
                //Color definitions
                string dangerColor = "#E61E24";
                string secondaryColor = "#303549";
                string borderColor = "#B6B6B6";
                string grayColor = "#B6B6B6";

                // Building Page
                doc.Page(page =>
                {
                    page.Margin(25);
                    page.Size(PageSizes.Letter.Portrait());
                    //Assuming that this is the 'column' for the header.
                    page.Header().ShowOnce().Column(col =>
                    {
                        //This makes an 'item' object
                        col.Item().Row(row =>
                        {
                            // setting the path for the logo de sharetech.
                            var imgPath = Path.Combine(host.WebRootPath, "images/logo.png");

                            // read image and cache bytes (memory)
                            byte[] imgData = System.IO.File.ReadAllBytes(imgPath);

                            // setting 'row' (actually a column)'s constant image, this isn't goin to get over imposed by anything.
                            row.ConstantItem(130).Image(imgData);

                            // This automatically aligns the row content relative to the other items in the page.
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().AlignLeft().Text("ShareTech Group").FontSize(9).Bold();
                                col.Item().AlignLeft().Text("Villa Blanca Industrial Park Plaza Bairoa Suite 215").FontSize(9);
                                col.Item().AlignLeft().Text("Caguas, P.R. 00725").FontSize(9);
                                col.Item().AlignLeft().Text("Phone: 787-720-5869").FontSize(9);
                            });

                            row.RelativeItem().Border(0).Column(col =>
                            {
                                col.Item().AlignRight().Text("Proposal Report").FontSize(14).Bold();
                                col.Item().AlignRight().Text($"{viewModel.Proposal.ProposalFormat.Name} - {viewModel.Proposal.BillingStyle.Name}").FontSize(9).Bold();
                            });
                        });
                    });

                    // Pages main content
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // First content row (title & generation date)
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
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.Number} Report").FontSize(10);
                            table.Cell().Row(1).Column(4).AlignRight().Text("Generated at: " + DateTime.Now.ToString()).Bold().FontSize(10);
                        });

                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);

                        // Second content row (general proposal data)
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(90);
                                cols.RelativeColumn();
                                cols.ConstantColumn(120);
                                cols.RelativeColumn();
                            });

                            // Left Half column

                            table.Cell().Row(1).Column(1).Text("Proposal Name:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(2).Text($"{viewModel.Proposal.ProjectName}").FontSize(10);

                            table.Cell().Row(2).Column(1).Text("Service Type:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(2).Text($"{viewModel.Proposal.ServiceType.Name}").FontSize(10);

                            table.Cell().Row(3).Column(1).Text("Project Type").Bold().FontSize(10);
                            table.Cell().Row(3).Column(2).Text($"{viewModel.Proposal.ProjectType.Name}").FontSize(10);

                            table.Cell().Row(4).Column(1).Text("Sector").Bold().FontSize(10);
                            table.Cell().Row(4).Column(2).Text($"{viewModel.Proposal.SectorCategory.Name}").FontSize(10);

                            // Right Half column

                            table.Cell().Row(1).Column(3).PaddingLeft(40).Text("Project Number:").Bold().FontSize(10);
                            table.Cell().Row(1).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Number}").FontSize(10);

                            table.Cell().Row(2).Column(3).PaddingLeft(40).Text("Client:").Bold().FontSize(10);
                            table.Cell().Row(2).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Client.Name}").FontSize(10);

                            table.Cell().Row(3).Column(3).PaddingLeft(40).Text("Complexity:").Bold().FontSize(10);
                            table.Cell().Row(3).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.Complexity.Name}").FontSize(10);

                            table.Cell().Row(4).Column(3).PaddingLeft(40).Text("Status:").Bold().FontSize(10);
                            table.Cell().Row(4).Column(4).PaddingLeft(40).Text($"{viewModel.Proposal.ProposalStatus.StatusString}").FontSize(10);

                        });


                        //  vertical border w/ padding.
                        col1.Item().PaddingVertical(1).LineHorizontal(0.5f).LineColor(borderColor);
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(90);
                                cols.RelativeColumn();
                            });

                        });

                        // Allocation Table.
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Budget
                                cols.RelativeColumn();
                                // Total
                                cols.RelativeColumn();
                                //Rate
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocation").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Percentage").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Rate").FontColor(secondaryColor).FontSize(7);

                            });

                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Architect").FontSize(8);
                            table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.DisciplinePercents[0].ArchitectPercent.ToString("P")).FontSize(8);
                            table.Cell().Row(2).Column(1).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Drafter").FontSize(8);
                            table.Cell().Row(2).Column(2).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.DisciplinePercents[0].DrafterPercent.ToString("P")).FontSize(8);
                            table.Cell().Row(1).Column(3).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.DisciplinePercents[0].ArchitectRate).FontSize(8);
                            table.Cell().Row(2).Column(3).BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Proposal.DisciplinePercents[0].DrafterRate).FontSize(8);
                        });


                        // Disciplines Table
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Discipline
                                cols.RelativeColumn();
                                // Allocated Percent
                                cols.RelativeColumn();
                                // Discipline Cost
                                cols.RelativeColumn();
                                // Hourly Rate
                                cols.RelativeColumn();
                                // Hours
                                cols.RelativeColumn();

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Discipline").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Allocated Percentage").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Discipline Cost").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Hourly Rate").FontColor(secondaryColor).FontSize(7);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Hours").FontColor(secondaryColor).FontSize(7);

                            });

                            foreach (DisciplinePercent disciplinePercent in viewModel.Proposal.DisciplinePercents)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(viewModel.Disciplines.FirstOrDefault(p => p.Id == disciplinePercent.DisciplineId).Name).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text($"{disciplinePercent.Percentage} %").FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(disciplinePercent.CalcPotentialDisciplineCost(viewModel.Proposal.PotentialAECostTotal)?.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(disciplinePercent.HourlyRate.ToString("C")).FontSize(8);
                                table.Cell().BorderBottom(0.5f).BorderColor(borderColor).AlignLeft().Padding(2).Text(disciplinePercent.Hours.ToString()).FontSize(8);
                            }





                        });

                        // Floating Line Separator

                        //col1.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(borderColor);


                        //Totals tables
                        col1.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                // Total Headings
                                cols.RelativeColumn();
                                // Sums
                                cols.ConstantColumn(60);

                            });

                            //table headers
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("Total").Bold().FontColor(dangerColor).FontSize(8);
                                header.Cell().Background(Colors.White).BorderBottom(.8f).BorderColor(Colors.Black).AlignLeft().AlignBottom().Padding(2).Text("").FontColor(secondaryColor).FontSize(7);

                            });


                            var sumOfPercentages = viewModel.Proposal.DisciplinePercents.Sum(x => x.Percentage);
                            var sumOfCosts = viewModel.Proposal.DisciplinePercents.Sum(x => x.CalcPotentialDisciplineCost(viewModel.Proposal.PotentialAECostTotal));

                            if (sumOfPercentages < 100 || sumOfPercentages > 100)
                            {
                                table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Calculated Phase Percentage:").Bold().FontSize(8);
                                table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text($"{sumOfPercentages} %").FontColor(dangerColor).FontSize(7);

                                table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Potential Proposal Cost:").Bold().FontSize(8);
                                table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text(sumOfCosts?.ToString("C")).FontColor(dangerColor).FontSize(7);
                            }

                            if (sumOfPercentages == 100)
                            {
                                table.Cell().Row(2).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Calculated Phase Percentage:").Bold().FontSize(8);
                                table.Cell().Row(2).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text($"{sumOfPercentages} %").FontSize(7);

                                table.Cell().Row(1).Column(1).BorderBottom(.8f).BorderColor(borderColor).AlignLeft().Padding(2).Text("Potential Proposal Cost:").Bold().FontSize(8);
                                table.Cell().Row(1).Column(2).BorderBottom(.8f).BorderColor(borderColor).AlignRight().Padding(2).Text(sumOfCosts?.ToString("C")).FontSize(7);
                            }


                        });


                        col1.Spacing(10);
                    });

                    //Defining page footer for 'pagination'
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });

            }).GeneratePdf();

            //throw new NotImplementedException();

            return document;
        }


        #endregion PDF AE Proposal
    }

}