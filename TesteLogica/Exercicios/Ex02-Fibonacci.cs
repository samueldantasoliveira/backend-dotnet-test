namespace Exercicios;

public static class Ex02_Fibonacci
{
    public static List<int> Gerar(int quantidade)
    {
        var resultado = new List<int>();

        if(quantidade <= 0)
            return resultado;

        if(quantidade >= 1)    
            resultado.Add(0);
        if(quantidade >= 2)
            resultado.Add(1);
        
        for(int i = 2; i < quantidade; i++)
        {
            int atual = resultado[i - 2] + resultado[i - 1];
            resultado.Add(atual);
        }
        return resultado;
    }
}