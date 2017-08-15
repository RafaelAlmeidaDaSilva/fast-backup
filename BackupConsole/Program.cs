using System;
using System.IO;
using System.Collections.Generic;


namespace FastBackupConsole
{
    public class Arquivo
    {
        public enum Status
        {
            Modificado, Novo, Tranferido
        }
        public FileInfo arquivoInfo;
        public Status statusArquivo { get; set; }
    }

    public class Diretorio
    {
        public DirectoryInfo diretorioInfoAtual;
            
    }

    public class Arquivos : List<Arquivo>
    {

    }

    public class Diretorios : List<Diretorio>
    {

    }

    public class ArquivosTransferiveis
    {
        public Arquivos arquivosModificados = new Arquivos();
        public Arquivos arquivosCriados = new Arquivos();
    }

    public class Backup
    {
        public Arquivos arquivosDeTransferencia { get; set; }
        public Diretorios repositoriosBackup { get; set; } // mais de um repositrio, para o mesmo backup
        
    }

    public class CollectionBackup : List<Backup>
    {

    }

    public class Analise
    {
        public Arquivos recursividades(DirectoryInfo diretorioInfoAtual, Arquivos arquivos)
        {

                System.IO.FileInfo[] arquivosDirAtual = diretorioInfoAtual.GetFiles();

                if (arquivosDirAtual != null)
                {
                    foreach (System.IO.FileInfo arq in arquivosDirAtual)
                    {
                        Arquivo arquivo = new Arquivo();
                        arquivo.arquivoInfo = arq;
                        arquivos.Add(arquivo);
                    }

                    foreach (System.IO.DirectoryInfo dirInfo in diretorioInfoAtual.GetDirectories())
                        recursividades(dirInfo, arquivos);
                }
            

            return arquivos;
        }

        public Diretorios recursividades(DirectoryInfo diretorioInfoAtual, Diretorios diretoriosEncontrados)
        {
                foreach (System.IO.DirectoryInfo dirInfo in diretorioInfoAtual.GetDirectories())
                {
                    Diretorio diretorio = new Diretorio();
                    diretorio.diretorioInfoAtual = dirInfo;
                    diretoriosEncontrados.Add(diretorio);
                    recursividades(dirInfo, diretoriosEncontrados);
                }
                   
            return diretoriosEncontrados;
        }
    }

    public class BackupAnalise : Analise
    {
        public ArquivosTransferiveis arquivosTransferencia;

        public BackupAnalise(ArquivosTransferiveis transferencia)
        {
            arquivosTransferencia = transferencia;
        }

        public void validaBackup(Backup backup)
        {
            foreach (Diretorio clone in backup.repositoriosBackup)
            {
                Arquivos arquivosDiretorioClonado = recursividades(clone.diretorioInfoAtual, new Arquivos());
                int index = 0;
                if (!arquivosDiretorioClonado.Count.Equals(0))
                {
                    foreach (Arquivo arquivoDiretorioAnalisado in backup.arquivosDeTransferencia)
                    {
                        foreach (Arquivo arquivoDiretorioClonado in arquivosDiretorioClonado)
                        {
                            index++;
                            if (arquivoDiretorioClonado.arquivoInfo.Name.Equals(arquivoDiretorioAnalisado.arquivoInfo.Name))
                            {
                                if (arquivoDiretorioAnalisado.arquivoInfo.LastWriteTime.CompareTo(arquivoDiretorioClonado.arquivoInfo.LastWriteTime) > 0)
                                {
                                    arquivoDiretorioAnalisado.statusArquivo = Arquivo.Status.Modificado;
                                    arquivosTransferencia.arquivosModificados.Add(arquivoDiretorioAnalisado);
                                }
                                else if (arquivoDiretorioAnalisado.arquivoInfo.LastWriteTime.CompareTo(arquivoDiretorioClonado.arquivoInfo.LastWriteTime) < 0)
                                {
                                    arquivoDiretorioClonado.statusArquivo = Arquivo.Status.Tranferido;
                                    arquivoDiretorioAnalisado.statusArquivo = Arquivo.Status.Tranferido;
                                }
                                else if (arquivosDiretorioClonado.Count.Equals(index))
                                {
                                    arquivoDiretorioAnalisado.statusArquivo = Arquivo.Status.Novo;
                                    arquivosTransferencia.arquivosCriados.Add(arquivoDiretorioAnalisado);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Arquivo arquivo in backup.arquivosDeTransferencia)
                        arquivo.statusArquivo = Arquivo.Status.Novo;
                    arquivosTransferencia.arquivosCriados = backup.arquivosDeTransferencia;
                }
            }
        }

        public void validaBackup(CollectionBackup colecaoBackup)
        {
            foreach (Backup backup in colecaoBackup)
            {
                validaBackup(backup);
            }
        }

    }

    public class Sincronize
    {
        Diretorios RepositoriosSincronizaveis;

    }



   

    class Program
    {

        static void Main(string[] args)
        {
            String dirArquivosTrabalhados = @"/media/rafaelalmeidadasilva/Arquivos/Teste";
            String dirRepositorioBackup = @"/media/rafaelalmeidadasilva/Arquivos/Samba";

            Backup backup = new Backup();

            Diretorio diretorio = new Diretorio();
        
            try{
                    diretorio.diretorioInfoAtual = new DirectoryInfo(dirArquivosTrabalhados);
                    backup.arquivosDeTransferencia = convertToArquivos(diretorio.diretorioInfoAtual.GetFiles(), new Arquivos());

                    diretorio.diretorioInfoAtual = new DirectoryInfo(dirRepositorioBackup);
                    backup.repositoriosBackup = new Diretorios();
                    backup.repositoriosBackup.Add(diretorio); 

                    FileInfo[] arquivosDoDiretorioTrabalhado = (new DirectoryInfo(dirArquivosTrabalhados)).GetFiles();

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Program.listandoArray("Arquivos trabalhados do diretorio atual", arquivosDoDiretorioTrabalhado);

                    BackupAnalise backupAnalise = new BackupAnalise(new ArquivosTransferiveis());
                    backupAnalise.validaBackup(backup);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Program.listandoList("Arquivos Transferíveis ", backupAnalise.arquivosTransferencia.arquivosModificados);

            }catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        public static void listandoArray(String titulo, FileInfo[] arquivos)
        {
            Console.WriteLine("\n[{0}] ", titulo);

            foreach (FileInfo arquivo in arquivos)
            {
                Console.WriteLine(arquivo.FullName);
            }
        }

        public static void listandoList(String titulo, List<Arquivo> arquivos)
        {
            if (!arquivos.Count.Equals(0))
            {
                Console.WriteLine("\n[{0}] ", titulo);
                foreach (Arquivo arquivo in arquivos)
                {   
                    Console.WriteLine("Arquivo:{0} \n Data de Modificacão: {1} \n Data de Criação: {2} ", arquivo.arquivoInfo.FullName, 
                    arquivo.arquivoInfo.LastWriteTime.ToString(), arquivo.arquivoInfo.CreationTime.ToString());
                }
            }
        }

        public static Arquivos convertToArquivos(FileInfo[] files, Arquivos arquivos)
        {
            foreach (FileInfo file in files)
                arquivos.Add(convertToArquivo(file, new Arquivo()));
            
            return arquivos;
        }

        public static Arquivo convertToArquivo(FileInfo file, Arquivo arquivo)
        {
            arquivo.arquivoInfo = file;
            return arquivo;
        }
    }
}


