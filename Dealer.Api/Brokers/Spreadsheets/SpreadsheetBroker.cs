using Bytescout.Spreadsheet;
using Dealer.Api.Models.ExternalApplicants;
using System;
using System.Collections.Generic;

namespace Dealer.Api.Brokers.Spreadsheets
{
    public class SpreadsheetBroker : ISpreadsheetBroker
    {
        public List<ExternalApplicant> applicants = new List<ExternalApplicant>();

        public List<ExternalApplicant> ImportApplicants(string filePath)
        {
            Spreadsheet document = new Spreadsheet();

            document.LoadFromFile(filePath);

            Worksheet worksheet = document.Workbook.Worksheets[0];

            for (int row = 1; row <= worksheet.UsedRangeRowMax; row++)
            {
                ExternalApplicant applicant = new ExternalApplicant();

                applicant.ExternalApplicantId = Guid.NewGuid();
                applicant.FirstName = worksheet.Cell(row, 1).ToString();
                applicant.LastName = worksheet.Cell(row, 2).ToString();
                applicant.PhoneNumber = worksheet.Cell(row, 3).ToString();
                applicant.Email = worksheet.Cell(row, 4).ToString();

                string dateString = worksheet.Cell(row, 5).ToString();
                if (DateTimeOffset.TryParse(dateString, out DateTimeOffset date))
                {
                    applicant.BirthDate = date;
                }

                applicant.GroupName = worksheet.Cell(row, 6).ToString();
                applicant.GroupId = Guid.NewGuid();
                applicants.Add(applicant);
            }

            document.Close();

            return applicants;
        }
    }
}