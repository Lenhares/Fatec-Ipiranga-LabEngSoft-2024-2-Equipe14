using Microsoft.EntityFrameworkCore;
using SweetMagic.Models;
using SweetMagic.Data;
using SweetMagic.Helpers;
using Org.BouncyCastle.Crypto.Digests;

namespace SweetMagic.Services
{
    public class UserService {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context) {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(string email, string nome, string password) {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                return false; // User already exists

            var user = new User {
                Email = email,
                Nome = nome,
                PasswordHash = PasswordHelper.HashPassword(password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginUserAsync(string email, string password) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null && PasswordHelper.VerifyPassword(password, user.PasswordHash);
        }
    }
}
