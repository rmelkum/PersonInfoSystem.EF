using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonInfoSystem.Data;
using PersonInfoSystem.Models;

namespace PersonInfoSystem.Repositories;

public class PersonRepository : ICRUDRepository<PersonEntity>
{
    private readonly PersonInfoDBContext _context;

    public PersonRepository(PersonInfoDBContext personInfoDBContext)
    {
        this._context = personInfoDBContext;
    }
    public PersonEntity Add(PersonEntity person)
    {
        try
        {
            this._context.Persons.Add(person);
            this._context.SaveChanges();
            return person;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public List<PersonEntity> GetAll()
    {
        try
        {
            return this._context.Persons.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public PersonEntity? GetById(int id)
    {
        try
        {
            return this._context.Persons.Find(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
    public void Update(PersonEntity person)
    {
        try
        {
            this._context.Persons.Update(person);
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
            var deletePerson = this._context.Persons.Find(id);
            if(deletePerson == null)
            {
                return false;
            }
            this._context.Persons.Remove(deletePerson);
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
