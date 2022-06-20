
string pathDirectory;
string pathIndexCsv = @"C:\TallerLenguajesC#\tp08-2022-SantiagoYalux\PuntoUno\PuntoUno\Archivos\index.csv";

//1,index,.txt
Console.WriteLine("Ingresa la direccion de una carpeta");
pathDirectory = Console.ReadLine();

//Si el archivo no existe lo creamos
if (!File.Exists(pathIndexCsv))
{
    File.Create(pathIndexCsv);
}

//Recuperamos los archivos de la carpeta ingresada y los recorremos para alcenar la informacion en index.csv
string[] files = Directory.GetFiles($@"{pathDirectory}");

if (files.Length > 0)
{
    foreach (var file in files)
    {

        Console.WriteLine("---------------------");
        FileInfo fileInfo = new FileInfo(file);
        Console.WriteLine("File Name = " + fileInfo.Name);
        Console.WriteLine("Extension name = " + fileInfo.Extension);

        string[] newData = new string[1];
        newData[0] = (RecuperarIndiceUltimoDato() + 1).ToString() + ',' + (fileInfo.Name.Split('.'))[0] + ',' + fileInfo.Extension;

        try
        {
            File.AppendAllLines(pathIndexCsv, newData);
            Console.WriteLine("**Archivo Agregado**");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        Console.WriteLine("---------------------");
    }
}
else
    Console.WriteLine("La carpeta no tiene archivos");



int RecuperarIndiceUltimoDato()
{
    int resultado = 0;
    List<string> Lineas = File.ReadAllLines(@"C:\TallerLenguajesC#\tp08-2022-SantiagoYalux\PuntoUno\PuntoUno\Archivos\index.csv").ToList();

    //Cuando salga del arreglo tendremos el ultimo indice
    foreach (var linea in Lineas)
    {
        var valores = linea.Split(',');
        resultado = int.Parse(valores[0]);
    }

    return resultado;
}

