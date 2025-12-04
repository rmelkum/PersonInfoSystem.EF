using System;
using PersonInfoSystem.Data;
using PersonInfoSystem.Models;
using PersonInfoSystem.Repositories;

class Program
{
    static void Main(string[] args)
    {
        using PersonInfoDBContext context = new PersonInfoDBContext();

        var countryRepo = new CountryRepository(context);
        var cityRepo = new CityRepository(context);
        var adressRepo = new AdressRepository(context);
        var personRepo = new PersonRepository(context);
        var personAddressRepo = new PersonAddressRepository(context);


        var countries = countryRepo.GetAll();
        foreach (var country in countries)
        {
            Console.WriteLine(country.ToString());
        }


    }
}