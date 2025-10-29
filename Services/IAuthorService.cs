using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Services;

public interface IAuthorService
{
    IEnumerable<Author> GetAll();
    Author? GetById(int id);
    Author Add(Author author);
    bool Update(Author author);
    bool Delete(int id);
}