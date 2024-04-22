using ITcompanyDB.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System.Reflection;
using System;

namespace ITcompanyDB.Models
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, List<Company> companies)
        {
			string result = "<tbody>";
            foreach (var company in companies)
            {
                string editUrl = $"/companies/edit/{company.CompanyId}";
                string deleteUrl = $"/companies/delete?companyid={company.CompanyId}";

				result = $"{result}<tr>" +
                    $"<td>{company.CompanyName}</td>" +
					$"<td>{company.FoundedDate}</td>" +
					$"<td>{company.Type}</td>" +
					$"<td>{company.EmployeeCount}</td>" +
					$"<td>{company.Revenue}</td>" +
					$"<td><td><a class=\"btn btn-link\" href=\"{editUrl}\">Edit</a></td></td>" +
					$"<td><a class=\"btn btn-link\" href=\"{deleteUrl}\" onclick=\"return confirmDelete()\">Delete</a></td>" +
					$"</tr>";
            }
            result = $"{result}</tbody>";
            return new HtmlString(result);
        }
    }
}