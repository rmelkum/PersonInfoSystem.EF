using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonInfoSystem.Data;
using PersonInfoSystem.Models;

namespace PersonInfoSystem.Repositories;

public class CountryRepository :IRepository<CountryEntity>
{
    private readonly PersonInfoDBContext _context;

    public CountryRepository(PersonInfoDBContext context)
    {
        this._context = context;
    }

    public CountryEntity Add(CountryEntity country)
    {
        try
        {
            this._context.Countries.Add(country);
            this._context.SaveChanges();
            return country;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public List<CountryEntity> GetAll()
    {
        try
        {
            return this._context.Countries.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public CountryEntity GetById(int id)
    {
        try
        {
            return this._context.Countries.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public void Update(CountryEntity country)
    {
        try
        {
            this._context.Countries.Update(country);
            this._context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
        }
    }

    public bool DeleteById(int id)
    {
        try
        {
            var deleteCountry = this._context.Countries.Find(id);
            if (deleteCountry == null)
            {
                return false;
            }
            this._context.Countries.Remove(deleteCountry);
            this._context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }
}