using Infrastructure.Entities;
using Infrastructure.Models.Users;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon.Models;

namespace Silicon.Controllers;

[Authorize]
public class AccountController(AccountService accountService, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly AccountService _accountService = accountService;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    #region Security

    public IActionResult Security()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordForm form)
    {
        if (form != null)
        {
            if (!string.IsNullOrEmpty(form.CurrentPassword) && !string.IsNullOrEmpty(form.NewPassword) && !string.IsNullOrEmpty(form.ConfirmPassword))
            {
                var result = await _accountService.ChangePasswordAsync(User, form);
                if (result == true)
                {
                    TempData["PasswordChangedUser"] = "User changed their password successfully.";
                    TempData["PasswordChanged"] = "Your password has been changed.";
                    return RedirectToAction("Security", "Account");
                }
                else
                {
                    TempData["StatusMessageUser"] = "User did NOT changed their password.";
                    TempData["StatusMessage"] = "Password NOT Changed.";
                    return RedirectToAction("Security", "Account");
                }
            }
        }

        return RedirectToAction("Security", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteForm form)
    {
        if (form != null)
        {
            var result = await _accountService.DeleteAsync(User);
            if (result == true)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Home", "Default");
            }
            else
            {
                TempData["StatusMessageDelete"] = "User is NOT deleted.";
                return RedirectToAction("Delete", "Account");
            }
        }

        return RedirectToAction("Delete", "Account");
    }

    #endregion

    #region Details
    public async Task<IActionResult> Details()
    {
        var user = await _accountService.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountBasicInfo
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Biography = user.Bio
            },
            AddressInfo = new AccountAddressInfo
            {
                AddressLine_1 = user.AddressLine_1!,
                AddressLine_2 = user.AddressLine_2,
                PostalCode = user.PostalCode!,
                City = user.City!
            }
        };

        return View(viewModel);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {
        if (model.BasicInfo != null)
        {
            if (!string.IsNullOrEmpty(model.BasicInfo.FirstName) && !string.IsNullOrEmpty(model.BasicInfo.LastName))
            {
                var result = await _accountService.UpdateBasicInfoAsync(User, model.BasicInfo);
            }
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if (model.AddressInfo != null)
        {
            if (!string.IsNullOrEmpty(model.AddressInfo.AddressLine_1) && !string.IsNullOrEmpty(model.AddressInfo.PostalCode) && !string.IsNullOrEmpty(model.AddressInfo.City))
            {
                var result = await _accountService.UpdateAddressInfoAsync(User, model.AddressInfo);
            }
        }

        return RedirectToAction("Details", "Account");
    }


    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);
        return RedirectToAction("Details", "Account");
    }

    #endregion
}
