using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetodlariListele
{
    public class ControllerListele
    {
        public void Listele()
        {
            var assembly = Assembly.Load("ApiLAyer");

            // Controller sınıflarını bulma
            var controllers = assembly.GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                .ToList();

            foreach (var controller in controllers)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Controller: {controller.Name}");
                Console.ResetColor();

                var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                    .Where(m => !m.IsSpecialName &&
                               (typeof(IActionResult).IsAssignableFrom(m.ReturnType) ||
                               (m.ReturnType.IsGenericType && m.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))))
                    .ToList();

                foreach (var method in methods)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"  Method: {method.Name}");
                    Console.ResetColor();
                }
            }
        }
    }
}
