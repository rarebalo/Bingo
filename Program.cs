


int filas = 3;
int columnas = 9;
int[,] carton = new int[filas, columnas];
int[,] espaciosCarton = new int[filas, columnas];
bool ocupado = false;
bool repetido = false;
Random lugar = new Random();
Random numero = new Random();
int auxLugar = 0;
int auxNumero = 0;
int contador = 1;
int cantidadDeNumerosPorFila = 5;


//Lleno las dos matrises de -1 (una es la que va a contener los numero y otro es la que me va a indiar los espacios ocupados) para indicar que tal espacio esta vacio

for (int i = 0; i < filas; i++)
{
    for (int i2 = 0; i2 < columnas; i2++)
    {
        espaciosCarton[i, i2] = -1;
        carton[i, i2] = -1;
    }
}

for (int i = 0; i < filas; i++)
{
    for (int i2 = 0; i2 < columnas; i2++)
    {
        do
        {
            //genero un numero aleatorio entre el 0 y el 9 el cual me indicara el lugar en la fila donde pondre un nuevo numero 
            auxLugar = lugar.Next(columnas);          
            

            for (int i3 = 0; i3 < columnas; i3++)
            {
                //verifico que dicho lugar no este ocupado
                if (espaciosCarton[i, auxLugar] > -1)
                {                    
                    ocupado = true;
                    break;
                }//verifico que en la columna que corresponde al lugar no existan mas de 2 nuemeros 
                else if (espaciosCarton[0, auxLugar]+ espaciosCarton[1, auxLugar]>1)
                {                    
                    ocupado = true;
                    break;
                }
                else
                {
                    ocupado = false;
                }
            }


        } while (ocupado);        
        //marco el espacio ocupado 
        espaciosCarton[i,auxLugar] =+ 1 ;
        contador++;


        do
        {
            //genero un numero aleatorio teniendo en cuenta la columna
            if (auxLugar==8)
            {
                auxNumero = numero.Next(auxLugar * 10, ((auxLugar + 1) * 10)+1);
            }
            else
            {
                auxNumero = numero.Next(auxLugar * 10, (auxLugar + 1) * 10);
            }
       
            
            //verifico si dicho numero aleatorio no esta repetido
            for (int i3 = 0; i3 < i; i3++)
            {
                if (i>0 && carton[i3,auxLugar] == auxNumero)
                {
                    repetido = true;
                    break;
                }
                else
                {
                    repetido = false;
                }
            }

        } while (repetido);

        carton[i, auxLugar] = auxNumero;
        //verifico que no se generen mas de 5 numero en cada fila 
        if (contador > cantidadDeNumerosPorFila)
        {
            contador = 1;
            break;
        }

    }

}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

for (int i = 0; i < filas; i++)
{
    
    for (int i2 = 0; i2 < columnas; i2++)
    {        
        if (carton[i, i2] == -1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"  |");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(carton[i,i2].ToString("00")+"|");
        }
    }
    Console.WriteLine();
}

