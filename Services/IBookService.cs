using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Services;

public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book Add(Book book);
    bool Update(Book book);
    bool Delete(int id);
}