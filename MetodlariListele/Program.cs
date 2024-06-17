using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var assembly = Assembly.Load("ApiLAyer");

// Controller sınıflarını bulma
var controllers = assembly.GetTypes()
    .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
    .ToList();

foreach (var controller in controllers)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Controller: {controller.Name}");
    Console.ResetColor();

    //metodları bulma , geri donus turu IActionResult olanlar
    var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
        .Where(m => !m.IsSpecialName &&
                   (typeof(IActionResult).IsAssignableFrom(m.ReturnType) ||
                   (m.ReturnType.IsGenericType && m.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))))
        .ToList();

    foreach (var method in methods)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"  Method:      {method.Name}");
        Console.ResetColor();
    }
}

/* 
 controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public) metodu,
belirtilen binding flag'lere göre controller'ın instance metotlarını döner.
BindingFlags.Instance: Sadece instance (örnek) metodları döner.
BindingFlags.DeclaredOnly: Sadece belirtilen türde tanımlanan metodları döner (miras alınan metodları döndürmez).
BindingFlags.Public: Sadece public metodları döner.
Where(m => !m.IsSpecialName && ... ) filtresi, özel isimlere sahip metodları (get, set, add, remove gibi) 
hariç tutar ve metodun dönüş türünü kontrol eder.
typeof(IActionResult).IsAssignableFrom(m.ReturnType): Metodun dönüş türü IActionResult veya ondan türetilmiş bir türse 
true döner.
(m.ReturnType.IsGenericType && m.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)): Metodun dönüş türü
generic bir Task ise true döner.
 
 
 */
