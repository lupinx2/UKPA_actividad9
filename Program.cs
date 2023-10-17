using System;
using System.Net.Http;
using System.Threading.Tasks;

//COMPILADO PARA DOTNET 6.0

bool waitingForNumber = true;
Console.WriteLine("Actividad 9");
Console.WriteLine("___________");
while (waitingForNumber){
    Console.WriteLine("Primer numero?");
    var input1 = Console.ReadLine();
    if (float.TryParse(input1, out float num1))
    {
        Console.WriteLine("Segundo numero?");
        var input2 = Console.ReadLine();
        if (float.TryParse(input2, out float num2))
        {
            waitingForNumber = false;

            using (var httpClient = new HttpClient())
            {
                // Para correr este programa api_sum.php debe estar corriendo el servidor local en el puerto 6660
                var response = await httpClient.GetAsync($"http://127.0.0.1:6660/api_sum.php?num1={num1}&num2={num2}");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Resultado: {responseBody}");
            }
        }
        else
        {
            Console.WriteLine("Numero invalido");
        }
    }
    else
    {
        Console.WriteLine("Numero invalido");
    }
}

