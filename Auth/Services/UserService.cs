using Auth.Context;
using Auth.Interfaces;
using Auth.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth.Services;

public class UserService(PostgresContext context) : ICommonServices<User>
{
    public async Task<User> AddAsync(User entity)
    {
        try
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteAsync(User entity)
    {
        try
        {
            context.Users.Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if (user != null)
                return user;
            
            return new();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
            return await context.Users.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<User> UpdateAsync(User entity)
    {
        try
        {
            var oldUser = await GetByIdAsync(entity.Id);
            if (oldUser.Id == 0)
                return oldUser;
            
            oldUser.FirstName = entity.FirstName;
            oldUser.LastName = entity.LastName;
            oldUser.Email = entity.Email;
            oldUser.Username = entity.Username;
            oldUser.Password = entity.Password;
            oldUser.IsActive = entity.IsActive;
            oldUser.dateOfBirth = entity.dateOfBirth;
            
            context.Users.Update(oldUser);
            await context.SaveChangesAsync();
            return oldUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}