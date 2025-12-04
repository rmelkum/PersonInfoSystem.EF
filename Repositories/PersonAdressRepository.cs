using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonInfoSystem.Data;
using PersonInfoSystem.Models;

namespace PersonInfoSystem.Repositories;

public class PersonAddressRepository
{
    private readonly PersonInfoDBContext _context;

    public PersonAddressRepository(PersonInfoDBContext context)
    {
        this._context = context;
    }

    public PersonAddressEntity Add(PersonAddressEntity personAddress)
    {
        try
        {
            this._context.PersonAddresses.Add(personAddress);
            this._context.SaveChanges();
            return personAddress;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public List<PersonAddressEntity> GetAll()
    {
        try
        {
            return this._context.PersonAddresses.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public PersonAddressEntity GetById(int id)
    {
        try
        {
            return this._context.PersonAddresses.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public void Update(PersonAddressEntity personAddress)
    {
        try
        {
            this._context.PersonAddresses.Update(personAddress);
            this._context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public bool DeleteById(int id)
    {
        try
        {
            var deletePersonAddress = this._context.PersonAddresses.Find(id);

            if (deletePersonAddress == null)
            {
                return false;
            }

            this._context.PersonAddresses.Remove(deletePersonAddress);
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
