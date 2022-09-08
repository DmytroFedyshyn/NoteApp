using Microsoft.AspNetCore.Identity;
using NoteApp.Models;

namespace NoteApp.Data
{
	public class Initializer
	{
		public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationContext applicationContext)
		{
			if (await roleManager.FindByNameAsync("Admin") is null)
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));
			}
			string email = "test@mail.com";
			string password = "123456";
			if (await userManager.FindByNameAsync(email) is null)
			{
				User user = new User { Email = email, UserName = email };
				IdentityResult identityResult = await userManager.CreateAsync(user, password);
				if (identityResult.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Admin");
				}
			}
            if (!applicationContext.Notes.Any())
            {
				var currrentUser = await userManager.FindByEmailAsync(email);
				applicationContext.Notes.Add(new Note
                {
					Name = "Note 1",
					Description = "Desc 1",
					CreatedDate = DateTime.Now,
					User = currrentUser
				});
				applicationContext.SaveChanges();
            }

		}
	}
}
