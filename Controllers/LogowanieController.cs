using System;
using System.Linq;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SklepInternetowy.Models;
using SklepInternetowy.Data;

namespace SklepInternetowy.Controllers
{
[Route("api/[controller]")]
public class LogowanieController : Controller
{
private readonly ILogger<LogowanieController> _logger;
private readonly SklepInternetowyContext _context;
    public LogowanieController(ILogger<LogowanieController> logger, SklepInternetowyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost("Login")]
    public IActionResult Login(string email, string password)
    {
        Console.WriteLine(_context.Customer.Count());
        Console.WriteLine("email: " + email);
        var customer = _context.Customer.FirstOrDefault(c => c.Email == email);
        if (customer == null || customer.Password != password)
        {
            ViewBag.ErrorMessage = "Invalid email or password";
            return View("Login");
        }

        // HttpContext.Session.SetInt32("customerId", customer.CustomerId);
        // HttpContext.Session.SetString("isLoggedIn", true.ToString());

        // bool isLoggedIn = true;
        // ViewBag.LoggedIn = isLoggedIn;

        return RedirectToAction("Index", "Home");
    }


    [HttpGet("Register")]
    public IActionResult Register()
    {
        return View("Register");
    }

    [HttpPost("Register")]
    public IActionResult Register(string email, string password, string confirmPassword, string Name, string Address)
    {
        if (email.Length < 5 || password.Length < 5)
        {
            ViewBag.ErrorMessage = "Email and password must be at least 5 characters long";
            return View("Register");
        }

        if (!email.Contains("@"))
        {
            ViewBag.ErrorMessage = "Email must contain @";
            return View("Register");
        }

        if (password != confirmPassword)
        {
            ViewBag.ErrorMessage = "Passwords do not match";
            return View("Register");
        }

        if (Name.Length < 2 || Name.Length < 2)
        {
            ViewBag.ErrorMessage = "Name must be at least 2 characters long";
            return View("Register");
        }

        if (_context.Customer.Any(c => c.Email == email))
        {
            ViewBag.ErrorMessage = "Email already exists";
            return View("Register");
        }

        Customer customer = new Customer();
        customer.CustomerId = _context.Customer.Count() + 5;
        customer.Email = email;
        customer.Address = Address;

        customer.Password = BCrypt.Net.BCrypt.HashPassword(password);

        customer.Name = Name;

        _context.Customer.Add(customer);

        _context.SaveChanges();

        ViewBag.SuccessMessage = "Registration successful";

        var registeredCustomer = _context.Customer.FirstOrDefault(c => c.Email == email);

        // HttpContext.Session.SetInt32("customerId", registeredCustomer.CustomerId);
        // HttpContext.Session.SetString("isLoggedIn", true.ToString());

        return RedirectToAction("Index", "Home");
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("customerId");

        return RedirectToAction("Index", "Home");
    }
}
}
