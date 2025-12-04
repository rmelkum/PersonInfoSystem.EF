using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonInfoSystem.Data;
using PersonInfoSystem.Models;

namespace PersonInfoSystem.Repositories;

public class AdressRepository : IRepository<AdressEntity>
{
    private readonly PersonInfoDBContext _context;

    public AdressRepository(PersonInfoDBContext context)
    {
        this._context = context;
    }

    public AdressEntity Add(AdressEntity adress)
    {
        try
        {
            this._context.Adressies.Add(adress);
            this._context.SaveChanges();
            return adress;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public List<AdressEntity> GetAll()
    {
        try
        {
            return this._context.Adressies.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public AdressEntity GetById(int id)
    {
        try
        {
            return this._context.Adressies.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public void Update(AdressEntity adress)
    {
        try
        {
            this._context.Adressies.Update(adress);
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
            var deleteAdress = this._context.Adressies.Find(id);
            if (deleteAdress == null)
            {
                return false;
            }

            this._context.Adressies.Remove(deleteAdress);
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