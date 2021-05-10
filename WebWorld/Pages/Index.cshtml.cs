// Brian Hodge
// C00170400
// CMPS 358
// Project #9

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using World;

namespace WebWorld.Pages
{
    public static class CitiesList
    {
        public static string GetCitiesList(string country)
        {
            using (var db = new World.World())
            {
                try
                {
                    var results =
                        from ci in db.Cities
                        join co in db.Countries
                            on ci.CountryCode equals co.Code
                        orderby ci.Name
                        where co.Name == country
                        select ci.Name;

                    if (!results.Any())
                    {
                        return $"";
                    }

                    string cities = $"Cities in {country}: ";
                    foreach (var c in results)
                        cities += $"{c}, ";
                    return cities;
                }
                catch (Exception e)
                {
                    return $"Error searching for cities in {country}";
                }
            }
        }
    }

    public static class CountriesInAContinent
    {
        public static string GetCountriesInAContinent(string continent)
        {
            using (var db = new World.World())
            {
                try
                {
                    var results =
                        from co in db.Countries
                        where co.Continent == continent
                        orderby co.Name
                        select co.Name;

                    if (!results.Any())
                    {
                        return $"";
                    }

                    string countries = $"Countries in {continent}: ";
                    foreach (var c in results)
                        countries += $"{c}, ";
                    return countries;
                }
                catch (Exception e)
                {
                    return $"Error searching for countries in {continent}";
                }
            }
        }
    }

    public static class ListByFirstLetter
    {
        public static List<string> GetListByFirstLetter(char letter)
        {
            using (var db = new World.World())
            {
                try
                {
                    var results =
                        from co in db.Countries.ToList()
                        where co.Name[0] == letter
                        orderby co.Name
                        select ($"{co.Name}, Continent: {co.Continent}, Region: {co.Region}, Code: {co.Code}").ToList();

                    
                    if (!results.Any())
                    {
                        return new List<string> {$""};
                    }
                    List<string> countryList = new List<string>();
                    foreach (var c in results)
                    {
                        countryList = new List<string> {$" {c}, "};
                        return countryList.ToList();
                    }

                    return countryList;
                }
                catch (Exception e)
                {
                    return new List<string> {$"Error searching for countries with first letter {letter}"};
                }
            }
        }
    }

    public static class ListInfoAboutCity
    {
        public static List<string> GetListInfoAboutCity(string city)
        {
            using (var db = new World.World())
            {
                try
                {
                    var results =
                        from ci in db.Cities
                        from co in db.Countries
                        where ci.CountryCode == co.Code
                        where ci.Name == city
                        orderby ci.Name
                        select (
                                $"City: {ci.Name}, Population: {ci.Population}, District: {ci.District}, Country: {co.Name}, CountryCode: {ci.CountryCode}")
                            .ToList();

                    if (results.Count() == 0)
                    {
                        Console.WriteLine("No cities listed with this name");
                    }

                    foreach (var c in results)
                    {
                        var list = new List<string>();
                        list.Add($" {c}, ");
                        return list;
                    }

                    Console.WriteLine();
                    
                }
                catch (Exception e)
                {
                    return new List<string> {$"Error searching for city {city}"};
                }
            }

            return null;
        }
    }
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Country { get; set; }
        [BindProperty]
        [Required]
        public string Continent { get; set; }
        [BindProperty]
        [Required]
        public char FirstLetter { get; set; }
        
        [BindProperty]
        [Required]
        public string City { get; set; }
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}