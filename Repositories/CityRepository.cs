using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonInfoSystem.Data;
using PersonInfoSystem.Models;

namespace PersonInfoSystem.Repositories;

public class CityRepository : IRepository<CityEntity>
{
    private readonly PersonInfoDBContext _context;

    public CityRepository(PersonInfoDBContext context)
    {
        this._context = context;
    }

    public CityEntity Add(CityEntity city)
    {
        try
        {
            this._context.Cities.Add(city);
            this._context.SaveChanges();
            return city;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public List<CityEntity> GetAll()
    {
        try
        {
            return this._context.Cities.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public CityEntity GetById(int id)
    {
        try
        {
            return this._context.Cities.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public void Update(CityEntity city)
    {
        try
        {
            this._context.Cities.Update(city);
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
            var deleteCity = this._context.Cities.Find(id);
            if (deleteCity == null)
            {
                return false;
            }
            
            this._context.Cities.Remove(deleteCity);
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