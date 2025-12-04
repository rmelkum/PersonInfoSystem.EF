using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystem.Models;

    [Table("Person")]
    public class PersonEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string Surname { get; set; }
        public int? Age { get; set; }

        [MaxLength(100)]
        
        public string Mail { get; set; }
        
        [MaxLength(20)]
        public string NationalID { get; set; }
        
        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<PersonAddressEntity> PersonAdresses { get; set; } = new List<PersonAddressEntity>();

    public PersonEntity(string name, string surname, int age, string mail, string nationalID, string gender, string phoneNumber, DateTime dateOfBirth)
    {
        this.Name = name;
        this.Surname = surname;
        this.Age = age;
        this.Mail = mail;
        this.NationalID = nationalID;
        this.Gender = gender;
        this.PhoneNumber = phoneNumber;
        this.DateOfBirth = dateOfBirth;
    }
        public PersonEntity() 
        {}

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, Surname: {this.Surname}, Age: {this.Age}, Mail: {this.Mail}, NationalID: {this.NationalID}, Gender: {this.Gender}, PhoneNumber: {this.PhoneNumber}, DateOfBirth: {this.DateOfBirth:yyyy-MM-dd}";
        }
    }
