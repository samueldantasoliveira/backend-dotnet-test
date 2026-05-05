namespace Exercicios;

public static class Ex03_NormalizarTexto
{
    public static string Normalizar(string textoOriginal)
    {
        string resultado = "";
        char ultimo = ' ';

        foreach(char c in textoOriginal)
        {
            if(c == '?')
            {
                if (ultimo == '?')
                {
                    continue;
                }
            }

            if(c == '!')
            {
                if (ultimo == '!')
                {
                    continue;
                }
            }
            resultado+= c;
            ultimo = c;
        }
        return resultado;
    }
}