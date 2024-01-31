namespace BancoAtlantidaChallenge.Application.Common.Utils;
public class NumeroDeAutorizacion
{
    public static string Generar()
    {
        int numeroAleatorio = new Random().Next(100000, 999999);
        return numeroAleatorio.ToString();
    }
}
