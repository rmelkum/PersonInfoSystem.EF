using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystem.Models;

[Table("PersonAdress")]
public class PersonAddressEntity
{
    public int PersonId { get; set; }
    public int AdressId { get; set; }

    public PersonEntity Person { get; set; }
    public AdressEntity Adress { get; set; }

}